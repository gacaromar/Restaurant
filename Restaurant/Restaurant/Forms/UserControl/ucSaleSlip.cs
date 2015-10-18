using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;
using Restaurant.DataClass;
using Restaurant.Forms.UserControl.Compotents;
using Restaurant.Helper;
using System.Drawing;

namespace Restaurant.Forms.UserControl
{
    public partial class ucSaleSlip : System.Windows.Forms.UserControl
    {
        private Table gTable;
        private Chelner gChelner;
        List<Basket> vBasket;
        private double gQuantity;
        private double gDiscount;
        private bool gComeMainForm = false;
        List<Table> tables;
        double total ;
        public ucSaleSlip(Table pTable)
        {
            InitializeComponent();
            LoadInitializeValues(pTable);
        }

        private void LoadInitializeValues(Table pTable)
        {
            gComeMainForm = true;
            var vGroups = ProductGroup.GetAllProductGroups();
            var ucProductGroups = new ucProductGroups();
            ucProductGroups.SetGroups(vGroups, GroupClick);
            gbGroups.Controls.Add(ucProductGroups);
            cmbTables.ValueMember = "Id";
            cmbTables.DisplayMember = "TableName";
            tables = Table.GetAllTables();
            cmbTables.DataSource = tables;
            if (pTable != null)
            {
                cmbTables.SelectedValue = pTable.Id;
                gTable = pTable;
                if (pTable.Active)
                {
                    LoadGrid(pTable.Id);
                }
            }
            gComeMainForm = false;



        }

        void LoadGrid(int pTableId)
        {
             vBasket = Basket.GetBasketList(pTableId);
            if (vBasket.Count == 0)
            {
                dgvProducts.DataSource = null;
                return;
            }
            gChelner = vBasket[0].Chelner;
            dgvProducts.DataSource = vBasket;
            gTable = tables.Where(z => z.Id == pTableId).First();// Table.GetTableById(pTableId);

            total = vBasket.Sum(t => t.Total);
            lblTotal.Text = total.ToString("N2");

        }
        private void GroupClick(object sender, EventArgs e)
        {
            if (sender == null) return;
            var vGroupId = ((sender as Button).Parent as ucProductGroup).ProductGroup.Id;
            var vList = Product.GetProductByProductGroupId(vGroupId);
            gbProducts.Controls.Clear();
            var vucProducts = new ucProducts();
            vucProducts.SetGroups(vList, ProductClick);
            gbProducts.Controls.Add(vucProducts);
        }

        private void ProductClick(object sender, EventArgs e)
        {
            if (sender == null) return;
            //if (gChelner == null || gChelner.Id == 0)
            //{
            //    MessageBox.Show("Lütfen Adisyon için Garson Seçiniz", "Garson Seçimi", MessageBoxButtons.OK,
            //        MessageBoxIcon.Error);
            //    return;

            //}
            var ucQty = new ucQuantity();
            var frm = GlobalHelper.OpenShowForm(ucQty, FormBorderStyle.None, FormStartPosition.CenterScreen);
            gQuantity = Convert.ToDouble(ucQty.txtQty.Value);
            gDiscount = Convert.ToDouble(ucQty.txtDiscount.Value.ToString().Replace('.', ','));
            GlobalHelper.FormDispose(frm);

            var vList = dgvProducts.DataSource as List<Basket>;
            var vProduct = ((sender as Button).Parent as ucProductGroup).Product;
            if (vList == null || vList.Where(l => l.Product.Id == vProduct.Id).Count() == 0)
            {
                Basket.InsertBasket(gTable.Id, vProduct.ProductGroup.Id, gChelner == null ? -1 : gChelner.Id, vProduct.Id, gDiscount, gQuantity);
            }
            else
            {
                var item = vList.Find(l => l.Product.Id == vProduct.Id);
                Basket.Update(gTable.Id, vProduct.Id, item.Quantity + gQuantity);
            }

            LoadBasket();

            if (!gTable.Active)
            {
                Table.UpdateActive(gTable.Id);
            }
        }

        private void LoadBasket()
        {
             vBasket = Basket.GetBasketList(gTable.Id);
            dgvProducts.DataSource = vBasket;

            total = vBasket.Sum(t => t.Total);
            lblTotal.Text = total.ToString("N2");
        }
        private void btnIncrement_Click(object sender, EventArgs e)
        {

        }

        private void btnAddSaleser_Click(object sender, EventArgs e)
        {
            var frm = new ChelnerForm();
            frm.ShowDialog();
            gChelner = new Chelner
            {
                Id = frm.ChelnerId
            };
            frm.Dispose();
        }

        private void dgvProducts_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if ((dgvProducts.Rows[e.RowIndex].DataBoundItem != null) &&
                (dgvProducts.Columns[e.ColumnIndex].DataPropertyName.Contains(".")))
            {
                e.Value = BindProperty(
                    dgvProducts.Rows[e.RowIndex].DataBoundItem,
                    dgvProducts.Columns[e.ColumnIndex].DataPropertyName
                    );
            }
        }
        private string BindProperty(object property, string propertyName)
        {
            string retValue = "";

            if (propertyName.Contains("."))
            {
                var leftPropertyName = propertyName.Substring(0, propertyName.IndexOf(".", StringComparison.Ordinal));
                var arrayProperties = property.GetType().GetProperties();

                foreach (PropertyInfo propertyInfo in arrayProperties)
                {
                    if (propertyInfo.Name == leftPropertyName)
                    {
                        retValue = BindProperty(
                          propertyInfo.GetValue(property, null),
                          propertyName.Substring(propertyName.IndexOf(".", StringComparison.Ordinal) + 1));
                        break;
                    }
                }
            }
            else
            {
                var propertyType = property.GetType();
                var propertyInfo = propertyType.GetProperty(propertyName);
                retValue = propertyInfo.GetValue(property, null).ToString();
            }

            return retValue;
        }

        private void cmbTables_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!gComeMainForm)
                LoadGrid((Convert.ToInt32(cmbTables.SelectedValue)));
        }

        private void btnCloseSlip_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Adisyon yazdırmak istermisiniz ? ", "Adisyon", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialogResult == System.Windows.Forms.DialogResult.Yes)
            {
                // Adisyon yazdır
                SaveOrder();
            }
            else
            {
                SaveOrder();
            }
        }

        private void SaveOrder()
        {
            int orderId = Orders.InsertOrder(gTable.Id, gChelner.Id, vBasket.Count, Convert.ToDouble(lblTotal.Text));

            foreach (Basket item in vBasket)
            {
                Basket.UpdateBasketWithOrder(item.Id, orderId);
                OrderDetail.InsertOrderDetail(orderId, item.ProductGroup.Id, item.Product.Id, item.Product.SalesPrice, item.Product.CurrencyType, item.Quantity, item.Discount, item.Total);
            }

            LoadBasket();

            MessageBox.Show("Hesap kapatılmıştır. ", "Hesap Kapatma", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        private void btnIncrement_Click_1(object sender, EventArgs e)
        {
            if (dgvProducts.CurrentCell.RowIndex >= 0)
            {
                int index = dgvProducts.CurrentCell.RowIndex;
                Basket.Update(gTable.Id, vBasket[index].Product.Id, vBasket[index].Quantity + 0.5);
                LoadBasket();
            }
            else
            {
                MessageBox.Show("Lütfen ürün seçiniz. ", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnDecrement_Click(object sender, EventArgs e)
        {
            if (dgvProducts.CurrentCell.RowIndex >= 0)
            {
                int index = dgvProducts.CurrentCell.RowIndex;
                Basket.Update(gTable.Id, vBasket[index].Product.Id, vBasket[index].Quantity - 0.5);
                LoadBasket();
            }
            else
            {
                MessageBox.Show("Lütfen ürün seçiniz. ", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnGift_Click(object sender, EventArgs e)
        {
            if (dgvProducts.CurrentCell.RowIndex >= 0)
            {
                int index = dgvProducts.CurrentCell.RowIndex;
                Basket.Update(gTable.Id, vBasket[index].Product.Id, vBasket[index].Quantity,100);
                LoadBasket();
            }
            else
            {
                MessageBox.Show("Lütfen ürün seçiniz. ", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnCancelSlip_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Adisyonu iptal etmek istediğinize emin misiniz ? ", "Adisyon İptal", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialogResult == System.Windows.Forms.DialogResult.Yes)
            {
                Basket.DeleteBasket(gTable.Id);
                LoadBasket();
            }
        }

        private void dgvProducts_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            Basket.Update(gTable.Id, vBasket[e.RowIndex].Product.Id, Convert.ToDouble(dgvProducts.Rows[e.RowIndex].Cells[2].Value), Convert.ToDouble(dgvProducts.Rows[e.RowIndex].Cells[3].Value));
            LoadBasket();
        }

        

        private void dgvProducts_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;

            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn &&
                e.RowIndex >= 0)
            {
                 DialogResult dialogResult = MessageBox.Show("Silmek istediğinize emin misiniz ? ", "Sil", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                 if (dialogResult == System.Windows.Forms.DialogResult.Yes)
                 {
                     Basket.DeleteBasketItem(vBasket[e.RowIndex].Id, gTable.Id);
                     LoadBasket();
                 }
            }
        }

       

        //private void MenuOpenPO_Click(object sender, MouseEventArgs e)
        //{
        //    Basket.DeleteBasketItem(vBasket[currentMouseOverRow].Id, gTable.Id);
        //}

    }

}
