using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Restaurant.DataClass;
using Restaurant.Forms.UserControl;
using Restaurant.Helper;
using System.Threading;

namespace Restaurant.Forms
{
    public partial class MainForm : Form
    {
        Table vTable;
        public MainForm()
        {
            InitializeComponent();
            LoadTables();
        }

        private void LoadTables()
        {
            var tbl = new ucTables();
            tbl.Dock = DockStyle.Fill;
            var vList = Table.GetAllTables();
            tbl.AddTable(vList, tbl_Click);
            tabPage1.Controls.Clear();
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
             vTable = new Table
            {
                Active = vucTable.TableActive,
                TableName = vucTable.TableName,
                Id = vucTable.TableID
            };
           //SetAdisyon(vTable);
            tabControl1.SelectedIndex = 1;
            
        }


        private void SetAdisyon(Table vTable)
        {
            var ucSlips = new ucSaleSlip(vTable);
            tabPage2.Controls.Clear();
            tabPage2.Controls.Add(ucSlips);
            //tabControl1.SelectedIndex = 1;
        }

        private void kayıtlarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CreateForm frmCreateForm = new CreateForm();
            frmCreateForm.ShowDialog();
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (tabControl1.SelectedIndex)
            {
                case 0:
                    LoadTables();
                    break;
                case 1:
                    SetAdisyon(vTable);
                    break;


                default:
                    break;
            }
        }
    }
}
