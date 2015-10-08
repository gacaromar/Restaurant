namespace Restaurant.Forms
{
    partial class ChelnerForm
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
            this.dgvChelner = new System.Windows.Forms.DataGridView();
            this.ChelnerName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvChelner)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvChelner
            // 
            this.dgvChelner.AllowUserToAddRows = false;
            this.dgvChelner.AutoGenerateColumns = global::Restaurant.Properties.Settings.Default.dgvAutoGeneretaFalse;
            this.dgvChelner.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvChelner.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ChelnerName,
            this.Id});
            this.dgvChelner.DataBindings.Add(new System.Windows.Forms.Binding("AutoGenerateColumns", global::Restaurant.Properties.Settings.Default, "dgvAutoGeneretaFalse", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.dgvChelner.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvChelner.Location = new System.Drawing.Point(0, 0);
            this.dgvChelner.Name = "dgvChelner";
            this.dgvChelner.Size = new System.Drawing.Size(184, 261);
            this.dgvChelner.TabIndex = 0;
            this.dgvChelner.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvChelner_CellDoubleClick);
            // 
            // ChelnerName
            // 
            this.ChelnerName.DataPropertyName = "ChelnerName";
            this.ChelnerName.HeaderText = "Garson";
            this.ChelnerName.Name = "ChelnerName";
            this.ChelnerName.ReadOnly = true;
            // 
            // Id
            // 
            this.Id.DataPropertyName = "Id";
            this.Id.HeaderText = "Id";
            this.Id.Name = "Id";
            this.Id.ReadOnly = true;
            this.Id.Visible = false;
            // 
            // ChelnerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(184, 261);
            this.Controls.Add(this.dgvChelner);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(200, 300);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(200, 300);
            this.Name = "ChelnerForm";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Garsonlar";
            ((System.ComponentModel.ISupportInitialize)(this.dgvChelner)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvChelner;
        private System.Windows.Forms.DataGridViewTextBoxColumn ChelnerName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Id;
    }
}