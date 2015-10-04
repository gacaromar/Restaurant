using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Restaurant.DataClass
{
    [Serializable]
    public class Basket : DataAccess
    {
        #region Properties

        public int Id { get; set; }
        public Table Table { get; set; }
        public ProductGroup ProductGroup { get; set; }
        public Product Product { get; set; }
        public int Quantity { get; set; }
        public DateTime RecordDate { get; set; }
        public int Status { get; set; }

        #endregion

        #region Methods

        #endregion
    }
    public partial class DataAccessLayer
    {

    }
}
