using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;
using Restaurant.DataClass;
using Restaurant.Forms.UserControl.Compotents;
using Restaurant.Helper;
using System.Drawing;
using System.Drawing.Printing;
using System.Globalization;
using System.IO;
using System.Runtime.InteropServices;
using iTextSharp.text;
using iTextSharp.text.pdf;
using Restaurant.Properties;
using Telerik.Reporting.Processing;
using Color = System.Drawing.Color;
using Table = Restaurant.DataClass.Table;

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
        double total;

        private string FileContents;
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
            tables.Insert(0, new Table { Id = -1, TableName = "Seçiniz" });
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
            gTable = tables.First(z => z.Id == pTableId);// Table.GetTableById(pTableId);

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
            if (cmbTables.SelectedIndex == 0)
            {
                MessageBox.Show("Lütfen Adisyon için Masa Seçiniz", "Masa Seçimi", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return;

            }
            var ucQty = new ucQuantity();
            var frm = GlobalHelper.OpenShowForm(ucQty, FormBorderStyle.None, FormStartPosition.CenterScreen);
            gQuantity = Convert.ToDouble(ucQty.txtQty.Value);
            gDiscount = Convert.ToDouble(ucQty.txtDiscount.Value.ToString().Replace('.', ','));
            GlobalHelper.FormDispose(frm);

            var vList = dgvProducts.DataSource as List<Basket>;
            var vProduct = ((sender as Button).Parent as ucProductGroup).Product;
            if (vList == null || vList.All(l => l.Product.Id != vProduct.Id))
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
                btnSlipPrint_Click(sender, e);
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
                Basket.Update(gTable.Id, vBasket[index].Product.Id, vBasket[index].Quantity, 100);
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

        private void btnSlipPrint_Click(object sender, EventArgs e)
        {

            string sss = DateTime.Now.Millisecond + "Doc1.pdf";
            string filename = AppDomain.CurrentDomain.BaseDirectory + sss;
            Document document = new Document(new iTextSharp.text.Rectangle(155f, 219f), 1f, 1f, 1f, 1f);

            PdfWriter.GetInstance(document, new FileStream(filename, FileMode.Create));

            #region Header

            iTextSharp.text.Table tblHeader = new iTextSharp.text.Table(2, 6);
            tblHeader.Padding = 0;
            tblHeader.BorderWidth = 0;
            tblHeader.Border = 0;
            tblHeader.BorderColor = iTextSharp.text.Color.WHITE;
            tblHeader.Width = 100;
            tblHeader.DefaultCell.Border = iTextSharp.text.Rectangle.NO_BORDER;
            tblHeader.DefaultCell.BorderWidth = 0;
            tblHeader.DefaultCell.BorderColor = iTextSharp.text.Color.WHITE;
            tblHeader.SetWidths(new[] { 45, 100 });
            tblHeader.AddCell(CellCreate("CAFE MOLA", Element.ALIGN_CENTER, Element.ALIGN_CENTER, 2, 1, 10), 0, 0);
            tblHeader.AddCell(CellCreate("Masa No", Element.ALIGN_LEFT, Element.ALIGN_CENTER, 1, 0, 8), 1, 0);
            tblHeader.AddCell(CellCreate(":" + gTable.TableName, Element.ALIGN_LEFT, Element.ALIGN_CENTER), 1, 1);
            tblHeader.AddCell(CellCreate("Açılış", Element.ALIGN_LEFT, Element.ALIGN_CENTER, 1, 0, 8), 2, 0);
            tblHeader.AddCell(
                CellCreate(":" + gTable.RecordDate.ToString("dd.MM.yyyy hh:mm:ss"), Element.ALIGN_LEFT, Element.ALIGN_CENTER),
                2, 1);
            tblHeader.AddCell(CellCreate("Adisyon No", Element.ALIGN_LEFT, Element.ALIGN_CENTER, 1, 0, 8), 3, 0);
            tblHeader.AddCell(CellCreate(":" + gTable.Id.ToString(), Element.ALIGN_LEFT, Element.ALIGN_CENTER), 3, 1);

            #endregion

            #region Content

            iTextSharp.text.Table aTableProduct = new iTextSharp.text.Table(4, vBasket.Count + 1);
            aTableProduct.Padding = 0;
            aTableProduct.BorderWidth = 0;
            aTableProduct.Border = 0;
            aTableProduct.BorderColor = iTextSharp.text.Color.WHITE;
            aTableProduct.Width = 100;
            aTableProduct.SetWidths(new[] { 70, 25, 25, 25 });
            aTableProduct.DefaultCell.Border = iTextSharp.text.Rectangle.NO_BORDER;
            aTableProduct.DefaultCell.BorderWidth = 0;
            aTableProduct.DefaultCell.BorderColor = iTextSharp.text.Color.WHITE;

            aTableProduct.AddCell(CellCreate("Ürün", Element.ALIGN_LEFT, Element.ALIGN_CENTER, 1, 2, 8));
            aTableProduct.AddCell(CellCreate("Mik.", Element.ALIGN_LEFT, Element.ALIGN_CENTER, 1, 2, 8));
            aTableProduct.AddCell(CellCreate("Fiyat", Element.ALIGN_LEFT, Element.ALIGN_CENTER, 1, 2, 8));
            aTableProduct.AddCell(CellCreate("Tutar", Element.ALIGN_LEFT, Element.ALIGN_CENTER, 1, 2, 8));

            foreach (Basket t in vBasket)
            {
                aTableProduct.AddCell(CellCreate(t.Product.ProductName, Element.ALIGN_LEFT, Element.ALIGN_CENTER, 1, 1, 6));
                aTableProduct.AddCell(CellCreate(t.Quantity.ToString(CultureInfo.CurrentCulture), Element.ALIGN_LEFT,
                    Element.ALIGN_CENTER, 1, 1, 6));
                aTableProduct.AddCell(CellCreate(t.Product.SalesPrice.ToString("N2"), Element.ALIGN_LEFT,
                    Element.ALIGN_CENTER, 1, 1, 6));
                aTableProduct.AddCell(CellCreate(t.Total.ToString("N2"), Element.ALIGN_LEFT, Element.ALIGN_CENTER, 1, 1, 6));
            }

            #endregion

            #region Footer

            iTextSharp.text.Table tblFooter = new iTextSharp.text.Table(2, 3);
            tblFooter.Padding = 0;
            tblFooter.BorderWidth = 0;
            tblFooter.Border = 0;
            tblFooter.BorderColor = iTextSharp.text.Color.WHITE;
            tblFooter.Width = 100;
            tblFooter.DefaultCell.Border = iTextSharp.text.Rectangle.NO_BORDER;
            tblFooter.DefaultCell.BorderWidth = 0;
            tblFooter.DefaultCell.BorderColor = iTextSharp.text.Color.WHITE;
            tblFooter.SetWidths(new[] { 100, 45 });
            tblFooter.AddCell(CellCreate("Ara", Element.ALIGN_LEFT, Element.ALIGN_CENTER, 1, 1, 8), 0, 0);
            tblFooter.AddCell(CellCreate(total.ToString("N2"), Element.ALIGN_RIGHT, Element.ALIGN_CENTER, 1, 1, 8), 0,
                1);
            tblFooter.AddCell(CellCreate("Genel Toplam", Element.ALIGN_LEFT, Element.ALIGN_CENTER, 1, 1, 8), 1, 0);
            tblFooter.AddCell(CellCreate(total.ToString("N2"), Element.ALIGN_RIGHT, Element.ALIGN_CENTER, 1, 1, 8), 1,
                1);
            tblFooter.AddCell(CellCreate("Afiyet Olsun", Element.ALIGN_CENTER, Element.ALIGN_CENTER, 2, 1, 12), 2, 0);

            #endregion

            if (document.IsOpen() == false)
            {
                document.Open();
            }

            Paragraph headerPhrase = new Paragraph("") { Alignment = Element.ALIGN_CENTER };
            document.Add(tblHeader);
            document.Add(headerPhrase);
            document.Add(aTableProduct);
            document.Add(headerPhrase);
            document.Add(tblFooter);


            document.Close();
            var vList = MySettings.GetListPrinter();
            //pdDoc.PrinterSettings.PrinterName = vList[0].Value;
            //FileInfo file_into = new FileInfo(filename);
            //string short_name = file_into.Name;

            //// Set the PrintDocument's name for use by the printer queue.
            //pdDoc.DocumentName = short_name;

            //// Read the file's contents.
            //try
            //{
            //    FileContents = File.ReadAllText(filename).Trim();
            //    pdDoc.PrintPage += pdocTextFile_PrintPage;
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show("Error reading file " + filename +
            //        ".\n" + ex.Message);
            //    return;
            //}

            //// Print.
            //pdDoc.Print();

            //return;

            myPrinters.SetDefaultPrinter(vList[0].Value);

            //ReportProcessor reportProcessor = new ReportProcessor();
            //reportProcessor.PrintReport(new Report1(), new PrinterSettings());
            ProcessStartInfo info = new ProcessStartInfo();
            info.Verb = "print";
            info.FileName = filename;
            info.CreateNoWindow = true;
            info.WindowStyle = ProcessWindowStyle.Hidden;

            Process p = new Process();
            p.StartInfo = info;
            p.Start();

            p.WaitForInputIdle();
            System.Threading.Thread.Sleep(10000);
            if (false == p.CloseMainWindow())
            {
                p.Kill();
                //File.Delete(filename);
            }
        }
        public static class myPrinters
        {
            [DllImport("winspool.drv", CharSet = CharSet.Auto, SetLastError = true)]
            public static extern bool SetDefaultPrinter(string Name);

        }

        private void btnPrintSlipKitchen_Click(object sender, EventArgs e)
        {
            string sss = DateTime.Now.Millisecond + "Doc1.pdf";
            string filename = AppDomain.CurrentDomain.BaseDirectory + sss;
            Document document = new Document(new iTextSharp.text.Rectangle(155f, 219f), 1f, 1f, 2f, 1f);

            PdfWriter.GetInstance(document, new FileStream(filename, FileMode.Create));

            #region Header

            iTextSharp.text.Table tblHeader = new iTextSharp.text.Table(2, 6);
            tblHeader.Padding = 0;
            tblHeader.BorderWidth = 0;
            tblHeader.Border = 0;
            tblHeader.BorderColor = iTextSharp.text.Color.WHITE;
            tblHeader.Width = 100;
            tblHeader.DefaultCell.Border = iTextSharp.text.Rectangle.NO_BORDER;
            tblHeader.DefaultCell.BorderWidth = 0;
            tblHeader.DefaultCell.BorderColor = iTextSharp.text.Color.WHITE;
            tblHeader.SetWidths(new[] { 45, 100 });
            tblHeader.AddCell(CellCreate("CAFE MOLA", Element.ALIGN_CENTER, Element.ALIGN_CENTER, 2, 1, 10), 0, 0);
            tblHeader.AddCell(CellCreate("Masa No", Element.ALIGN_LEFT, Element.ALIGN_CENTER, 1, 0, 8), 1, 0);
            tblHeader.AddCell(CellCreate(":" + gTable.TableName, Element.ALIGN_LEFT, Element.ALIGN_CENTER), 1, 1);
            tblHeader.AddCell(CellCreate("Açılış", Element.ALIGN_LEFT, Element.ALIGN_CENTER, 1, 0, 8), 2, 0);
            tblHeader.AddCell(
                CellCreate(":" + gTable.RecordDate.ToString("dd.MM.yyyy hh:mm:ss"), Element.ALIGN_LEFT, Element.ALIGN_CENTER),
                2, 1);
            tblHeader.AddCell(CellCreate("Adisyon No", Element.ALIGN_LEFT, Element.ALIGN_CENTER, 1, 0, 8), 3, 0);
            tblHeader.AddCell(CellCreate(":" + gTable.Id.ToString(), Element.ALIGN_LEFT, Element.ALIGN_CENTER), 3, 1);

            #endregion

            #region Content

            iTextSharp.text.Table aTableProduct = new iTextSharp.text.Table(4, vBasket.Count + 1);
            aTableProduct.Padding = 0;
            aTableProduct.BorderWidth = 0;
            aTableProduct.Border = 0;
            aTableProduct.BorderColor = iTextSharp.text.Color.WHITE;
            aTableProduct.Width = 100;
            aTableProduct.SetWidths(new[] { 70, 25, 25, 25 });
            aTableProduct.DefaultCell.Border = iTextSharp.text.Rectangle.NO_BORDER;
            aTableProduct.DefaultCell.BorderWidth = 0;
            aTableProduct.DefaultCell.BorderColor = iTextSharp.text.Color.WHITE;

            aTableProduct.AddCell(CellCreate("Ürün", Element.ALIGN_LEFT, Element.ALIGN_CENTER, 1, 2, 8));
            aTableProduct.AddCell(CellCreate("Mik.", Element.ALIGN_LEFT, Element.ALIGN_CENTER, 1, 2, 8));
            aTableProduct.AddCell(CellCreate("Fiyat", Element.ALIGN_LEFT, Element.ALIGN_CENTER, 1, 2, 8));
            aTableProduct.AddCell(CellCreate("Tutar", Element.ALIGN_LEFT, Element.ALIGN_CENTER, 1, 2, 8));

            foreach (Basket t in vBasket)
            {
                aTableProduct.AddCell(CellCreate(t.Product.ProductName, Element.ALIGN_LEFT, Element.ALIGN_CENTER, 1, 1, 6));
                aTableProduct.AddCell(CellCreate(t.Quantity.ToString(CultureInfo.CurrentCulture), Element.ALIGN_LEFT,
                    Element.ALIGN_CENTER, 1, 1, 6));
                aTableProduct.AddCell(CellCreate(t.Product.SalesPrice.ToString("N2"), Element.ALIGN_LEFT,
                    Element.ALIGN_CENTER, 1, 1, 6));
                aTableProduct.AddCell(CellCreate(t.Total.ToString("N2"), Element.ALIGN_LEFT, Element.ALIGN_CENTER, 1, 1, 6));
            }

            #endregion

            #region Footer

            iTextSharp.text.Table tblFooter = new iTextSharp.text.Table(2, 3);
            tblFooter.Padding = 0;
            tblFooter.BorderWidth = 0;
            tblFooter.Border = 0;
            tblFooter.BorderColor = iTextSharp.text.Color.WHITE;
            tblFooter.Width = 100;
            tblFooter.DefaultCell.Border = iTextSharp.text.Rectangle.NO_BORDER;
            tblFooter.DefaultCell.BorderWidth = 0;
            tblFooter.DefaultCell.BorderColor = iTextSharp.text.Color.WHITE;
            tblFooter.SetWidths(new[] { 100, 45 });
            tblFooter.AddCell(CellCreate("Ara", Element.ALIGN_LEFT, Element.ALIGN_CENTER, 1, 1, 8), 0, 0);
            tblFooter.AddCell(CellCreate(total.ToString("N2"), Element.ALIGN_RIGHT, Element.ALIGN_CENTER, 1, 1, 8), 0,
                1);
            tblFooter.AddCell(CellCreate("Genel Toplam", Element.ALIGN_LEFT, Element.ALIGN_CENTER, 1, 1, 8), 1, 0);
            tblFooter.AddCell(CellCreate(total.ToString("N2"), Element.ALIGN_RIGHT, Element.ALIGN_CENTER, 1, 1, 8), 1,
                1);
            tblFooter.AddCell(CellCreate("Afiyet Olsun", Element.ALIGN_CENTER, Element.ALIGN_CENTER, 2, 1, 12), 2, 0);

            #endregion

            if (document.IsOpen() == false)
            {
                document.Open();
            }

            Paragraph headerPhrase = new Paragraph("") { Alignment = Element.ALIGN_CENTER };
            document.Add(tblHeader);
            document.Add(headerPhrase);
            document.Add(aTableProduct);
            document.Add(headerPhrase);
            document.Add(tblFooter);

            document.Close();
            var vList = MySettings.GetListPrinter();
            myPrinters.SetDefaultPrinter(vList[1].Value);
            ProcessStartInfo info = new ProcessStartInfo();
            info.Verb = "print";
            info.FileName = filename;
            info.CreateNoWindow = true;
            info.WindowStyle = ProcessWindowStyle.Hidden;

            Process p = new Process();
            p.StartInfo = info;
            p.Start();

            p.WaitForInputIdle();
            System.Threading.Thread.Sleep(3000);
            if (false == p.CloseMainWindow())
            {
                p.Kill();
                //File.Delete(filename);
            }
        }

        private Cell CellCreate(string text, int vAlignment = 1, int hAlignment = 0, int colspan = 1, int type = 0, int font = 10)
        {
            BaseFont trArial = BaseFont.CreateFont(@"C:\WINDOWS\Fonts\arial.ttf", BaseFont.IDENTITY_H, BaseFont.NOT_EMBEDDED);
            iTextSharp.text.Font newFont = new iTextSharp.text.Font(trArial, font, iTextSharp.text.Font.NORMAL);

            if (type == 0) newFont = new iTextSharp.text.Font(trArial, font, iTextSharp.text.Font.NORMAL);
            else newFont = new iTextSharp.text.Font(trArial, font, iTextSharp.text.Font.BOLD);

            Cell cell = new Cell();
            cell.Add(new Phrase(text, newFont));
            cell.HorizontalAlignment = vAlignment;
            cell.VerticalAlignment = hAlignment;
            cell.Colspan = colspan;

            return cell;
        }
    }
}
