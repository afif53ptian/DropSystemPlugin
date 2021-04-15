using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamplePacketPlugin
{
    class Item
    {
        private int id;
        private string sName;
        private int bCoins;
        private int bUpg;
        private string sType;
        private int iQty;
        private bool isRejected = false;
        private string firstDropMsg;

        private string strES;
        private string sFile;
        private string sLink;

        public Item(int id, string sName, int bCoins, int bUpg, string sType, int iQty, string firstDropMsg,
            string strES, string sFile, string sLink)
        {
            this.id = id;
            this.sName = sName;
            this.bCoins = bCoins;
            this.bUpg = bUpg;
            this.sType = sType;
            this.iQty = iQty;
            this.firstDropMsg = firstDropMsg;

            this.strES = strES;
            this.sFile = sFile;
            this.sLink = sLink;
        }

        public int ID { get => id; set => id = value; }
        public string SName { get => sName; set => sName = value; }
        public int BCoins { get => bCoins; set => bCoins = value; }
        public int BUpg { get => bUpg; set => bUpg = value; }
        public string SType { get => sType; set => sType = value; }
        public int IQty { get => iQty; set => iQty = value; }
        public bool IsRejected { get => isRejected; set => isRejected = value; }
        public string FirstDropMsg { get => firstDropMsg; set => firstDropMsg = value; }
        public string StrES { get => strES; set => strES = value; }
        public string SFile { get => sFile; set => sFile = value; }
        public string SLink { get => sLink; set => sLink = value; }

        public bool isEquipable()
        {
            string[] sES_CanEquip =
            {
                "Weapon", "ar", "co", "he", "ba", "pe"
            };

            foreach(string sES in sES_CanEquip)
            {
                if(this.strES == sES)
                {
                    return true;
                }
            }
            return false;
        }
        public string toString()
        {
            return $"{this.id}, {this.sName}, {this.sType}, AC:{this.bCoins}, Upg:{this.bUpg}, Qty:{this.iQty}";
        }
    }
}
