using System;
using System.Reflection;
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

        private void dgvChelner_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if ((dgvChelner.Rows[e.RowIndex].DataBoundItem != null) &&
                (dgvChelner.Columns[e.ColumnIndex].DataPropertyName.Contains(".")))
            {
                e.Value = BindProperty(
                    dgvChelner.Rows[e.RowIndex].DataBoundItem,
                    dgvChelner.Columns[e.ColumnIndex].DataPropertyName
                    );
            }
        }
        private string BindProperty(object property, string propertyName)
        {
            string retValue = "";

            if (propertyName.Contains("."))
            {
                var leftPropertyName = propertyName.Substring(0, propertyName.IndexOf(".", StringComparison.Ordinal));
                var arrayProperties = property.GetType().GetProperties();

                foreach (PropertyInfo propertyInfo in arrayProperties)
                {
                    if (propertyInfo.Name == leftPropertyName)
                    {
                        retValue = BindProperty(
                          propertyInfo.GetValue(property, null),
                          propertyName.Substring(propertyName.IndexOf(".", StringComparison.Ordinal) + 1));
                        break;
                    }
                }
            }
            else
            {
                var propertyType = property.GetType();
                var propertyInfo = propertyType.GetProperty(propertyName);
                retValue = propertyInfo.GetValue(property, null).ToString();
            }

            return retValue;
        }

    }
}
