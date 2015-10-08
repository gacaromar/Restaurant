using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Restaurant.DataClass;
using Restaurant.Forms.UserControl.Compotents;

namespace Restaurant.Forms.UserControl
{
    public partial class ucSaleSlip : System.Windows.Forms.UserControl
    {
        private Table gTable;
        private Chelner gChelner;
        private int gQuantity;
        private int gDiscount;
        public ucSaleSlip(Table pTable)
        {
            InitializeComponent();
            LoadInitializeValues(pTable);
        }

        private void LoadInitializeValues(Table pTable)
        {
            var vGroups = ProductGroup.GetAllProductGroups();
            var ucProductGroups = new ucProductGroups();
            ucProductGroups.SetGroups(vGroups, GroupClick);
            gbGroups.Controls.Add(ucProductGroups);
            cmbTables.ValueMember = "Id";
            cmbTables.DisplayMember = "TableName";
            cmbTables.DataSource = Table.GetAllTables();
            cmbTables.SelectedValue = pTable.Id;
            gTable = pTable;
            if (pTable.Active)
            {
                var vBasket = Basket.GetBasketList(pTable.Id);
                gChelner = vBasket[0].Chelner;
                dgvProducts.DataSource = vBasket;
            }
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
            if (gChelner == null || gChelner.Id == 0)
            {
                MessageBox.Show("Lütfen Adisyon için Garson Seçiniz", "Garson Seçimi", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
            var vList = dgvProducts.DataSource as List<Basket>;
            var vProduct = ((sender as Button).Parent as ucProductGroup).Product;
            if (vList == null || vList.All(l => l.Id != vProduct.Id))
            {
                Basket.InsertBasket(gTable.Id, vProduct.ProductGroup.Id, gChelner.Id, vProduct.Id, gDiscount, gQuantity);
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
    }
}
