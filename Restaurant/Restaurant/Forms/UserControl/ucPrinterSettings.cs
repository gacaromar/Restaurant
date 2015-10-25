using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
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
            if (!string.IsNullOrEmpty(Settings.Default.GeneralPrinter))
                cbGeneral.SelectedIndex = cbGeneral.Items.IndexOf(Settings.Default.GeneralPrinter);
            if (!string.IsNullOrEmpty(Settings.Default.KitchenPrinter))
                cbKitchen.SelectedIndex = cbKitchen.Items.IndexOf(Settings.Default.KitchenPrinter);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Settings.Default.GeneralPrinter = cbGeneral.SelectedItem.ToString();
            Settings.Default.KitchenPrinter = cbKitchen.SelectedItem.ToString();
            Settings.Default.Save();
            MessageBox.Show("Yazıcı Ayarları Yapıldı.", "Yazıcı Ayarı", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Parent.Hide();
        }
    }
}
