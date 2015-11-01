using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Restaurant.DataClass;
using Restaurant.Properties;

namespace Restaurant.Forms.UserControl
{
    public partial class ucPrinterSettings : System.Windows.Forms.UserControl
    {
        public ucPrinterSettings()
        {
            InitializeComponent();
            foreach (string printer in System.Drawing.Printing.PrinterSettings.InstalledPrinters)
            {
                cbGeneral.Items.Add(printer);
                cbKitchen.Items.Add(printer);
            }
            var vPrinters = MySettings.GetListPrinter();
            if (vPrinters.Count == 0) return;

            if (!string.IsNullOrEmpty(vPrinters[0].Value))
                cbGeneral.SelectedIndex = cbGeneral.Items.IndexOf(vPrinters[0].Value);
            if (!string.IsNullOrEmpty(vPrinters[1].Value))
                cbKitchen.SelectedIndex = cbKitchen.Items.IndexOf(vPrinters[1].Value);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MySettings.AddPrinter("1", cbGeneral.SelectedItem.ToString());
            MySettings.AddPrinter("2", cbKitchen.SelectedItem.ToString());
            MessageBox.Show("Yazıcı Ayarları Yapıldı.", "Yazıcı Ayarı", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Parent.Hide();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Parent.Hide();
        }
    }
}
