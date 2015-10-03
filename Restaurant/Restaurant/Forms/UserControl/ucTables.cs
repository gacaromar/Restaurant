using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Restaurant.DataClass;

namespace Restaurant.Forms.UserControl
{
    public partial class ucTables : System.Windows.Forms.UserControl
    {
        public ucTables()
        {
            InitializeComponent();
        }

        public bool AddTable(List<Table> pSource)
        {
            for (int i = 0; i < pSource.Count; i++)
            {
                var tbl = new ucTable();
                tbl.lblTableName.Text = pSource[i].Name;
                tbl.pbPicture.Image =
                    Image.FromFile(pSource[i].Active ? "~/Images/ActiveTable.png" : "~/Images/PassiveTable.png");
                tbl.Left = 10 + (94 * i);
                if (i % 5 == 0)
                    tbl.Height = 122 * ((i + 1) * (int)(i / 5));
            }
            return true;
        }
    }
}
