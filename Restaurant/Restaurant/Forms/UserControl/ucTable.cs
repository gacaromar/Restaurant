using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Restaurant.Forms.UserControl
{
    public partial class ucTable : System.Windows.Forms.UserControl
    {
        public int TableID { get; set; }
        public string TableName { get; set; }
        public bool TableActive { get; set; }
        public ucTable()
        {
            InitializeComponent();
        }
    }
}
