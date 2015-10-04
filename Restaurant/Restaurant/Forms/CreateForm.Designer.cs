namespace Restaurant.Forms
{
    partial class CreateForm
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tb1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnSaveTable = new System.Windows.Forms.Button();
            this.tbTableName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.dtProductGroup = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.btnSaveProductGroup = new System.Windows.Forms.Button();
            this.tbProductGroup = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.dtProduct = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ProductName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SalesPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CurrencyType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.cmbProductGroup = new System.Windows.Forms.ComboBox();
            this.button1 = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.tbProductName = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.dtChelner = new System.Windows.Forms.DataGridView();
            this.ChelnerName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.btnSaveChelner = new System.Windows.Forms.Button();
            this.tbChelnerName = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.dtTables = new System.Windows.Forms.DataGridView();
            this.TableName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tb1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtProductGroup)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtProduct)).BeginInit();
            this.groupBox4.SuspendLayout();
            this.tabPage4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtChelner)).BeginInit();
            this.groupBox5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtTables)).BeginInit();
            this.SuspendLayout();
            // 
            // tb1
            // 
            this.tb1.Controls.Add(this.tabPage1);
            this.tb1.Controls.Add(this.tabPage2);
            this.tb1.Controls.Add(this.tabPage3);
            this.tb1.Controls.Add(this.tabPage4);
            this.tb1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tb1.Location = new System.Drawing.Point(0, 0);
            this.tb1.Name = "tb1";
            this.tb1.SelectedIndex = 0;
            this.tb1.Size = new System.Drawing.Size(878, 408);
            this.tb1.TabIndex = 0;
            this.tb1.Tag = "";
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.groupBox2);
            this.tabPage1.Controls.Add(this.groupBox1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(870, 382);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Masa Ekle";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dtTables);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(3, 121);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(864, 258);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Masalar";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnSaveTable);
            this.groupBox1.Controls.Add(this.tbTableName);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(864, 118);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Masa Ekle";
            // 
            // btnSaveTable
            // 
            this.btnSaveTable.Location = new System.Drawing.Point(391, 71);
            this.btnSaveTable.Name = "btnSaveTable";
            this.btnSaveTable.Size = new System.Drawing.Size(75, 23);
            this.btnSaveTable.TabIndex = 2;
            this.btnSaveTable.Text = "Kaydet";
            this.btnSaveTable.UseVisualStyleBackColor = true;
            this.btnSaveTable.Click += new System.EventHandler(this.btnSaveTable_Click);
            // 
            // tbTableName
            // 
            this.tbTableName.Location = new System.Drawing.Point(127, 31);
            this.tbTableName.Name = "tbTableName";
            this.tbTableName.Size = new System.Drawing.Size(339, 20);
            this.tbTableName.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(29, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Masa Adı";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.dtProductGroup);
            this.tabPage2.Controls.Add(this.groupBox3);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(870, 382);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Ürün Grubu Ekle";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // dtProductGroup
            // 
            this.dtProductGroup.AllowUserToAddRows = false;
            this.dtProductGroup.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtProductGroup.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1});
            this.dtProductGroup.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtProductGroup.Location = new System.Drawing.Point(3, 121);
            this.dtProductGroup.Name = "dtProductGroup";
            this.dtProductGroup.Size = new System.Drawing.Size(864, 258);
            this.dtProductGroup.TabIndex = 1;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.FillWeight = 300F;
            this.dataGridViewTextBoxColumn1.HeaderText = "Ürün Grubu Adı";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.Width = 300;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.btnSaveProductGroup);
            this.groupBox3.Controls.Add(this.tbProductGroup);
            this.groupBox3.Controls.Add(this.label2);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox3.Location = new System.Drawing.Point(3, 3);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(864, 118);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Ürün Grubu Ekle";
            // 
            // btnSaveProductGroup
            // 
            this.btnSaveProductGroup.Location = new System.Drawing.Point(391, 71);
            this.btnSaveProductGroup.Name = "btnSaveProductGroup";
            this.btnSaveProductGroup.Size = new System.Drawing.Size(75, 23);
            this.btnSaveProductGroup.TabIndex = 2;
            this.btnSaveProductGroup.Text = "Kaydet";
            this.btnSaveProductGroup.UseVisualStyleBackColor = true;
            // 
            // tbProductGroup
            // 
            this.tbProductGroup.Location = new System.Drawing.Point(127, 31);
            this.tbProductGroup.Name = "tbProductGroup";
            this.tbProductGroup.Size = new System.Drawing.Size(339, 20);
            this.tbProductGroup.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(29, 34);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(62, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Ürün Grubu";
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.dtProduct);
            this.tabPage3.Controls.Add(this.groupBox4);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(870, 382);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Ürün Ekle";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // dtProduct
            // 
            this.dtProduct.AllowUserToAddRows = false;
            this.dtProduct.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtProduct.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn2,
            this.ProductName,
            this.SalesPrice,
            this.CurrencyType});
            this.dtProduct.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtProduct.Location = new System.Drawing.Point(3, 140);
            this.dtProduct.Name = "dtProduct";
            this.dtProduct.Size = new System.Drawing.Size(864, 239);
            this.dtProduct.TabIndex = 3;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.FillWeight = 300F;
            this.dataGridViewTextBoxColumn2.HeaderText = "Ürün Grubu Adı";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            this.dataGridViewTextBoxColumn2.Width = 300;
            // 
            // ProductName
            // 
            this.ProductName.HeaderText = "Ürün Adı";
            this.ProductName.Name = "ProductName";
            this.ProductName.ReadOnly = true;
            // 
            // SalesPrice
            // 
            this.SalesPrice.HeaderText = "Ürün Fiyatı";
            this.SalesPrice.Name = "SalesPrice";
            this.SalesPrice.ReadOnly = true;
            // 
            // CurrencyType
            // 
            this.CurrencyType.HeaderText = "Döviz Tipi";
            this.CurrencyType.Name = "CurrencyType";
            this.CurrencyType.ReadOnly = true;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.comboBox1);
            this.groupBox4.Controls.Add(this.cmbProductGroup);
            this.groupBox4.Controls.Add(this.button1);
            this.groupBox4.Controls.Add(this.textBox1);
            this.groupBox4.Controls.Add(this.tbProductName);
            this.groupBox4.Controls.Add(this.label4);
            this.groupBox4.Controls.Add(this.label3);
            this.groupBox4.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox4.Location = new System.Drawing.Point(3, 3);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(864, 137);
            this.groupBox4.TabIndex = 4;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Ürün Ekle";
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "TL"});
            this.comboBox1.Location = new System.Drawing.Point(483, 65);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(235, 21);
            this.comboBox1.TabIndex = 3;
            // 
            // cmbProductGroup
            // 
            this.cmbProductGroup.FormattingEnabled = true;
            this.cmbProductGroup.Location = new System.Drawing.Point(127, 32);
            this.cmbProductGroup.Name = "cmbProductGroup";
            this.cmbProductGroup.Size = new System.Drawing.Size(339, 21);
            this.cmbProductGroup.TabIndex = 3;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(643, 108);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 2;
            this.button1.Text = "Kaydet";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(483, 33);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(235, 20);
            this.textBox1.TabIndex = 1;
            // 
            // tbProductName
            // 
            this.tbProductName.Location = new System.Drawing.Point(127, 70);
            this.tbProductName.Name = "tbProductName";
            this.tbProductName.Size = new System.Drawing.Size(339, 20);
            this.tbProductName.TabIndex = 1;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(29, 32);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(62, 13);
            this.label4.TabIndex = 0;
            this.label4.Text = "Ürün Grubu";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(29, 73);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(48, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "Ürün Adı";
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.dtChelner);
            this.tabPage4.Controls.Add(this.groupBox5);
            this.tabPage4.Location = new System.Drawing.Point(4, 22);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage4.Size = new System.Drawing.Size(870, 382);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "Garson Ekle";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // dtChelner
            // 
            this.dtChelner.AllowUserToAddRows = false;
            this.dtChelner.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtChelner.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ChelnerName});
            this.dtChelner.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtChelner.Location = new System.Drawing.Point(3, 121);
            this.dtChelner.Name = "dtChelner";
            this.dtChelner.Size = new System.Drawing.Size(864, 258);
            this.dtChelner.TabIndex = 3;
            // 
            // ChelnerName
            // 
            this.ChelnerName.FillWeight = 300F;
            this.ChelnerName.HeaderText = "Garson Adı";
            this.ChelnerName.Name = "ChelnerName";
            this.ChelnerName.ReadOnly = true;
            this.ChelnerName.Width = 300;
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.btnSaveChelner);
            this.groupBox5.Controls.Add(this.tbChelnerName);
            this.groupBox5.Controls.Add(this.label5);
            this.groupBox5.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox5.Location = new System.Drawing.Point(3, 3);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(864, 118);
            this.groupBox5.TabIndex = 4;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Garson Ekle";
            // 
            // btnSaveChelner
            // 
            this.btnSaveChelner.Location = new System.Drawing.Point(391, 71);
            this.btnSaveChelner.Name = "btnSaveChelner";
            this.btnSaveChelner.Size = new System.Drawing.Size(75, 23);
            this.btnSaveChelner.TabIndex = 2;
            this.btnSaveChelner.Text = "Kaydet";
            this.btnSaveChelner.UseVisualStyleBackColor = true;
            // 
            // tbChelnerName
            // 
            this.tbChelnerName.Location = new System.Drawing.Point(127, 31);
            this.tbChelnerName.Name = "tbChelnerName";
            this.tbChelnerName.Size = new System.Drawing.Size(339, 20);
            this.tbChelnerName.TabIndex = 1;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(29, 34);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(59, 13);
            this.label5.TabIndex = 0;
            this.label5.Text = "Garson Adı";
            // 
            // dtTables
            // 
            this.dtTables.AllowUserToAddRows = false;
            this.dtTables.AllowUserToOrderColumns = true;
            this.dtTables.AutoGenerateColumns = global::Restaurant.Properties.Settings.Default.datagiridFalse;
            this.dtTables.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtTables.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.TableName});
            this.dtTables.DataBindings.Add(new System.Windows.Forms.Binding("AutoGenerateColumns", global::Restaurant.Properties.Settings.Default, "datagiridFalse", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.dtTables.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtTables.Location = new System.Drawing.Point(3, 16);
            this.dtTables.Name = "dtTables";
            this.dtTables.ReadOnly = true;
            this.dtTables.Size = new System.Drawing.Size(858, 239);
            this.dtTables.TabIndex = 0;
            // 
            // TableName
            // 
            this.TableName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.TableName.HeaderText = "Masa Adı";
            this.TableName.Name = "TableName";
            this.TableName.ReadOnly = true;
            // 
            // CreateForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(878, 408);
            this.Controls.Add(this.tb1);
            this.Name = "CreateForm";
            this.Text = "Kayıt Formu";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.tb1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtProductGroup)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtProduct)).EndInit();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.tabPage4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtChelner)).EndInit();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtTables)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tb1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnSaveTable;
        private System.Windows.Forms.TextBox tbTableName;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView dtProductGroup;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button btnSaveProductGroup;
        private System.Windows.Forms.TextBox tbProductGroup;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridView dtProduct;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox tbProductName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cmbProductGroup;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn ProductName;
        private System.Windows.Forms.DataGridViewTextBoxColumn SalesPrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn CurrencyType;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.DataGridView dtChelner;
        private System.Windows.Forms.DataGridViewTextBoxColumn ChelnerName;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.Button btnSaveChelner;
        private System.Windows.Forms.TextBox tbChelnerName;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DataGridView dtTables;
        private System.Windows.Forms.DataGridViewTextBoxColumn TableName;
    }
}