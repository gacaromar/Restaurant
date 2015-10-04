﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Restaurant.DataClass;
using Restaurant.Forms.UserControl.Compotents;

namespace Restaurant.Forms.UserControl
{
    public partial class ucProductGroups : System.Windows.Forms.UserControl
    {
        public ucProductGroups()
        {
            InitializeComponent();
        }

        public bool SetGroups(List<ProductGroup> pSource, EventHandler btnProductGroupClick)
        {
            int row = -1;
            for (int i = 0, j = 0; i < pSource.Count; i++, j++)
            {
                var tbl = new ucProductGroup();
                tbl.GroupID = pSource[i].Id;
                tbl.GroupName = pSource[i].ProductGroupName;
                tbl.btnGroupName.Click += btnProductGroupClick;
                if (i % 5 == 0)
                {
                    j = 0; row++;
                }
                tbl.Left = 5 + (125 * j);
                tbl.Top = 5 + 35 * row;
                this.Controls.Add(tbl);
            }
            return true;
        }
    }
}