namespace Restaurant.Forms.UserControl
{
    partial class ucSaleSlip
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.pnlGroups = new System.Windows.Forms.Panel();
            this.pnlProducts = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.btnDecrement = new System.Windows.Forms.Button();
            this.btnIncrement = new System.Windows.Forms.Button();
            this.btnSlipPrint = new System.Windows.Forms.Button();
            this.btnCloseSlip = new System.Windows.Forms.Button();
            this.btnPrintSlipKitchen = new System.Windows.Forms.Button();
            this.btnGift = new System.Windows.Forms.Button();
            this.btnCancelSlip = new System.Windows.Forms.Button();
            this.dgvProducts = new System.Windows.Forms.DataGridView();
            this.Product = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Price = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Quantity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Amount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Delete = new System.Windows.Forms.DataGridViewButtonColumn();
            this.btnAddSaleser = new System.Windows.Forms.Button();
            this.cmbTables = new System.Windows.Forms.ComboBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProducts)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlGroups
            // 
            this.pnlGroups.AutoScroll = true;
            this.pnlGroups.Location = new System.Drawing.Point(311, 1);
            this.pnlGroups.Name = "pnlGroups";
            this.pnlGroups.Size = new System.Drawing.Size(710, 105);
            this.pnlGroups.TabIndex = 6;
            // 
            // pnlProducts
            // 
            this.pnlProducts.Location = new System.Drawing.Point(311, 112);
            this.pnlProducts.Name = "pnlProducts";
            this.pnlProducts.Size = new System.Drawing.Size(710, 365);
            this.pnlProducts.TabIndex = 6;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.btnDecrement);
            this.panel1.Controls.Add(this.btnIncrement);
            this.panel1.Controls.Add(this.btnSlipPrint);
            this.panel1.Controls.Add(this.btnCloseSlip);
            this.panel1.Controls.Add(this.btnPrintSlipKitchen);
            this.panel1.Controls.Add(this.btnGift);
            this.panel1.Controls.Add(this.btnCancelSlip);
            this.panel1.Controls.Add(this.dgvProducts);
            this.panel1.Controls.Add(this.btnAddSaleser);
            this.panel1.Controls.Add(this.cmbTables);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(310, 480);
            this.panel1.TabIndex = 7;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.Location = new System.Drawing.Point(156, 444);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(145, 33);
            this.label1.TabIndex = 16;
            this.label1.Text = "0.00";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btnDecrement
            // 
            this.btnDecrement.Location = new System.Drawing.Point(5, 367);
            this.btnDecrement.Name = "btnDecrement";
            this.btnDecrement.Size = new System.Drawing.Size(51, 23);
            this.btnDecrement.TabIndex = 9;
            this.btnDecrement.Text = "-0.5";
            this.btnDecrement.UseVisualStyleBackColor = true;
            // 
            // btnIncrement
            // 
            this.btnIncrement.Location = new System.Drawing.Point(62, 367);
            this.btnIncrement.Name = "btnIncrement";
            this.btnIncrement.Size = new System.Drawing.Size(51, 23);
            this.btnIncrement.TabIndex = 10;
            this.btnIncrement.Text = "+0.5";
            this.btnIncrement.UseVisualStyleBackColor = true;
            // 
            // btnSlipPrint
            // 
            this.btnSlipPrint.Location = new System.Drawing.Point(156, 396);
            this.btnSlipPrint.Name = "btnSlipPrint";
            this.btnSlipPrint.Size = new System.Drawing.Size(145, 41);
            this.btnSlipPrint.TabIndex = 11;
            this.btnSlipPrint.Text = "Adisyonu Yaz";
            this.btnSlipPrint.UseVisualStyleBackColor = true;
            // 
            // btnCloseSlip
            // 
            this.btnCloseSlip.Location = new System.Drawing.Point(5, 439);
            this.btnCloseSlip.Name = "btnCloseSlip";
            this.btnCloseSlip.Size = new System.Drawing.Size(145, 38);
            this.btnCloseSlip.TabIndex = 12;
            this.btnCloseSlip.Text = "Hesabı Kapat";
            this.btnCloseSlip.UseVisualStyleBackColor = true;
            // 
            // btnPrintSlipKitchen
            // 
            this.btnPrintSlipKitchen.Location = new System.Drawing.Point(5, 396);
            this.btnPrintSlipKitchen.Name = "btnPrintSlipKitchen";
            this.btnPrintSlipKitchen.Size = new System.Drawing.Size(145, 41);
            this.btnPrintSlipKitchen.TabIndex = 13;
            this.btnPrintSlipKitchen.Text = "Mutfağa Yaz";
            this.btnPrintSlipKitchen.UseVisualStyleBackColor = true;
            // 
            // btnGift
            // 
            this.btnGift.Location = new System.Drawing.Point(119, 367);
            this.btnGift.Name = "btnGift";
            this.btnGift.Size = new System.Drawing.Size(75, 23);
            this.btnGift.TabIndex = 14;
            this.btnGift.Text = "İkram";
            this.btnGift.UseVisualStyleBackColor = true;
            // 
            // btnCancelSlip
            // 
            this.btnCancelSlip.Location = new System.Drawing.Point(200, 367);
            this.btnCancelSlip.Name = "btnCancelSlip";
            this.btnCancelSlip.Size = new System.Drawing.Size(75, 23);
            this.btnCancelSlip.TabIndex = 15;
            this.btnCancelSlip.Text = "İptal";
            this.btnCancelSlip.UseVisualStyleBackColor = true;
            // 
            // dgvProducts
            // 
            this.dgvProducts.AllowUserToAddRows = false;
            this.dgvProducts.AllowUserToOrderColumns = true;
            this.dgvProducts.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvProducts.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Product,
            this.Price,
            this.Quantity,
            this.Amount,
            this.Delete});
            this.dgvProducts.Location = new System.Drawing.Point(5, 36);
            this.dgvProducts.Name = "dgvProducts";
            this.dgvProducts.Size = new System.Drawing.Size(301, 325);
            this.dgvProducts.TabIndex = 8;
            // 
            // Product
            // 
            this.Product.HeaderText = "Ürün";
            this.Product.Name = "Product";
            // 
            // Price
            // 
            this.Price.HeaderText = "Fiyatı";
            this.Price.Name = "Price";
            this.Price.ReadOnly = true;
            // 
            // Quantity
            // 
            this.Quantity.HeaderText = "Mik.";
            this.Quantity.Name = "Quantity";
            this.Quantity.ReadOnly = true;
            // 
            // Amount
            // 
            this.Amount.HeaderText = "Toplam";
            this.Amount.Name = "Amount";
            this.Amount.ReadOnly = true;
            // 
            // Delete
            // 
            this.Delete.HeaderText = "Sil";
            this.Delete.Name = "Delete";
            // 
            // btnAddSaleser
            // 
            this.btnAddSaleser.Location = new System.Drawing.Point(173, 4);
            this.btnAddSaleser.Margin = new System.Windows.Forms.Padding(4);
            this.btnAddSaleser.Name = "btnAddSaleser";
            this.btnAddSaleser.Size = new System.Drawing.Size(133, 25);
            this.btnAddSaleser.TabIndex = 7;
            this.btnAddSaleser.Text = "Garson";
            this.btnAddSaleser.UseVisualStyleBackColor = true;
            // 
            // cmbTables
            // 
            this.cmbTables.FormattingEnabled = true;
            this.cmbTables.Location = new System.Drawing.Point(5, 4);
            this.cmbTables.Margin = new System.Windows.Forms.Padding(4);
            this.cmbTables.Name = "cmbTables";
            this.cmbTables.Size = new System.Drawing.Size(160, 24);
            this.cmbTables.TabIndex = 6;
            // 
            // ucSaleSlip
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.pnlProducts);
            this.Controls.Add(this.pnlGroups);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "ucSaleSlip";
            this.Size = new System.Drawing.Size(1024, 480);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvProducts)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlGroups;
        private System.Windows.Forms.Panel pnlProducts;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnDecrement;
        private System.Windows.Forms.Button btnIncrement;
        private System.Windows.Forms.Button btnSlipPrint;
        private System.Windows.Forms.Button btnCloseSlip;
        private System.Windows.Forms.Button btnPrintSlipKitchen;
        private System.Windows.Forms.Button btnGift;
        private System.Windows.Forms.Button btnCancelSlip;
        private System.Windows.Forms.DataGridView dgvProducts;
        private System.Windows.Forms.DataGridViewTextBoxColumn Product;
        private System.Windows.Forms.DataGridViewTextBoxColumn Price;
        private System.Windows.Forms.DataGridViewTextBoxColumn Quantity;
        private System.Windows.Forms.DataGridViewTextBoxColumn Amount;
        private System.Windows.Forms.DataGridViewButtonColumn Delete;
        private System.Windows.Forms.Button btnAddSaleser;
        private System.Windows.Forms.ComboBox cmbTables;

    }
}
