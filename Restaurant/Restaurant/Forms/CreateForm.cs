using Restaurant.DataClass;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Restaurant.Forms
{
    public partial class CreateForm : Form
    {
        public CreateForm()
        {
            InitializeComponent();
            LoadTables();
        }
        List<Table> list;
        private void btnSaveTable_Click(object sender, EventArgs e)
        {
            if (tbTableName.Text.Replace(" ", "") != string.Empty)
            {
                Table table = new Table()
                {
                    TableName = tbTableName.Text.Replace(" ", "")
                };
                bool result = table.Save();
                if (result)
                    MessageBox.Show("Masa ekleme işleminiz gerçekleştirilmiştir.", "Bilgilendirme", MessageBoxButtons.OK, MessageBoxIcon.Information);
                else
                    MessageBox.Show("İşlemde hata gerçekleşti.", "Dikkat", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LoadTables();

                tbTableName.Text = string.Empty;
            }
            else
            {
                MessageBox.Show("Lütfen masa adı giriniz", "Dikkat", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadTables()
        {
             list = Table.GetAllTables();
            dtTables.DataSource = list;
            dtTables.Columns[1].HeaderText = "Masa Adı";
            

        }

        private void dtTables_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            string value = dtTables.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();
            int Id = Convert.ToInt32(dtTables.Rows[e.RowIndex].Cells[0].Value);
            DialogResult dialogResult = MessageBox.Show("Güncellemek istediğinize emin misiniz ? ", "Dikkat", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialogResult == System.Windows.Forms.DialogResult.Yes)
            {
                Table t = new Table()
                {
                    Id = Id,
                    TableName = value
                };
                t.Update();
                MessageBox.Show("Masa güncelleme işleminiz gerçekleştirilmiştir.", "Bilgilendirme", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                LoadTables();
            }

        }

        private void dtTables_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 46)
            {
                DialogResult dialogResult = MessageBox.Show("Silmek istediğinize emin misiniz ? ", "Dikkat", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dialogResult == System.Windows.Forms.DialogResult.Yes)
                {
                    int Id = Convert.ToInt32(dtTables.SelectedRows[0].Cells[0].Value);
                    Table t = new Table()
                    {
                        Id = Id
                    };
                    t.Delete();
                }
                LoadTables();
            }

        }

        private void tbTableName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
            {
                if (tbTableName.Text.Replace(" ", "") != string.Empty)
                {
                    Table table = new Table()
                    {
                        TableName = tbTableName.Text.Replace(" ", "")
                    };
                    bool result = table.Save();
                    if (result)
                        MessageBox.Show("Masa ekleme işleminiz gerçekleştirilmiştir.", "Bilgilendirme", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    else
                        MessageBox.Show("İşlemde hata gerçekleşti.", "Dikkat", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    LoadTables();

                    tbTableName.Text = string.Empty;
                }
                else
                {
                    MessageBox.Show("Lütfen masa adı giriniz", "Dikkat", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
