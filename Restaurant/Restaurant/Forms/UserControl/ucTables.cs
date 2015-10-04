using System;
using System.Collections.Generic;
using Restaurant.DataClass;

namespace Restaurant.Forms.UserControl
{
    public partial class ucTables : System.Windows.Forms.UserControl
    {
        public ucTables()
        {
            InitializeComponent();
        }

        public bool AddTable(List<Table> pSource, EventHandler tblClick)
        {
            int row = -1;
            for (int i = 0, j = 0; i < pSource.Count; i++, j++)
            {
                var tbl = new ucTable();
                tbl.TableActive = pSource[i].Active;
                tbl.TableID = pSource[i].Id;
                tbl.TableName = pSource[i].TableName;
                tbl.lblTableName.Text = pSource[i].TableName;
                tbl.pbPicture.Image = pSource[i].Active ? Properties.Resources.ActiveTable : Properties.Resources.PassiveTable;
                tbl.pbPicture.Click += tblClick;
                if (i % 10 == 0)
                {
                    j = 0; row++;
                }
                tbl.Left = 10 + (120 * j);
                tbl.Top = 30 + 122 * row;
                this.Controls.Add(tbl);
            }
            return true;
        }
    }
}
