using System;
using System.Collections.Generic;
using Restaurant.DataClass;
using Restaurant.Forms.UserControl.Compotents;

namespace Restaurant.Forms.UserControl
{
    public partial class ucProducts : System.Windows.Forms.UserControl
    {

        public ucProducts()
        {
            InitializeComponent();
        }
        public bool SetGroups(List<Product> pSource, EventHandler btnProductClick)
        {
            int row = -1;
            for (int i = 0, j = 0; i < pSource.Count; i++, j++)
            {
                var tbl = new ucProductGroup();
                tbl.Product = pSource[i];
                tbl.Text = pSource[i].ProductNameSalesPrice;
                tbl.btnGroupName.Click += btnProductClick;
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
