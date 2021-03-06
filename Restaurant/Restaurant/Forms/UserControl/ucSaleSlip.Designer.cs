﻿namespace Restaurant.Forms.UserControl
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblTotal = new System.Windows.Forms.Label();
            this.btnDecrement = new System.Windows.Forms.Button();
            this.btnIncrement = new System.Windows.Forms.Button();
            this.btnSlipPrint = new System.Windows.Forms.Button();
            this.btnCloseSlip = new System.Windows.Forms.Button();
            this.btnPrintSlipKitchen = new System.Windows.Forms.Button();
            this.btnGift = new System.Windows.Forms.Button();
            this.btnCancelSlip = new System.Windows.Forms.Button();
            this.dgvProducts = new System.Windows.Forms.DataGridView();
            this.btnAddSaleser = new System.Windows.Forms.Button();
            this.cmbTables = new System.Windows.Forms.ComboBox();
            this.gbGroups = new System.Windows.Forms.GroupBox();
            this.gbProducts = new System.Windows.Forms.GroupBox();
            this.pdDoc = new System.Drawing.Printing.PrintDocument();
            this.ProductName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Price = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Quantity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Discount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Sil = new System.Windows.Forms.DataGridViewButtonColumn();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProducts)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.lblTotal);
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
            // lblTotal
            // 
            this.lblTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblTotal.ForeColor = System.Drawing.Color.DarkGreen;
            this.lblTotal.Location = new System.Drawing.Point(156, 444);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(145, 33);
            this.lblTotal.TabIndex = 16;
            this.lblTotal.Text = "0.00";
            this.lblTotal.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btnDecrement
            // 
            this.btnDecrement.Location = new System.Drawing.Point(5, 367);
            this.btnDecrement.Name = "btnDecrement";
            this.btnDecrement.Size = new System.Drawing.Size(51, 23);
            this.btnDecrement.TabIndex = 9;
            this.btnDecrement.Text = "-0.5";
            this.btnDecrement.UseVisualStyleBackColor = true;
            this.btnDecrement.Click += new System.EventHandler(this.btnDecrement_Click);
            // 
            // btnIncrement
            // 
            this.btnIncrement.Location = new System.Drawing.Point(62, 367);
            this.btnIncrement.Name = "btnIncrement";
            this.btnIncrement.Size = new System.Drawing.Size(51, 23);
            this.btnIncrement.TabIndex = 10;
            this.btnIncrement.Text = "+0.5";
            this.btnIncrement.UseVisualStyleBackColor = true;
            this.btnIncrement.Click += new System.EventHandler(this.btnIncrement_Click_1);
            // 
            // btnSlipPrint
            // 
            this.btnSlipPrint.Location = new System.Drawing.Point(156, 396);
            this.btnSlipPrint.Name = "btnSlipPrint";
            this.btnSlipPrint.Size = new System.Drawing.Size(145, 41);
            this.btnSlipPrint.TabIndex = 11;
            this.btnSlipPrint.Text = "Adisyonu Yaz";
            this.btnSlipPrint.UseVisualStyleBackColor = true;
            this.btnSlipPrint.Click += new System.EventHandler(this.btnSlipPrint_Click);
            // 
            // btnCloseSlip
            // 
            this.btnCloseSlip.Location = new System.Drawing.Point(5, 439);
            this.btnCloseSlip.Name = "btnCloseSlip";
            this.btnCloseSlip.Size = new System.Drawing.Size(145, 38);
            this.btnCloseSlip.TabIndex = 12;
            this.btnCloseSlip.Text = "Hesabı Kapat";
            this.btnCloseSlip.UseVisualStyleBackColor = true;
            this.btnCloseSlip.Click += new System.EventHandler(this.btnCloseSlip_Click);
            // 
            // btnPrintSlipKitchen
            // 
            this.btnPrintSlipKitchen.Location = new System.Drawing.Point(5, 396);
            this.btnPrintSlipKitchen.Name = "btnPrintSlipKitchen";
            this.btnPrintSlipKitchen.Size = new System.Drawing.Size(145, 41);
            this.btnPrintSlipKitchen.TabIndex = 13;
            this.btnPrintSlipKitchen.Text = "Mutfağa Yaz";
            this.btnPrintSlipKitchen.UseVisualStyleBackColor = true;
            this.btnPrintSlipKitchen.Click += new System.EventHandler(this.btnPrintSlipKitchen_Click);
            // 
            // btnGift
            // 
            this.btnGift.Location = new System.Drawing.Point(119, 367);
            this.btnGift.Name = "btnGift";
            this.btnGift.Size = new System.Drawing.Size(75, 23);
            this.btnGift.TabIndex = 14;
            this.btnGift.Text = "İkram";
            this.btnGift.UseVisualStyleBackColor = true;
            this.btnGift.Click += new System.EventHandler(this.btnGift_Click);
            // 
            // btnCancelSlip
            // 
            this.btnCancelSlip.Location = new System.Drawing.Point(200, 367);
            this.btnCancelSlip.Name = "btnCancelSlip";
            this.btnCancelSlip.Size = new System.Drawing.Size(75, 23);
            this.btnCancelSlip.TabIndex = 15;
            this.btnCancelSlip.Text = "İptal";
            this.btnCancelSlip.UseVisualStyleBackColor = true;
            this.btnCancelSlip.Click += new System.EventHandler(this.btnCancelSlip_Click);
            // 
            // dgvProducts
            // 
            this.dgvProducts.AllowUserToAddRows = false;
            this.dgvProducts.AllowUserToOrderColumns = true;
            this.dgvProducts.AutoGenerateColumns = global::Restaurant.Properties.Settings.Default.dgvAutoGeneretaFalse;
            this.dgvProducts.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvProducts.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ProductName,
            this.Price,
            this.Quantity,
            this.Discount,
            this.Sil});
            this.dgvProducts.DataBindings.Add(new System.Windows.Forms.Binding("AutoGenerateColumns", global::Restaurant.Properties.Settings.Default, "dgvAutoGeneretaFalse", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.dgvProducts.Location = new System.Drawing.Point(5, 36);
            this.dgvProducts.Name = "dgvProducts";
            this.dgvProducts.Size = new System.Drawing.Size(301, 325);
            this.dgvProducts.TabIndex = 8;
            this.dgvProducts.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvProducts_CellContentClick);
            this.dgvProducts.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvProducts_CellEndEdit);
            this.dgvProducts.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvProducts_CellFormatting);
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
            this.btnAddSaleser.Click += new System.EventHandler(this.btnAddSaleser_Click);
            // 
            // cmbTables
            // 
            this.cmbTables.DisplayMember = "TableName";
            this.cmbTables.FormattingEnabled = true;
            this.cmbTables.Location = new System.Drawing.Point(5, 4);
            this.cmbTables.Margin = new System.Windows.Forms.Padding(4);
            this.cmbTables.Name = "cmbTables";
            this.cmbTables.Size = new System.Drawing.Size(160, 24);
            this.cmbTables.TabIndex = 6;
            this.cmbTables.ValueMember = "Id";
            this.cmbTables.SelectedIndexChanged += new System.EventHandler(this.cmbTables_SelectedIndexChanged);
            // 
            // gbGroups
            // 
            this.gbGroups.Location = new System.Drawing.Point(311, 0);
            this.gbGroups.Name = "gbGroups";
            this.gbGroups.Size = new System.Drawing.Size(713, 112);
            this.gbGroups.TabIndex = 8;
            this.gbGroups.TabStop = false;
            this.gbGroups.Text = "Ürün Grupları";
            // 
            // gbProducts
            // 
            this.gbProducts.Location = new System.Drawing.Point(311, 112);
            this.gbProducts.Name = "gbProducts";
            this.gbProducts.Size = new System.Drawing.Size(713, 368);
            this.gbProducts.TabIndex = 8;
            this.gbProducts.TabStop = false;
            this.gbProducts.Text = "Ürünler";
            // 
            // ProductName
            // 
            this.ProductName.DataPropertyName = "Product.ProductName";
            this.ProductName.HeaderText = "Ürün";
            this.ProductName.Name = "ProductName";
            this.ProductName.ReadOnly = true;
            // 
            // Price
            // 
            this.Price.DataPropertyName = "Product.SalesPrice";
            this.Price.HeaderText = "Fiyatı";
            this.Price.Name = "Price";
            this.Price.ReadOnly = true;
            // 
            // Quantity
            // 
            this.Quantity.DataPropertyName = "Quantity";
            this.Quantity.HeaderText = "Mik.";
            this.Quantity.Name = "Quantity";
            // 
            // Discount
            // 
            this.Discount.DataPropertyName = "Discount";
            this.Discount.HeaderText = "İndirim";
            this.Discount.Name = "Discount";
            // 
            // Sil
            // 
            this.Sil.HeaderText = "Sil";
            this.Sil.Name = "Sil";
            this.Sil.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Sil.Text = "Sil";
            this.Sil.ToolTipText = "Sil";
            this.Sil.UseColumnTextForButtonValue = true;
            // 
            // ucSaleSlip
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gbProducts);
            this.Controls.Add(this.gbGroups);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "ucSaleSlip";
            this.Size = new System.Drawing.Size(1024, 480);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvProducts)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.Button btnDecrement;
        private System.Windows.Forms.Button btnIncrement;
        private System.Windows.Forms.Button btnSlipPrint;
        private System.Windows.Forms.Button btnCloseSlip;
        private System.Windows.Forms.Button btnPrintSlipKitchen;
        private System.Windows.Forms.Button btnGift;
        private System.Windows.Forms.Button btnCancelSlip;
        private System.Windows.Forms.DataGridView dgvProducts;
        private System.Windows.Forms.Button btnAddSaleser;
        private System.Windows.Forms.ComboBox cmbTables;
        private System.Windows.Forms.GroupBox gbGroups;
        private System.Windows.Forms.GroupBox gbProducts;
        private System.Drawing.Printing.PrintDocument pdDoc;
        private System.Windows.Forms.DataGridViewTextBoxColumn ProductName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Price;
        private System.Windows.Forms.DataGridViewTextBoxColumn Quantity;
        private System.Windows.Forms.DataGridViewTextBoxColumn Discount;
        private System.Windows.Forms.DataGridViewButtonColumn Sil;

    }
}
