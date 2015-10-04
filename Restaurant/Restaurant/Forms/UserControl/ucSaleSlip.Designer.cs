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
            this.cmbTables = new System.Windows.Forms.ComboBox();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.btnAddSaleser = new System.Windows.Forms.Button();
            this.dgvProducts = new System.Windows.Forms.DataGridView();
            this.Product = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Price = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Quantity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Amount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Delete = new System.Windows.Forms.DataGridViewButtonColumn();
            this.btnCancelSlip = new System.Windows.Forms.Button();
            this.btnGift = new System.Windows.Forms.Button();
            this.btnIncrement = new System.Windows.Forms.Button();
            this.btnDecrement = new System.Windows.Forms.Button();
            this.btnPrintSlipKitchen = new System.Windows.Forms.Button();
            this.btnSlipPrint = new System.Windows.Forms.Button();
            this.btnCloseSlip = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProducts)).BeginInit();
            this.SuspendLayout();
            // 
            // cmbTables
            // 
            this.cmbTables.FormattingEnabled = true;
            this.cmbTables.Location = new System.Drawing.Point(4, 4);
            this.cmbTables.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cmbTables.Name = "cmbTables";
            this.cmbTables.Size = new System.Drawing.Size(160, 24);
            this.cmbTables.TabIndex = 0;
            // 
            // splitter1
            // 
            this.splitter1.Location = new System.Drawing.Point(0, 0);
            this.splitter1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(305, 480);
            this.splitter1.TabIndex = 1;
            this.splitter1.TabStop = false;
            // 
            // btnAddSaleser
            // 
            this.btnAddSaleser.Location = new System.Drawing.Point(172, 4);
            this.btnAddSaleser.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnAddSaleser.Name = "btnAddSaleser";
            this.btnAddSaleser.Size = new System.Drawing.Size(133, 25);
            this.btnAddSaleser.TabIndex = 2;
            this.btnAddSaleser.Text = "Garson";
            this.btnAddSaleser.UseVisualStyleBackColor = true;
            // 
            // dgvProducts
            // 
            this.dgvProducts.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvProducts.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Product,
            this.Price,
            this.Quantity,
            this.Amount,
            this.Delete});
            this.dgvProducts.Location = new System.Drawing.Point(4, 36);
            this.dgvProducts.Name = "dgvProducts";
            this.dgvProducts.Size = new System.Drawing.Size(301, 325);
            this.dgvProducts.TabIndex = 3;
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
            // btnCancelSlip
            // 
            this.btnCancelSlip.Location = new System.Drawing.Point(199, 367);
            this.btnCancelSlip.Name = "btnCancelSlip";
            this.btnCancelSlip.Size = new System.Drawing.Size(75, 23);
            this.btnCancelSlip.TabIndex = 4;
            this.btnCancelSlip.Text = "İptal";
            this.btnCancelSlip.UseVisualStyleBackColor = true;
            // 
            // btnGift
            // 
            this.btnGift.Location = new System.Drawing.Point(118, 367);
            this.btnGift.Name = "btnGift";
            this.btnGift.Size = new System.Drawing.Size(75, 23);
            this.btnGift.TabIndex = 4;
            this.btnGift.Text = "İkram";
            this.btnGift.UseVisualStyleBackColor = true;
            // 
            // btnIncrement
            // 
            this.btnIncrement.Location = new System.Drawing.Point(61, 367);
            this.btnIncrement.Name = "btnIncrement";
            this.btnIncrement.Size = new System.Drawing.Size(51, 23);
            this.btnIncrement.TabIndex = 4;
            this.btnIncrement.Text = "+0.5";
            this.btnIncrement.UseVisualStyleBackColor = true;
            this.btnIncrement.Click += new System.EventHandler(this.btnIncrement_Click);
            // 
            // btnDecrement
            // 
            this.btnDecrement.Location = new System.Drawing.Point(4, 367);
            this.btnDecrement.Name = "btnDecrement";
            this.btnDecrement.Size = new System.Drawing.Size(51, 23);
            this.btnDecrement.TabIndex = 4;
            this.btnDecrement.Text = "-0.5";
            this.btnDecrement.UseVisualStyleBackColor = true;
            // 
            // btnPrintSlipKitchen
            // 
            this.btnPrintSlipKitchen.Location = new System.Drawing.Point(4, 396);
            this.btnPrintSlipKitchen.Name = "btnPrintSlipKitchen";
            this.btnPrintSlipKitchen.Size = new System.Drawing.Size(145, 41);
            this.btnPrintSlipKitchen.TabIndex = 4;
            this.btnPrintSlipKitchen.Text = "Mutfağa Yaz";
            this.btnPrintSlipKitchen.UseVisualStyleBackColor = true;
            // 
            // btnSlipPrint
            // 
            this.btnSlipPrint.Location = new System.Drawing.Point(155, 396);
            this.btnSlipPrint.Name = "btnSlipPrint";
            this.btnSlipPrint.Size = new System.Drawing.Size(145, 41);
            this.btnSlipPrint.TabIndex = 4;
            this.btnSlipPrint.Text = "Adisyonu Yaz";
            this.btnSlipPrint.UseVisualStyleBackColor = true;
            // 
            // btnCloseSlip
            // 
            this.btnCloseSlip.Location = new System.Drawing.Point(4, 439);
            this.btnCloseSlip.Name = "btnCloseSlip";
            this.btnCloseSlip.Size = new System.Drawing.Size(145, 38);
            this.btnCloseSlip.TabIndex = 4;
            this.btnCloseSlip.Text = "Hesabı Kapat";
            this.btnCloseSlip.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.Location = new System.Drawing.Point(155, 444);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(145, 33);
            this.label1.TabIndex = 5;
            this.label1.Text = "0.00";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // ucSaleSlip
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnDecrement);
            this.Controls.Add(this.btnIncrement);
            this.Controls.Add(this.btnSlipPrint);
            this.Controls.Add(this.btnCloseSlip);
            this.Controls.Add(this.btnPrintSlipKitchen);
            this.Controls.Add(this.btnGift);
            this.Controls.Add(this.btnCancelSlip);
            this.Controls.Add(this.dgvProducts);
            this.Controls.Add(this.btnAddSaleser);
            this.Controls.Add(this.cmbTables);
            this.Controls.Add(this.splitter1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "ucSaleSlip";
            this.Size = new System.Drawing.Size(1024, 480);
            ((System.ComponentModel.ISupportInitialize)(this.dgvProducts)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox cmbTables;
        private System.Windows.Forms.Splitter splitter1;
        private System.Windows.Forms.Button btnAddSaleser;
        private System.Windows.Forms.DataGridView dgvProducts;
        private System.Windows.Forms.DataGridViewTextBoxColumn Product;
        private System.Windows.Forms.DataGridViewTextBoxColumn Price;
        private System.Windows.Forms.DataGridViewTextBoxColumn Quantity;
        private System.Windows.Forms.DataGridViewTextBoxColumn Amount;
        private System.Windows.Forms.DataGridViewButtonColumn Delete;
        private System.Windows.Forms.Button btnCancelSlip;
        private System.Windows.Forms.Button btnGift;
        private System.Windows.Forms.Button btnIncrement;
        private System.Windows.Forms.Button btnDecrement;
        private System.Windows.Forms.Button btnPrintSlipKitchen;
        private System.Windows.Forms.Button btnSlipPrint;
        private System.Windows.Forms.Button btnCloseSlip;
        private System.Windows.Forms.Label label1;

    }
}
