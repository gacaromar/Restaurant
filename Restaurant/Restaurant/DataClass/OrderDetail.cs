using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using Utilities;

namespace Restaurant.DataClass
{
     [Serializable]
   public class OrderDetail : DataAccess
    {

        #region Properties
        public int Id { get; set; }
        public Orders Orders { get; set; }
        public ProductGroup ProductGroup { get; set; }
        public Product Product { get; set; }
        public double  Price { get; set; }
        public string Currency { get; set; }
        public double Quantity { get; set; }
        public double Discount { get; set; }
        public double Total { get; set; }


        #endregion

        #region Methods

        public static void InsertOrderDetail(int pOrderId, int pProductGroupId,int pProductId,double pPrice,string pCurrency, double pQuantity,double pDiscount, double pTotal)
        {
             DAL.InsertOrderDetail(pOrderId, pProductGroupId,pProductId,pPrice,pCurrency, pQuantity,pDiscount, pTotal);
        }

        #endregion
    }
  

}

public partial class DataAccessLayer
{
    public void InsertOrderDetail(int pOrderId, int pProductGroupId, int pProductId, double pPrice, string pCurrency, double pQuantity, double pDiscount, double pTotal)
    {
        try
        {
            UtilMySqlHelper.ExecuteNonQuery(conString, CommandType.StoredProcedure, SpNameCollection.InsertOrderDetail,
                 MySQLParameterGeneratorEx.GenerateParam(((MethodInfo)MethodBase.GetCurrentMethod()).GetParameters(), pOrderId, pProductGroupId, pProductId, pPrice, pCurrency, pQuantity, pDiscount, pTotal));

        }
        catch (Exception ex)
        {
        }
    }

}
