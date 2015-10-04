namespace Restaurant.Forms.UserControl.Compotents
{
    public partial class ucProductGroup : System.Windows.Forms.UserControl
    {
        public string GroupName
        {
            get { return btnGroupName.Text; }
            set { btnGroupName.Text = value; }
        }
        public int GroupID { get; set; }
        public ucProductGroup()
        {
            InitializeComponent();
        }
    }
}
