using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Restaurant.DataClass;
using Restaurant.Forms.UserControl.Compotents;

namespace Restaurant.Forms.UserControl
{
    public partial class ucSaleSlip : System.Windows.Forms.UserControl
    {
        public ucSaleSlip()
        {
            InitializeComponent();
            var vGroups = ProductGroup.GetAllProductGroups();
            var ucProductGroups = new ucProductGroups();
            ucProductGroups.SetGroups(vGroups, GroupClick);
            pnlGroups.Controls.Add(ucProductGroups);
        }

        private void GroupClick(object sender, EventArgs e)
        {
            if (sender == null) return;
            var vGroupId = ((sender as Button).Parent as ucProductGroup).GroupID;

        }
        private void btnIncrement_Click(object sender, EventArgs e)
        {

        }
    }
}
