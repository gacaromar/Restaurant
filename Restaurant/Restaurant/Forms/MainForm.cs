using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Restaurant.DataClass;
using Restaurant.Forms.UserControl;

namespace Restaurant.Forms
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            var tbl = new ucTables();
            tbl.Dock = DockStyle.Fill;
            var vList = new List<Table>();
            vList.Add(new Table
            {
                Active = true,
                Name = "1",
                Id = 1
            });
            vList.Add(new Table
            {
                Active = false,
                Name = "2",
                Id = 2
            }); vList.Add(new Table
             {
                 Active = true,
                 Name = "1",
                 Id = 1
             });
            vList.Add(new Table
            {
                Active = false,
                Name = "2",
                Id = 2
            }); vList.Add(new Table
             {
                 Active = true,
                 Name = "1",
                 Id = 1
             });
            vList.Add(new Table
            {
                Active = false,
                Name = "2",
                Id = 2
            }); vList.Add(new Table
             {
                 Active = true,
                 Name = "1",
                 Id = 1
             });
            vList.Add(new Table
            {
                Active = false,
                Name = "2",
                Id = 2
            });
            vList.Add(new Table
            {
                Active = true,
                Name = "3",
                Id = 3
            });
            vList.Add(new Table
            {
                Active = true,
                Name = "1",
                Id = 1
            });
            vList.Add(new Table
            {
                Active = false,
                Name = "2",
                Id = 2
            });
            vList.Add(new Table
            {
                Active = true,
                Name = "3",
                Id = 3
            });
            vList.Add(new Table
            {
                Active = true,
                Name = "1",
                Id = 1
            });
            vList.Add(new Table
            {
                Active = false,
                Name = "2",
                Id = 2
            });
            vList.Add(new Table
            {
                Active = true,
                Name = "3",
                Id = 3
            });
            tbl.AddTable(vList, tbl_Click);
            tabPage1.Controls.Add(tbl);
        }

        void tbl_Click(object sender, EventArgs e)
        {
            if (sender == null)
            {
                MessageBox.Show("Lütfen Masa Seçiniz", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            var vucTable = ((sender as PictureBox).Parent as ucTable);
            var vTable = new Table
            {
                Active = vucTable.TableActive,
                Name = vucTable.TableName,
                Id = vucTable.TableID
            };
            SetAdisyon(vTable);
            tabControl1.SelectedIndex = 1;
        }

        private void SetAdisyon(Table vTable)
        {
            throw new NotImplementedException();
        }
    }
}
