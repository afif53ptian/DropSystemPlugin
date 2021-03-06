using System;
using System.Windows.Forms;
using Grimoire.Networking;
using Grimoire.Tools.Plugins;

namespace ExamplePacketPlugin
{
    [GrimoirePluginEntry]
    public class Loader : IGrimoirePlugin
    {
        public string Author => "Afif_Sapi";

        public string Description => "AQLite-like drop system tool.";

        private ToolStripItem menuItem;

        public void Load()
        {
            // Add an item to the main menu in Grimoire.
            menuItem = Grimoire.UI.Root.Instance.MenuMain.Items.Add("Drops");
            menuItem.Click += MenuStripItem_Click;
        }

        public void Unload() // In this method you need to clean everything up
        {
            //Proxy.Instance.UnregisterHandler(Main.Instance.Handler);
            Main.Instance.cbEnable.Checked = false;
            Proxy.Instance.UnregisterHandler(Main.Instance.HideHandler);
            Proxy.Instance.UnregisterHandler(Main.Instance.AnimsHandler);
            Proxy.Instance.UnregisterHandler(Main.Instance.HandlerRange);
            Proxy.Instance.ReceivedFromServer -= Main.Instance.MapHandler;
            Proxy.Instance.ReceivedFromClient -= Main.Instance.MapHandler;
            menuItem.Click -= MenuStripItem_Click;
            Grimoire.UI.Root.Instance.MenuMain.Items.Remove(menuItem);
            Main.Instance.Close();
            Main.Instance.stopStateUI();
            Main.Instance.cbAutoAtt.Checked = false;
            Main.Instance.Dispose();
        }

        private void MenuStripItem_Click(object sender, EventArgs e)
        {
            if (Main.Instance.Visible)
            {
                Main.Instance.Hide();
            }
            else
            {
                Main.Instance.Show();
                Main.Instance.BringToFront();
            }
        }
    }
}
