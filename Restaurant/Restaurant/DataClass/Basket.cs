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
    public class Basket : DataAccess
    {
        #region Properties

        public int Id { get; set; }
        public Table Table { get; set; }
        public ProductGroup ProductGroup { get; set; }
        public Product Product { get; set; }
        public double Quantity { get; set; }
        public double Discount { get; set; }
        public DateTime RecordDate { get; set; }
        public int Status { get; set; }
        public Chelner Chelner { get; set; }
        public double Total { get { return Product.SalesPrice * Quantity * (1- (Discount/100)); } }
        #endregion

        #region Methods

       

        public static List<Basket> GetBasketList(int pTableId)
        {
            var dt = DAL.GetBasketList(pTableId);
            var vList = new List<Basket>();
            foreach (DataRow dr in dt.Rows)
            {
                var vBasket = new Basket();
                vBasket.Product = new Product
                {
                    Id = dr.Field<int>("ProductId"),
                    ProductName = dr.Field<string>("ProductName"),
                    SalesPrice = dr.Field<double>("SalesPrice")
                };
                vBasket.Chelner = new Chelner { Id = dr.Field<int>("ChelnerId") };
                vBasket.Id = dr.Field<int>("Id");
                vBasket.Discount = dr.Field<double>("Discount");
                vBasket.ProductGroup = new ProductGroup { Id = dr.Field<int>("ProductGroupId") };
                vBasket.Quantity = dr.Field<double>("Quantity");
                vBasket.RecordDate = dr.Field<DateTime>("RecordDate");
                vBasket.Table = new Table { Id = dr.Field<int>("TableId") };
                vList.Add(vBasket);
            }
            return vList;
        }

        public static int InsertBasket(int pTableId, int pProductGroupId, int pChelnerId, int pProductId, double pDiscount, double pQuantity)
        {
            var dt = DAL.InsertBasket(pTableId, pProductGroupId, pChelnerId, pProductId, pDiscount, pQuantity);
            if (dt.Rows.Count == 0) return -1;
            return Convert.ToInt32(dt.Rows[0][0]);
        }

        public static int Update(int pTableId, int pProductId, double pQuantity,double pDiscount = 0)
        {
            return DAL.UpdateBasket(pTableId, pProductId, pQuantity, pDiscount);
        }

        public static void UpdateBasketWithOrder(int pId, int pOrderId)
        {
             DAL.UpdateBasketWithOrder(pId, pOrderId);
        }

        public static void DeleteBasket(int pTableId)
        {
            DAL.DeleteBasket(pTableId);
        }

        public static void DeleteBasketItem(int pId,int pTableId)
        {
            DAL.DeleteBasketItem(pId, pTableId);
        }

        #endregion
    }

}
public partial class DataAccessLayer
{

    public DataTable GetBasketList(int pTableId)
    {
        try
        {
            return UtilMySqlHelper.ExecuteDataTable(conString, CommandType.StoredProcedure, SpNameCollection.GetBasketList,
                MySQLParameterGeneratorEx.GenerateParam(((MethodInfo)MethodBase.GetCurrentMethod()).GetParameters(), pTableId));
        }
        catch (Exception ex)
        {
            return new DataTable();
        }
    }
    public DataTable InsertBasket(int pTableId, int pProductGroupId, int pChelnerId, int pProductId, double pDiscount, double pQuantity)
    {
        try
        {
            return UtilMySqlHelper.ExecuteDataTable(conString, CommandType.StoredProcedure, SpNameCollection.InsertBasket,
                MySQLParameterGeneratorEx.GenerateParam(((MethodInfo)MethodBase.GetCurrentMethod()).GetParameters(), pTableId, pProductGroupId, pChelnerId, pProductId, pDiscount, pQuantity));
        }
        catch (Exception ex)
        {
            return new DataTable();
        }
    }

    public int UpdateBasket(int pTableId, int pProductId, double pQuantity, double pDiscount)
    {
        try
        {
            UtilMySqlHelper.ExecuteNonQuery(conString, CommandType.StoredProcedure, SpNameCollection.UpdateBasket,
                 MySQLParameterGeneratorEx.GenerateParam(((MethodInfo)MethodBase.GetCurrentMethod()).GetParameters(), pTableId, pProductId, pQuantity, pDiscount));
            return 1;
        }
        catch (Exception ex)
        {
            return -1;
        }
    }

    public void UpdateBasketWithOrder(int pId, int pOrderId)
    {
        try
        {
            UtilMySqlHelper.ExecuteNonQuery(conString, CommandType.StoredProcedure, SpNameCollection.UpdateBasketWithOrder,
                 MySQLParameterGeneratorEx.GenerateParam(((MethodInfo)MethodBase.GetCurrentMethod()).GetParameters(), pId, pOrderId));
            
        }
        catch (Exception ex)
        {
        }
    }


    public void DeleteBasket(int pTableId)
    {
        try
        {
            UtilMySqlHelper.ExecuteNonQuery(conString, CommandType.StoredProcedure, SpNameCollection.DeleteBasket,
                 MySQLParameterGeneratorEx.GenerateParam(((MethodInfo)MethodBase.GetCurrentMethod()).GetParameters(), pTableId));
            
        }
        catch (Exception ex)
        {
        }
    }

    public void DeleteBasketItem(int pId,int pTableId)
    {
        try
        {
            UtilMySqlHelper.ExecuteNonQuery(conString, CommandType.StoredProcedure, SpNameCollection.DeleteBasketItem,
                 MySQLParameterGeneratorEx.GenerateParam(((MethodInfo)MethodBase.GetCurrentMethod()).GetParameters(), pId, pTableId));
            
        }
        catch (Exception ex)
        {
        }
    }

}
