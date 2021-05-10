using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using Grimoire.Game;
using Grimoire.Networking;
using Newtonsoft.Json.Linq;

namespace ExamplePacketPlugin
{
    public partial class Main : Form
    {
        public static Main Instance { get; } = new Main();

        public Main()
        {
            InitializeComponent();
        }

        /*
        public JoinHandler Handler { get; } = new JoinHandler();

        private void chkenable_checkedchanged(object sender, eventargs e)
        {
            if (chkenable.checked)
            {
                handler.maptojoin = txtmap.text;
                proxy.instance.registerhandler(handler);
            }
            else
            {
                proxy.instance.unregisterhandler(handler);
            }
        }
        */

        List<Item> drops = new List<Item>();
        bool isInvenLoaded = false;
        int bagSlots = 0;

        bool needToGrab = false;
        int UID = 0;
        int mapSessionID = 1;
        int numDroppedItems = 0;
        bool inBank = false;

        TreeNode tempSelectedNode;

        string bankItemsMsg;
        string invItemsMsg;

        bool isInvNeedToParse = false;
        bool isBankNeedToParse = false;

        List<string> LMsg = new List<string>();
        List<string> UpdQtyMsg = new List<string>();

        List<string> EquipMsg = new List<string>();
        List<string> EquipmentMsg = new List<string>();

        bool isBotNotActive = true;

        private async void cbEnable_CheckedChanged(object sender, EventArgs e)
        {
            if (cbEnable.Checked)
            {
                if (Player.IsLoggedIn)
                {
                    cbEnable.Checked = false;
                    MessageBoxEx.Show(this, "You must be logged out to enable it.", "Oops");
                    return;
                }

                startStateUI();

                Player.Logout();
                Proxy.Instance.ReceivedFromServer += MapHandler;
                Proxy.Instance.ReceivedFromClient += MapHandler;

                while (cbEnable.Checked)
                {
                    if (Grimoire.Botting.OptionsManager.IsRunning && isBotNotActive)
                    {
                        MessageBoxEx.Show(this, "Bot activation makes this plugin release all drops,\r\n" +
                            "but you can decline it, and all your drops still on the list!", "Oops");
                        tbDrop.Text += "*Attention: you can use this plugin with Bot " +
                            "but we don't recommend you to do so.";

                        cbAutoAtt.Checked = false;

                        foreach(Item drop in drops)
                        {
                            if(drop.IQty > 0 && drop.FirstDropMsg != null)
                            {
                                Proxy.Instance.SendToClient(drop.FirstDropMsg);
                                drop.FirstDropMsg = string.Empty;
                            }
                        }
                        isBotNotActive = false;
                    }
                    if (!Grimoire.Botting.OptionsManager.IsRunning)
                    {
                        isBotNotActive = true;
                    }
                    if (!Player.IsLoggedIn)
                    {
                        cbEnable.Enabled = true;
                        cbHidePlayer.Checked = false;

                        isInvNeedToParse = false;
                        isBankNeedToParse = false;
                        this.numDroppedItems = 0;

                        drops.Clear();
                        EquipmentMsg.Clear();
                        tvDropMain.Nodes.Clear();
                        tvDropPool.Nodes.Clear();
                        this.bagSlots = 0;
                        await Task.Delay(1000);
                    }
                    else
                    {
                        cbEnable.Enabled = false;
                    }
                    if (inBank)
                    {
                        inBankMsgBox();
                        inBank = false;
                    }
                    if (needToGrab)
                    {
                        await Task.Delay(100);

                        grabTreeDrops();
                        tvDropPool.Enabled = true;
                        tvDropMain.Enabled = true;
                        needToGrab = false;
                    }
                    if (isInvNeedToParse && (invItemsMsg != null))
                    {
                        listFromChar(invItemsMsg);
                        isInvNeedToParse = false;
                    }
                    if (isBankNeedToParse && (bankItemsMsg != null))
                    {
                        listFromChar(bankItemsMsg);
                        isBankNeedToParse = false;
                    }
                    if (LMsg.Any())
                    {
                        List<string> tempLMsg = new List<string>(LMsg);
                        this.LMsg.Clear();
                        try { listDropItem(tempLMsg); }
                        catch (Exception ex) { errorMsg(ex); }
                        tempLMsg.Clear();
                        needToGrab = true;
                    }
                    if (UpdQtyMsg.Any())
                    {
                        List<string> tempUpQty = new List<string>(UpdQtyMsg);
                        this.UpdQtyMsg.Clear();

                        updQtyList(tempUpQty);
                        tempUpQty.Clear();

                        // making the drops sorted by its quantity (not actived)
                        // drops = drops.OrderByDescending(o => o.IQty).ToList();
                        needToGrab = true;
                    }
                    if (EquipMsg.Any())
                    {
                        List<string> tempEquipMsg = new List<string>(EquipMsg);
                        this.EquipMsg.Clear();

                        updEquipment(tempEquipMsg);
                        tempEquipMsg.Clear();

                    }
                    try
                    {
                        lbInfo.Text = $"(Inv: {(isInvenLoaded ? Player.Inventory.Items.Count : 0)}/{bagSlots})";
                        lbDropItems.Text = $"Main Drop: {tnCount(0)} item(s)";
                        lbDropPool.Text = $"Drop Pool: {tnCount(1)} item(s)";
                    }
                    catch
                    {
                        tbDrop.Text = string.Empty;
                        tbDrop.Text = "**is the number of inventory items not match? try relogging/joining somewhere.\r\n";
                    }
                    await Task.Delay(100);
                }
            }
            else
            {
                stopStateUI();
                Proxy.Instance.ReceivedFromServer -= MapHandler;
                Proxy.Instance.ReceivedFromClient -= MapHandler;
            }
        }

        public void MapHandler(Grimoire.Networking.Message message)
        {
            string msg = message.ToString();

            try
            {
                if (msg.Contains("{\"cmd\":\"dropItem"))
                {
                    if (!Grimoire.Botting.OptionsManager.IsRunning)
                    {
                        message.Send = false;
                    }

                    int tempItemID = getItemID(msg);
                    int tempIQty = getiQty(msg);

                    if (isListed(tempItemID))
                    {
                        this.UpdQtyMsg.Add(msg);
                    }
                    else
                    {
                        this.LMsg.Add(msg);
                    }

                    /*if (msg.Contains("bTemp\":"))
                    {
                        Proxy.Instance.SendToClient(msg.Replace("bTemp\":0", "bTemp\":1"));
                    }*/

                    tbDrop.Text = string.Empty;

                    /*foreach (Item drop in drops)
                    {
                        if (drop.IQty != 0)
                        {
                            tbDrop.Text += drop.toString() + "\r\n";
                        }
                    }*/
                    //tbDrop.Text += this.mapSessionID + " <mapSessionID\r\n";

                    this.numDroppedItems += tempIQty;
                    tbDrop.Text += numDroppedItems > 10 ?
                        numDroppedItems + " item(s) dropped! (you've a lot of drops, keep it! be careful of disconnected!)\r\n" :
                        numDroppedItems + " item(s) dropped!\r\n";

                    needToGrab = true;
                }
                else if (msg.Contains("cmd\":\"getDrop"))
                {
                    if (msg.Contains("bSuccess\":1"))
                    {
                        int tempItemID = getItemID(msg);
                        foreach (Item item in drops)
                        {
                            if (item.ID == tempItemID)
                            {
                                this.numDroppedItems -= item.IQty;
                                item.IQty = 0;
                                break;
                            }
                        }
                    }
                    else if (msg.Contains("bSuccess\":0"))
                    {
                        this.inBank = true;
                        message.Send = false;
                    }
                    needToGrab = true;
                }
                else if (msg.Contains("cmd\":\"equipItem") || msg.Contains("cmd\":\"unequipItem"))
                {
                    this.EquipMsg.Add(msg);
                }
                else if (msg.Contains("cmd\":\"moveToArea"))
                {
                    this.mapSessionID = getSessionID(msg);
                }
                else if (msg.Contains("cmd\":\"loadInventory"))
                {
                    this.invItemsMsg = msg;
                    isInvNeedToParse = true;
                    isInvenLoaded = true;
                }
                else if (msg.Contains("cmd\":\"loadBank"))
                {
                    this.bankItemsMsg = msg;
                    isBankNeedToParse = true;
                }
                else if (msg.Contains("iBagSlots\":"))
                {
                    this.bagSlots = int.Parse(getBetweenString(msg, "iBagSlots\":", ","));
                }
                else if (msg.Contains("%xt%loginResponse%"))
                {
                    this.UID = int.Parse(getBetweenString(msg, "%loginResponse%-1%true%", "%"));
                }
            }
            catch (Exception ex) 
            { 
                errorMsg(ex);
                tbDrop.Text += msg;
            }
        }

        public void listFromChar(string invItemsMsg)
        {
            JObject packet = JObject.Parse(invItemsMsg);

            JArray items = (JArray)packet["b"]["o"]["items"];

            for(int i = 0; i < items.Count; i++)
            {
                int id = int.Parse(items[i]["ItemID"].ToString());
                string sName = items[i]["sName"].ToString();
                int bCoins = int.Parse(items[i]["bCoins"].ToString());
                int bUpg = int.Parse(items[i]["bUpg"].ToString());
                string sType = items[i]["sType"].ToString();
                int iQty = int.Parse(items[i]["iQty"].ToString());

                string strES = items[i]["sES"].ToString();
                string sFile = _isEquipable(strES) ?
                    items[i]["sFile"].ToString() : string.Empty;
                string sLink = _isEquipable(strES) ?
                    items[i]["sLink"].ToString() : string.Empty;

                drops.Add(new Item(id, sName, bCoins, bUpg, sType, 0, string.Empty,
                    strES, sFile, sLink));
            }

            tbDrop.Text += "\r\n[Bank/Inv is Listed]" + "\r\n\r\n";
        }

        public void listDropItem(List<string> msgs)
        {
            foreach(string msg in msgs)
            {
                JObject packet = JObject.Parse(msg);

                JObject items = (JObject)packet["b"]["o"]["items"][$"{getItemID(msg)}"];

                int id = int.Parse(items["ItemID"].ToString());
                string sName = items["sName"].ToString();
                int bCoins = int.Parse(items["bCoins"].ToString());
                int bUpg = int.Parse(items["bUpg"].ToString());
                string sType = items["sType"].ToString();
                int iQty = int.Parse(items["iQty"].ToString());

                string strES = items["sES"].ToString();
                string sFile = _isEquipable(strES) ?
                    items["sFile"].ToString() : string.Empty;
                string sLink = _isEquipable(strES) ?
                    items["sLink"].ToString() : string.Empty;

                drops.Add(new Item(id, sName, bCoins, bUpg, sType, iQty, msg,
                    strES, sFile, sLink));
            }
        }

        public void updQtyList(List<string> msgs)
        {
            foreach(string msg in msgs)
            {
                int tempItemID = getItemID(msg);
                int tempIQty = getiQty(msg);

                foreach (Item drop in drops)
                {
                    if (tempItemID == drop.ID)
                    {
                        drop.IQty += tempIQty;
                        break;
                    }
                }
            }
        }

        public void updEquipment(List<string> msgs)
        {
            if (!EquipmentMsg.Any())
            {
                foreach(string msg in msgs)
                    this.EquipmentMsg.Add(msg);
                return;
            }

            foreach(string msg in msgs)
            {
                /* {"t":"xt","b":{"r":-1,"o":{"uid":3694,"ItemID":9198,["strES":"he"]
                 * ,"cmd":"equipItem","sFile":"items/helms/CrimsonHelm.swf","sLink":
                 * "CrimsonHelm","sMeta":"undefined"}}} */

                if (msg.Contains("cmd\":\"equipItem"))
                {
                    string strES_Type = getBetweenString(msg, ",", ",\"cmd\":\"equipItem");

                    for (int i = 0; i < EquipmentMsg.Count(); i++)
                    {
                        if (EquipmentMsg[i].Contains(strES_Type))
                        {
                            EquipmentMsg[i] = msg;
                            break;
                        }
                        if (i == EquipmentMsg.Count() - 1)
                        {
                            EquipmentMsg.Add(msg);
                        }
                    }
                } 
                else
                {
                    string strES_Type = getBetweenString(msg, ",", ",\"cmd\":\"unequipItem");

                    for (int i = 0; i < EquipmentMsg.Count(); i++)
                    {
                        if (EquipmentMsg[i].Contains(strES_Type))
                        {
                            EquipmentMsg.RemoveAt(i);
                            break;
                        }
                    }
                }
            }
        }

        public bool _isEquipable(string curr_sES)
        {
            string[] sES_CanEquip =
            {
                "Weapon", "ar", "co", "he", "ba", "pe"
            };

            foreach (string sES in sES_CanEquip)
            {
                if (curr_sES == sES)
                {
                    return true;
                }
            }
            return false;
        }

        public bool isListed(int id)
        {
            foreach(Item drop in drops)
            {
                if (id == drop.ID)
                    return true;
            }
            return false;
        }

        public int getSessionID(string msg)
        {
            string sID;
            if (msg.Contains("areaId\":\""))
            {
                sID = getBetweenString(msg, "areaId\":\"", "\"");
            }
            else
            {
                sID = getBetweenString(msg, "areaId\":", ",");
            }
            
            int iSID = int.Parse(sID);
            return iSID;
        }

        public static int getItemID(string msg)
        {
            string sItemID;
            if (msg.Contains("ItemID\":\""))
            {
                sItemID = getBetweenString(msg, "ItemID\":\"", "\"");
            }
            else
            {
                sItemID = getBetweenString(msg, "ItemID\":", ",");
            }
                
            int itemID = int.Parse(sItemID);
            return itemID;
        }

        public string getSName(string msg)
        {
            return getBetweenString(msg, "sName\":\"", "\"");
        }

        public int getBCoins(string msg)
        {
            string sBCoins;
            if (msg.Contains("bCoins\":\""))
            {
                sBCoins = getBetweenString(msg, "bCoins\":\"", "\"");
            }
            else
            {
                sBCoins = getBetweenString(msg, "bCoins\":", ",");
            }
            int bCoins = int.Parse(sBCoins);
            return bCoins;
        }

        public int getBUpg(string msg)
        {
            string sBUpg;
            if (msg.Contains("bUpg\":\""))
            {
                sBUpg = getBetweenString(msg, "bUpg\":\"", "\"");
            }
            else
            {
                sBUpg = getBetweenString(msg, "bUpg\":", ",");
            }
            int bUpg = int.Parse(sBUpg);
            return bUpg;
        }

        public string getSType(string msg)
        {
            return getBetweenString(msg, "sType\":\"", "\"");
        }

        public int getiQty(string msg)
        {
            string siQty;
            if (msg.Contains("sDesc"))
            {
                siQty = getBetweenString(msg, "iQty\":", ",");
            }
            else
            {
                siQty = getBetweenString(msg, "iQty\":", "}");
            }
            int iQty = int.Parse(siQty);
            return iQty;
        }

        public static string getBetweenString(string strSource, string strStart, string strEnd)
        {
            if (strSource.Contains(strStart) && strSource.Contains(strEnd))
            {
                int Start, End;
                int IndexStart = 0;

                Start = strSource.IndexOf(strStart, IndexStart) + strStart.Length;
                End = strSource.IndexOf(strEnd, Start);
                IndexStart = Start;

                return strSource.Substring(Start, End - Start);
            }
            return null;
        }

        // grabDrops
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            grabTreeDrops();
        }

        // Reset SWF
        private void btnResetSWF_Click(object sender, EventArgs e)
        {
            if (EquipmentMsg.Any())
            {
                btnResetSWF.Enabled = false;
                foreach (string msg in EquipmentMsg)
                {
                    Proxy.Instance.SendToClient(msg);
                }
                btnResetSWF.Enabled = true;
            }
        }

        // making treenode base on drops.IQty >= 1
        public void grabTreeDrops()
        {
            try
            {
                Point ScrollPosTree = GetTreeViewScrollPos(tvDropMain);
                Point ScrollPosPool = GetTreeViewScrollPos(tvDropPool);

                tvDropMain.Nodes.Clear();
                tvDropPool.Nodes.Clear();
                int index = 0;
                int indexPool = 0;

                foreach (Item drop in drops)
                {
                    if (drop.IQty != 0)
                    {
                        TreeNode idNode = new TreeNode($"ID: {drop.ID}");
                        TreeNode sNameNode = new TreeNode($"{drop.SName}");
                        TreeNode typeNode = new TreeNode($"Type: {drop.SType}");
                        TreeNode bCoinsNode = new TreeNode(drop.BCoins == 1 ? $"AC: True" : $"AC: False");
                        TreeNode bUpgNode = new TreeNode(drop.BUpg == 1 ? $"Legend: True" : $"Legend: False");
                        TreeNode iQtyNode = new TreeNode($"Quantity: {drop.IQty}");

                        TreeNode mainNode = new TreeNode($"{drop.SName} x{drop.IQty}", new TreeNode[] {
                            idNode,
                            sNameNode,
                            typeNode,
                            bCoinsNode,
                            bUpgNode,
                            iQtyNode,
                        });
                        mainNode.Name = $"{drop.ID}";

                        if (!drop.IsRejected)
                        {
                            mainNode.ContextMenuStrip = drop.isEquipable() ?
                                contextMenuStripMainEquip : contextMenuStripMain;
                            tvDropMain.Nodes.Add(mainNode);

                            //setup node style
                            if (drop.BCoins == 1)
                            {
                                tvDropMain.Nodes[index].ImageIndex = 1;
                                tvDropMain.Nodes[index].SelectedImageIndex = 1;
                            }
                            else
                            {
                                tvDropMain.Nodes[index].ImageIndex = 2;
                                tvDropMain.Nodes[index].SelectedImageIndex = 2;
                            }

                            if (drop.BUpg == 1)
                            {
                                tvDropMain.Nodes[index].ForeColor = System.Drawing.Color.Magenta;
                            }

                            index++;
                        }
                        else
                        {
                            mainNode.ContextMenuStrip = contextMenuStripPool;
                            tvDropPool.Nodes.Add(mainNode);

                            //setup node style
                            if (drop.BCoins == 1)
                            {
                                tvDropPool.Nodes[indexPool].ImageIndex = 1;
                                tvDropPool.Nodes[indexPool].SelectedImageIndex = 1;
                            }
                            else
                            {
                                tvDropPool.Nodes[indexPool].ImageIndex = 2;
                                tvDropPool.Nodes[indexPool].SelectedImageIndex = 2;
                            }

                            if (drop.BUpg == 1)
                            {
                                tvDropPool.Nodes[indexPool].ForeColor = System.Drawing.Color.Magenta;
                            }

                            indexPool++;
                        }
                    }
                }

                /* Making the last selected node be selected 
                when treeview gets refreshed. */
                if (tempSelectedNode != null)
                {
                    string currTnName = tempSelectedNode.Name;

                    if (tvDropMain.Nodes != null && tvDropMain.Nodes.ContainsKey(currTnName))
                    {
                        tvDropMain.SelectedNode = tvDropMain.Nodes[currTnName];
                    }
                    else if(tvDropPool.Nodes != null && tvDropPool.Nodes.ContainsKey(currTnName))
                    {
                        tvDropPool.SelectedNode = tvDropPool.Nodes[currTnName];
                    }
                }

                SetTreeViewScrollPos(tvDropMain, ScrollPosTree);
                SetTreeViewScrollPos(tvDropPool, ScrollPosPool);
            }
            catch (Exception ex) { errorMsg(ex); }

        }

        /* TreeView mouse-click handler
         * LClick: make any node selected
         * RClick: make any node selected & show their ContextMenuStrip
         */
        private void tv_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            try
            {
                if (e.Button == MouseButtons.Right && e.Node != null)
                {
                    if (tvDropMain.Nodes.Contains(e.Node))
                    {
                        tempSelectedNode = e.Node;
                        tvDropMain.SelectedNode = e.Node;
                        tvDropMain.SelectedNode.ContextMenuStrip.Show(Cursor.Position);
                        //tbDrop.Text += "**Main RClicked" + "\r\n";
                    } 
                    else if (tvDropPool.Nodes.Contains(e.Node))
                    {
                        tempSelectedNode = e.Node;
                        tvDropPool.SelectedNode = e.Node;
                        tvDropPool.SelectedNode.ContextMenuStrip.Show(Cursor.Position);
                        //tbDrop.Text += "**Pool RClicked" + "\r\n";
                    }
                } 
                else if (e.Button == MouseButtons.Left && e.Node != null)
                {
                    if (tvDropMain.Nodes.Contains(e.Node))
                    {
                        tempSelectedNode = e.Node;
                        tvDropMain.SelectedNode = e.Node;
                        //tbDrop.Text += "**Main LClicked" + "\r\n";
                    }
                    else if (tvDropPool.Nodes.Contains(e.Node))
                    {
                        tempSelectedNode = e.Node;
                        tvDropPool.SelectedNode = e.Node;
                        //tbDrop.Text += "**Pool LClicked" + "\r\n";
                    }
                }
            }
            catch (Exception ex) { errorMsg(ex); }
        }

        private bool isInvFull()
        {
            if(isInvenLoaded ? (Player.Inventory.Items.Count < bagSlots) : false)
            {
                return false;
            } 
            return true;
        }

        private void invFullMsgBox()
        {
            MessageBoxEx.Show(this, "Inventory is full.", "Oops");
        }

        private void inBankMsgBox()
        {
            MessageBoxEx.Show(this, "Item already exists in your bank.\r\n" +
                "(or) already max-stacked in your inv!", "Oops");
        }

        // Control StripMenuItem for main treeview
        private void keepToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bool isItemInInv = Player.Inventory.ContainsItem(tempSelectedNode.Nodes[1].Text, "1");
            if (isInvFull() && !isItemInInv)
            {
                invFullMsgBox();
                return;
            }

            foreach (Item drop in drops)
            {
                try
                {
                    int tempID = int.Parse(tempSelectedNode.Name);
                    if (drop.ID == tempID)
                    {
                        if(drop.FirstDropMsg != null)
                        {
                            Proxy.Instance.SendToClient(drop.FirstDropMsg);
                            drop.FirstDropMsg = string.Empty;
                        }
                        Proxy.Instance.SendToServer($"%xt%zm%getDrop%{this.mapSessionID}%{drop.ID}%");
                        tvDropMain.SelectedNode.ForeColor = System.Drawing.SystemColors.GrayText;
                        tvDropMain.SelectedNode.ContextMenuStrip = null;
                        tvDropPool.Enabled = false;
                        tvDropMain.Enabled = false;
                        break;
                    }
                }
                catch (Exception ex) { errorMsg(ex); }
            }
        }

        private void rejectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Item drop in drops)
            {
                try
                {
                    int tempID = int.Parse(tempSelectedNode.Name);
                    if (drop.ID == tempID)
                    {
                        drop.IsRejected = true;
                        needToGrab = true;
                        tvDropMain.SelectedNode = null;
                        //tbDrop.Text += "to Pool" + "\r\n";
                        break;
                    }
                }
                catch (Exception ex) { errorMsg(ex); }
            }
        }

        // Control StripMenuItem for pool treeview
        private void keepToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            bool isItemInInv = Player.Inventory.ContainsItem(tempSelectedNode.Nodes[1].Text, "1");
            if (isInvFull() && !isItemInInv)
            {
                invFullMsgBox();
                return;
            }

            foreach (Item drop in drops)
            {
                try
                {
                    int tempID = int.Parse(tempSelectedNode.Name);
                    if (drop.ID == tempID)
                    {
                        if (drop.FirstDropMsg != null)
                        {
                            Proxy.Instance.SendToClient(drop.FirstDropMsg);
                            drop.FirstDropMsg = string.Empty;
                        }
                        Proxy.Instance.SendToServer($"%xt%zm%getDrop%{this.mapSessionID}%{drop.ID}%");
                        tvDropPool.SelectedNode.ForeColor = System.Drawing.SystemColors.GrayText;
                        tvDropPool.SelectedNode.ContextMenuStrip = null;
                        tvDropPool.Enabled = false;
                        tvDropMain.Enabled = false;
                        break;
                    }
                }
                catch (Exception ex) { errorMsg(ex); }
            }
        }

        private void restoreToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Item drop in drops)
            {
                try
                {
                    int tempID = int.Parse(tempSelectedNode.Name);
                    if (drop.ID == tempID)
                    {
                        drop.IsRejected = false;
                        needToGrab = true;
                        tvDropPool.SelectedNode = null;
                        //tbDrop.Text += "to Main" + "\r\n";
                        break;
                    }
                }
                catch (Exception ex) { errorMsg(ex); }
            }
        }

        /* Making sure tbDrop always scrolled to the bottom/last added text. */
        private void tbDrop_TextChanged(object sender, EventArgs e)
        {
            tbDrop.SelectionStart = tbDrop.Text.Length;
            tbDrop.ScrollToCaret();
        }

        /* tnCount: count treenode of each treeview
         * tnCount(0): count treenode of main treeview
         * tnCount(1): count treenode of pool treeview
         */
        private int tnCount(int i)
        {
            if(i == 0)
            {
                return tvDropMain.Nodes.Count;
            }
            else if(i == 1)
            {
                return tvDropPool.Nodes.Count;
            }
            return 0;
        }

        public void startStateUI()
        {
            cbEnable.Enabled = false;
            tbDrop.Enabled = true;
            tvDropPool.Enabled = true;
            tvDropMain.Enabled = true;
            btnRefresh.Enabled = true;
            btnResetSWF.Enabled = true;
        }

        public void stopStateUI()
        {
            cbEnable.Enabled = true;
            tbDrop.Text = null;
            tbDrop.Enabled = false;
            tvDropPool.Enabled = false;
            tvDropMain.Enabled = false;
            btnRefresh.Enabled = false;
            btnResetSWF.Enabled = false;
        }

        /* Hiding Pool/Logs and making the form shrink */
        int temptbDropWidth;
        private void cbHideUI_CheckedChanged(object sender, EventArgs e)
        {
            if (cbHideUI.Checked)
            {
                temptbDropWidth = this.ClientSize.Width;
                this.ClientSize = new System.Drawing.Size(tbDrop.Location.X + tvDropMain.Location.X + 5, ClientSize.Height);
                this.FormBorderStyle = FormBorderStyle.Sizable;
                this.MaximumSize = new System.Drawing.Size(tbDrop.Location.X + tvDropMain.Location.X + 5, Int32.MaxValue);
                this.MinimumSize = new System.Drawing.Size(tbDrop.Location.X + tvDropMain.Location.X + 5, tvDropMain.Location.Y);
                tbDrop.Visible = false;
                tvDropPool.Visible = false;
                lbStringLogs.Visible = false;
                lbDropPool.Visible = false;
                //cbAutoAtt.Visible = false;
                //tbSkill.Visible = false;
                //linklbReportBug.Visible = false;
                //cbDisableAnim.Visible = false;
                //cbHidePlayer.Visible = false;
                //cbLagKiller.Visible = false;
                linklbReportBug.Visible = false;
                cbWalkSpeed.Visible = false;
                numWalkSpeed.Visible = false;
                cbSkipCutscene.Visible = false;
            }
            else
            {
                this.MaximumSize = new System.Drawing.Size(Int32.MaxValue, Int32.MaxValue);
                this.MinimumSize = new System.Drawing.Size(510, 0);
                this.ClientSize = new System.Drawing.Size(temptbDropWidth, ClientSize.Height);
                this.FormBorderStyle = FormBorderStyle.Sizable;
                tbDrop.Visible = true;
                tvDropPool.Visible = true;
                lbStringLogs.Visible = true;
                lbDropPool.Visible = true;
                //cbAutoAtt.Visible = true;
                //tbSkill.Visible = true;
                //linklbReportBug.Visible = true;
                //cbDisableAnim.Visible = true;
                //cbHidePlayer.Visible = true;
                //cbLagKiller.Visible = true;
                linklbReportBug.Visible = true;
                cbWalkSpeed.Visible = true;
                numWalkSpeed.Visible = true;
                cbSkipCutscene.Visible = true;
            }
        }

        private void linkLbReportBug_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                // Change the color of the link text by setting LinkVisited
                // to true.
                // linklbReportBug.LinkVisited = true;

                //Call the Process.Start method to open the default browser
                //with a URL:
                System.Diagnostics.Process.Start("http://www.fb.com/afif.septian.35");
            }
            catch
            {
                MessageBox.Show(this, "Unable to open link that was clicked.");
            }
        }

        private void equipSWFToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int itemID = int.Parse(tempSelectedNode.Name);

            foreach(Item drop in drops)
            {
                if(itemID == drop.ID)
                {
                    Proxy.Instance.SendToClient("{\"t\":\"xt\",\"b\":{\"r\":-1,\"o\":{\"uid\":" + this.UID + ",\"ItemID\":" + drop.ID + "," +
                        "\"strES\":\"" + drop.StrES + "\",\"cmd\":\"equipItem\",\"sFile\":\"" + drop.SFile + "\"," +
                        "\"sLink\":\"" + drop.SLink + "\"}}}");
                    return;
                }
            }
        }

        private void openOnWikiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                string iName = tempSelectedNode.Nodes[1].Text;
                Regex reg = new Regex(@"\W");
                string urlName = reg.Replace(iName, "-").ToLower();
                System.Diagnostics.Process.Start("http://aqwwiki.wikidot.com/" + urlName);
            }
            catch (Exception ex) { errorMsg(ex); }
        }

        private void searchOnWikiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                string iName = tempSelectedNode.Nodes[1].Text;
                System.Diagnostics.Process.Start("http://aqwwiki.wikidot.com/search:site/q/" + iName);
            }
            catch (Exception ex) { errorMsg(ex); }
        }

        private async void cbAutoAtt_CheckedChanged(object sender, EventArgs e)
        {
            if (cbAutoAtt.Checked)
            {
                tbSkill.Enabled = false;
                string[] skillList = tbSkill.Text.Split(';');
                int skillIndex = 0;

                while (Player.IsLoggedIn && cbAutoAtt.Checked)
                {
                    if (!Player.HasTarget)
                        Player.AttackMonster("*");

                    Player.UseSkill(skillList[skillIndex]);
                    skillIndex++;

                    if (skillIndex == skillList.Length)
                        skillIndex = 0;

                    await Task.Delay(500);
                }

                cbAutoAtt.Checked = false;
            }
            else
            {
                tbSkill.Enabled = true;
            }
        }

        private void errorMsg(Exception ex)
        {
            tbDrop.Text = string.Empty;
            string erMsg = ex + " < Bugs!!, Tell me about these logs! (Click on: ReportBug?) " +
                "-- and -- Click Refresh for a Quick Fix!";
            tbDrop.Text += erMsg;
        }

        private void Main_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = true;
                Hide();
            }
        }

        private void Main_Load(object sender, EventArgs e)
        {
            stopStateUI();
        }

        /* All the code below is only to maintain 
         * the scroll position of each tree when it gets refreshed */

        [DllImport("user32.dll", CharSet = CharSet.Unicode)]
        public static extern int GetScrollPos(IntPtr hWnd, int nBar);

        [DllImport("user32.dll", CharSet = CharSet.Unicode)]
        public static extern int SetScrollPos(IntPtr hWnd, int nBar, int nPos, bool bRedraw);

        private const int SB_HORZ = 0x0;
        private const int SB_VERT = 0x1;

        private Point GetTreeViewScrollPos(TreeView treeView)
        {
            return new Point(
                GetScrollPos(treeView.Handle, SB_HORZ),
                GetScrollPos(treeView.Handle, SB_VERT));
        }

        private void SetTreeViewScrollPos(TreeView treeView, Point scrollPosition)
        {
            SetScrollPos(treeView.Handle, SB_HORZ, scrollPosition.X, true);
            SetScrollPos(treeView.Handle, SB_VERT, scrollPosition.Y, true);
        }

        /* Misc. bot manager options */

        public HandlerHidePlayer HideHandler { get; } = new HandlerHidePlayer();

        public HandlerDisableAnims AnimsHandler { get; } = new HandlerDisableAnims();

        public HandlerSkills HandlerRange { get; } = new HandlerSkills();

        private void cbHidePlayer_CheckedChanged(object sender, EventArgs e)
        {
            if (cbHidePlayer.Checked)
            {
                Proxy.Instance.RegisterHandler(HideHandler);
                Grimoire.Tools.Flash.Call("DestroyPlayers");
            }
            else
            {
                Proxy.Instance.UnregisterHandler(HideHandler);
            }
        }

        private void cbDisableAnim_CheckedChanged(object sender, EventArgs e)
        {
            if (cbDisableAnim.Checked)
            {
                Proxy.Instance.RegisterHandler(AnimsHandler);
            }
            else
            {
                Proxy.Instance.UnregisterHandler(AnimsHandler);
            }
        }

        private void cbLagKiller_CheckedChanged(object sender, EventArgs e)
        {
            if (cbLagKiller.Checked)
            {
                Grimoire.Tools.Flash.Call("SetLagKiller", bool.TrueString);
            }
            else
            {
                Grimoire.Tools.Flash.Call("SetLagKiller", bool.FalseString);
            }
        }

        private void cbInfiniteRange_CheckedChanged(object sender, EventArgs e)
        {
            if(cbInfiniteRange.Checked)
            {
                Proxy.Instance.RegisterHandler(HandlerRange);
                Grimoire.Tools.Flash.Call("SetInfiniteRange");
            }
            else
            {
                Proxy.Instance.UnregisterHandler(HandlerRange);
            }
        }

        private async void cbProvokeMons_CheckedChanged(object sender, EventArgs e)
        {
            while (cbProvokeMons.Checked)
            {
                Grimoire.Tools.Flash.Call("SetProvokeMonsters");
                await Task.Delay(1000);
            }
        }

        private async void cbWalkSpeed_CheckedChangedAsync(object sender, EventArgs e)
        {
            while (cbWalkSpeed.Checked)
            {
                Grimoire.Tools.Flash.Call("SetWalkSpeed", numWalkSpeed.Value.ToString());
                await Task.Delay(1000);
            }

            if(!cbWalkSpeed.Checked)
            {
                Grimoire.Tools.Flash.Call("SetWalkSpeed", "8");
            }
        }

        private void numWalkSpeed_ValueChanged(object sender, EventArgs e)
        {
            if(cbWalkSpeed.Checked)
            {
                Grimoire.Tools.Flash.Call("SetWalkSpeed", numWalkSpeed.Value.ToString());
            }
        }

        private async void cbSkipCutscene_CheckedChanged(object sender, EventArgs e)
        {
            while(cbSkipCutscene.Checked)
            {
                Grimoire.Tools.Flash.Call("SetSkipCutscenes");
                await Task.Delay(1000);
            }
        }
    }
}
