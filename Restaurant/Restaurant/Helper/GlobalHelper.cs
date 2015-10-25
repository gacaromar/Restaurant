using System.Windows.Forms;

namespace Restaurant.Helper
{
    public static class GlobalHelper
    {
        public static Form OpenShowForm(Control pControl, FormBorderStyle pFormBorderStyle, FormStartPosition pFormStartPosition)
        {
            var frm = new Form();
            frm.Width = pControl.Width;
            frm.Height = pControl.Height;
            frm.FormBorderStyle = pFormBorderStyle;
            frm.StartPosition = pFormStartPosition;
            frm.Controls.Add(pControl);
            frm.ShowDialog();
            return frm;
        }

        public static void FormDispose(Form pForm)
        {
            pForm.Close();
            pForm.Dispose();
        }
    }
}
