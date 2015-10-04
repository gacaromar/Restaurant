using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Restaurant.DataClass
{
    public class ProductGroup : DataAccess
    {
        #region Properties

        public int Id { get; set; }
        public string ProductGroupName { get; set; }
        public int Status { get; set; }
        public DateTime RecordDate { get; set; }
        #endregion

        #region Methods
        
        #endregion

    }
   
}
public partial class DataAccessLayer
{

}
