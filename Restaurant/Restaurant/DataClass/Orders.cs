using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Restaurant.DataClass
{
    public class Orders : DataAccess
    {
        #region Properties
        public int Id { get; set; }
        public Table Table { get; set; }
        public ProductGroup ProductGroup { get; set; }
        public Product Product { get; set; }
        public Chelner Chelner { get; set; }
        public double Price { get; set; }
        public int Quantity { get; set; }
        public double Total { get; set; }
        public DateTime RecordDate { get; set; }
        public double Discount { get; set; }
        public int Status { get; set; }
        #endregion
        #region Methods

        #endregion
    }
   
}
public partial class DataAccessLayer
{

}
