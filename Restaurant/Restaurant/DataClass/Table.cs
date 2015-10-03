﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Restaurant.DataClass
{
    [Serializable]
    public class Table : DataAccess
    {
        public Table()
        {

        }
        public int Id { get; set; }
        public string Name { get; set; }
        public bool Active { get; set; }

    }

    public partial class DataAccessLayer
    {

    }
}