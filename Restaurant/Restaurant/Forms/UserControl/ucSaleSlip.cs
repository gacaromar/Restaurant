using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;
using Restaurant.DataClass;
using Restaurant.Forms.UserControl.Compotents;
using Restaurant.Helper;

namespace Restaurant.Forms.UserControl
{
    public partial class ucSaleSlip : System.Windows.Forms.UserControl
    {
        private Table gTable;
        private Chelner gChelner;
        private int gQuantity;
        private int gDiscount;
        private bool gComeMainForm = false;
        List<Table> tables;
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
            var vBasket = Basket.GetBasketList(pTableId);
            if (vBasket.Count == 0)
            {
                dgvProducts.DataSource = null;
                return;
            }
            gChelner = vBasket[0].Chelner;
            dgvProducts.DataSource = vBasket;
            gTable = tables.Where(z => z.Id == pTableId).First();// Table.GetTableById(pTableId);
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
            gQuantity = Convert.ToInt32(ucQty.txtQty.Value);
            gDiscount = Convert.ToInt32(ucQty.txtDiscount.Value.ToString().Replace('.', ','));
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
            var vBasket = Basket.GetBasketList(gTable.Id);
            dgvProducts.DataSource = vBasket;
            if (!gTable.Active)
            {
                Table.UpdateActive(gTable.Id);
            }
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

    }

}
