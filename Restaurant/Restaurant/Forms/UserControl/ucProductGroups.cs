using System;
using System.Collections.Generic;
using Restaurant.DataClass;
using Restaurant.Forms.UserControl.Compotents;

namespace Restaurant.Forms.UserControl
{
    public partial class ucProductGroups : System.Windows.Forms.UserControl
    {
        public ucProductGroups()
        {
            InitializeComponent();
        }

        public bool SetGroups(List<ProductGroup> pSource, EventHandler btnProductGroupClick)
        {
            int row = -1;
            for (int i = 0, j = 0; i < pSource.Count; i++, j++)
            {
                var tbl = new ucProductGroup();
                tbl.ProductGroup = pSource[i];
                tbl.Text = pSource[i].ProductGroupName;
                tbl.btnGroupName.Click += btnProductGroupClick;
                tbl.Width = 85;
                tbl.Height = 35;
                if (i % 5 == 0)
                {
                    j = 0; row++;
                }
                tbl.Left = 5 + (85 * j);
                tbl.Top = 12 + 35 * row;
                this.Controls.Add(tbl);
            }
            return true;
        }
    }
}
