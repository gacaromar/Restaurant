using Restaurant.DataClass;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Restaurant.Forms
{
    public partial class CreateForm : Form
    {
        public CreateForm()
        {
            InitializeComponent();
        }

        private void btnSaveTable_Click(object sender, EventArgs e)
        {
            if (tbTableName.Text.Replace(" ","") !=string.Empty)
            {
                Table table = new Table()
                {
                    Name = tbTableName.Text.Replace(" ", "")
                };
                table.Save();
                MessageBox.Show("Masa ekleme işleminiz gerçekleştirilmiştir.", "Bilgilendirme",MessageBoxButtons.OK,MessageBoxIcon.Information);
                LoadTables();
            }
            else
            {
                MessageBox.Show("Lütfen masa adı giriniz", "Dikkat", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadTables()
        {
            List<Table> list = Table.GetAllTables();
            dtTable.DataSource = list;
            
        }
    }
}
