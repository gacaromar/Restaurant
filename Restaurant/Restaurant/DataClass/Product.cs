using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Restaurant.DataClass
{
    [Serializable]
  public class Product : DataAccess
    {
        #region Properties

        public int Id { get; set; }
        public ProductGroup ProductGroup { get; set; }
        public string ProductName { get; set; }
        public double SalesPrice { get; set; }
        public string CurrencyType { get; set; }
        public DateTime RecordDate { get; set; }
        public int Status { get; set; }

        #endregion

        #region Methods
        
        #endregion
    }
  
}
public partial class DataAccessLayer
{

}
