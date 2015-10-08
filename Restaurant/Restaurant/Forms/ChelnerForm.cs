using System;
using System.Windows.Forms;
using Restaurant.DataClass;

namespace Restaurant.Forms
{
    public partial class ChelnerForm : Form
    {
        public int ChelnerId;
        public ChelnerForm()
        {
            InitializeComponent();
            var vList = Chelner.GetList();
            dgvChelner.DataSource = vList;
        }

        private void dgvChelner_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                if (e.ColumnIndex != 1)
                {
                    var vID = Convert.ToInt32(dgvChelner.Rows[e.RowIndex].Cells["Id"].Value.ToString());
                    ChelnerId = vID;
                    Close();
                }
            }
        }
    }
}
