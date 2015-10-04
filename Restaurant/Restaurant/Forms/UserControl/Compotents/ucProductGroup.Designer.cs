namespace Restaurant.Forms.UserControl.Compotents
{
    partial class ucProductGroup
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
            this.btnGroupName = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnGroupName
            // 
            this.btnGroupName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnGroupName.Location = new System.Drawing.Point(0, 0);
            this.btnGroupName.Margin = new System.Windows.Forms.Padding(4);
            this.btnGroupName.Name = "btnGroupName";
            this.btnGroupName.Size = new System.Drawing.Size(125, 35);
            this.btnGroupName.TabIndex = 0;
            this.btnGroupName.Text = "Ürün Grubu";
            this.btnGroupName.UseVisualStyleBackColor = true;
            // 
            // ucProductGroup
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.Controls.Add(this.btnGroupName);
            this.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximumSize = new System.Drawing.Size(125, 35);
            this.MinimumSize = new System.Drawing.Size(125, 35);
            this.Name = "ucProductGroup";
            this.Size = new System.Drawing.Size(125, 35);
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.Button btnGroupName;

    }
}
