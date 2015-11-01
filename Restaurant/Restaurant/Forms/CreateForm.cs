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
            cmbCurrency.SelectedIndex = 0;
        }
        List<Table> list;
        List<ProductGroup> listProductGroup;
        List<Product> ListProduct;

        #region SaveEvents

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

        private void btnSaveProductGroup_Click(object sender, EventArgs e)
        {
            if (tbProductGroup.Text.Replace(" ", "") != string.Empty)
            {
                ProductGroup productGrup = new ProductGroup()
                {
                    ProductGroupName = tbProductGroup.Text.Replace(" ", "")
                };
                bool result = productGrup.Save();
                if (result)
                    MessageBox.Show("ürün grubu eklem işleminiz gerçekleştirilmiştir.", "Bilgilendirme", MessageBoxButtons.OK, MessageBoxIcon.Information);
                else
                    MessageBox.Show("İşlemde hata gerçekleşti.", "Dikkat", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LoadProductGroups();

                tbProductGroup.Text = string.Empty;
            }
            else
            {
                MessageBox.Show("Lütfen ürün grubu giriniz", "Dikkat", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion

        #region LoadFunctions



        private void LoadTables()
        {
            list = Table.GetAllTables();
            dtTables.DataSource = list;
        }

        private void LoadProductGroups()
        {
            listProductGroup = ProductGroup.GetAllProductGroups();
            dtProductGroup.DataSource = listProductGroup;
        }

        private void LoadProduct()
        {
            ListProduct = Product.GetProductByAll();
            dtProduct.DataSource = ListProduct;
        }

        #endregion


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

        private void dtProductGroup_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            var a = dtProductGroup.Rows[e.RowIndex].DataBoundItem as ProductGroup;
            string value = dtProductGroup.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();
            int Id = a.Id;
            //int Id = Convert.ToInt32(dtProductGroup.Rows[e.RowIndex].Cells[0].Value);
            DialogResult dialogResult = MessageBox.Show("Güncellemek istediğinize emin misiniz ? ", "Dikkat", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialogResult == System.Windows.Forms.DialogResult.Yes)
            {
                ProductGroup t = new ProductGroup()
                {
                    Id = Id,
                    ProductGroupName = value
                };
                t.Update();
                MessageBox.Show("Ürün grubu güncelleme işleminiz gerçekleştirilmiştir.", "Bilgilendirme", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                LoadProductGroups();
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

        private void dtProductGroup_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 46)
            {
                DialogResult dialogResult = MessageBox.Show("Silmek istediğinize emin misiniz ? ", "Dikkat", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dialogResult == System.Windows.Forms.DialogResult.Yes)
                {
                    int Id = Convert.ToInt32(dtProductGroup.SelectedRows[0].Cells[0].Value);
                    ProductGroup t = new ProductGroup()
                    {
                        Id = Id
                    };
                    t.Delete();
                }
                LoadProductGroups();
            }
        }


        #region TextBoxKeyDown

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

        private void tbProductGroup_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
            {
                if (tbProductGroup.Text.Replace(" ", "") != string.Empty)
                {
                    ProductGroup productGroup = new ProductGroup()
                    {
                        ProductGroupName = tbProductGroup.Text.Replace(" ", "")
                    };
                    bool result = productGroup.Save();
                    if (result)
                        MessageBox.Show("Ürün Grubu ekleme işleminiz gerçekleştirilmiştir.", "Bilgilendirme", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    else
                        MessageBox.Show("İşlemde hata gerçekleşti.", "Dikkat", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    LoadProductGroups();

                    tbProductGroup.Text = string.Empty;
                }
                else
                {
                    MessageBox.Show("Lütfen masa adı giriniz", "Dikkat", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        #endregion
        private void tb1_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (tb1.SelectedIndex)
            {
                case 0:
                    LoadTables();
                    break;
                case 1:
                    LoadProductGroups();
                    break;
                case 2:
                    LoadProduct();
                    cmbProductGroup.DataSource = ProductGroup.GetAllProductGroups();
                    cmbCurrency.SelectedIndex = 0;
                    break;
                case 3:
                    LoadChelner();
                    break;
                default:
                    break;
            }
        }

        private void btnProductSave_Click(object sender, EventArgs e)
        {
            Product.InsertProduct(Convert.ToInt32(cmbProductGroup.SelectedValue), tbProductName.Text.Trim(),
                Convert.ToDouble(tbPrice.Text.Trim()), cmbCurrency.SelectedItem.ToString());
            LoadProduct();
        }

        private void btnSaveChelner_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(tbChelnerName.Text.Trim()))
            {
                Chelner.Insert(tbChelnerName.Text.Trim());
                LoadChelner();
            }
        }

        private void LoadChelner()
        {
            dtChelner.DataSource = Chelner.GetList();
        }

        private void dtProduct_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            var a = dtProduct.Rows[e.RowIndex].DataBoundItem as Product;
            string value = dtProduct.Rows[e.RowIndex].Cells["ProductName"].Value.ToString();
            double price = Convert.ToDouble(dtProduct.Rows[e.RowIndex].Cells["SalesPrice"].Value.ToString());
            int Id = a.Id;
            //int Id = Convert.ToInt32(dtProduct.Rows[e.RowIndex].Cells[0].Value);
            DialogResult dialogResult = MessageBox.Show("Güncellemek istediğinize emin misiniz ? ", "Dikkat", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialogResult == System.Windows.Forms.DialogResult.Yes)
            {
                Product t = new Product()
                {
                    Id = Id,
                    ProductName = value,
                    SalesPrice = price
                };
                t.Update();
                MessageBox.Show("Ürün güncelleme işleminiz gerçekleştirilmiştir.", "Bilgilendirme", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                LoadProduct();
            }
        }

        private void dtChelner_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            var a = dtChelner.Rows[e.RowIndex].DataBoundItem as Chelner;
            string value = dtChelner.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();
            int Id = a.Id;
            //int Id = Convert.ToInt32(dtProduct.Rows[e.RowIndex].Cells[0].Value);
            DialogResult dialogResult = MessageBox.Show("Güncellemek istediğinize emin misiniz ? ", "Dikkat", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialogResult == DialogResult.Yes)
            {
                Chelner t = new Chelner()
                {
                    Id = Id,
                    ChelnerName = value
                };
                t.Update();
                MessageBox.Show("Masa güncelleme işleminiz gerçekleştirilmiştir.", "Bilgilendirme", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                LoadChelner();
            }
        }

        private void dtProduct_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 46)
            {
                DialogResult dialogResult = MessageBox.Show("Silmek istediğinize emin misiniz ? ", "Dikkat", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dialogResult == DialogResult.Yes)
                {
                    var a = dtProduct.SelectedRows[0].DataBoundItem as Product;
                    Product t = new Product()
                    {
                        Id = a.Id
                    };
                    t.Delete();
                }
                LoadProduct();
            }
        }

        private void dtChelner_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 46)
            {
                DialogResult dialogResult = MessageBox.Show("Silmek istediğinize emin misiniz ? ", "Dikkat", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dialogResult == DialogResult.Yes)
                {
                    var a = dtChelner.SelectedRows[0].DataBoundItem as Chelner;
                    Chelner t = new Chelner
                    {
                        Id = a.Id
                    };
                    t.Delete();
                }
                LoadChelner();
            }
        }
    }
}
