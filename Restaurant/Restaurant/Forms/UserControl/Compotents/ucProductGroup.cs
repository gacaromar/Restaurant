using Restaurant.DataClass;

namespace Restaurant.Forms.UserControl.Compotents
{
    public partial class ucProductGroup : System.Windows.Forms.UserControl
    {
        public Product Product { get; set; }
        public ProductGroup ProductGroup { get; set; }
        public string Text
        {
            set { btnGroupName.Text = value; }
        }
        public ucProductGroup()
        {
            InitializeComponent();
        }
    }
}
