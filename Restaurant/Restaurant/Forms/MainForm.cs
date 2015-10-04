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
                TableName = "1",
                Id = 1
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
                TableName = vucTable.TableName,
                Id = vucTable.TableID
            };
            SetAdisyon(vTable);
            tabControl1.SelectedIndex = 1;
        }

        private void SetAdisyon(Table vTable)
        {
            var ucSlips = new ucSaleSlip();
            tabPage2.Controls.Add(ucSlips);
            tabControl1.SelectedIndex = 1;
        }

        private void kayıtlarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CreateForm frmCreateForm = new CreateForm();
            frmCreateForm.ShowDialog();
        }
    }
}
