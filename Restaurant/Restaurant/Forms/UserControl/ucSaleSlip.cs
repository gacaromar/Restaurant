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
            if (pTable.Active)
            {
                gTable = pTable;
                var vBasket = Basket.GetBasketList(pTable.Id);
                gChelner = vBasket[0].Chelner;
                dgvProducts.DataSource = vBasket;
            }
            var vGroups = ProductGroup.GetAllProductGroups();
            var ucProductGroups = new ucProductGroups();
            ucProductGroups.SetGroups(vGroups, GroupClick);
            gbGroups.Controls.Add(ucProductGroups);
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
            var vList = dgvProducts.DataSource as List<Orders>;
            var vProduct = ((sender as Button).Parent as ucProductGroup).Product;
            if (vList != null && vList.Any(l => l.Id == vProduct.Id))
            {
                Orders.InsertOrder(gTable.Id, vProduct.ProductGroup.Id, gChelner.Id, vProduct.Id, vProduct.SalesPrice,
                    gDiscount,
                    gQuantity, vProduct.SalesPrice * gQuantity);
            }
        }
        private void btnIncrement_Click(object sender, EventArgs e)
        {

        }
    }
}
