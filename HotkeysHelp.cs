using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ExamplePacketPlugin
{
    public partial class HotkeysHelp : Form
    {
        public HotkeysHelp()
        {
            InitializeComponent();
            this.FormClosing += (sender, e) => {
                this.Hide();
                e.Cancel = true;
            };
            this.VisibleChanged += (sender, e) =>
            {
                if (Owner != null && this.Visible)
                    Location = new Point(Owner.Location.X + Owner.Width / 2 - Width / 2,
                        Owner.Location.Y + Owner.Height / 2 - Height / 2);
            };
        }
    }
}
