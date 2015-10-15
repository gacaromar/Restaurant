using System;
using System.Diagnostics;
namespace Restaurant.Forms.UserControl
{
    public partial class ucQuantity : System.Windows.Forms.UserControl
    {
        public ucQuantity()
        {
            InitializeComponent();
           
        }

        private void btnOk_Click(object sender, System.EventArgs e)
        {
            Parent.Hide();
        }
        
    }
}
