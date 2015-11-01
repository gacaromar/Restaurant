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
    public class Product : DataAccess
    {
        #region Properties

        public int Id { get; set; }
        public ProductGroup ProductGroup { get; set; }
        public string ProductGroupNameForProduct { get { return ProductGroup.ProductGroupName; } }
        public string ProductName { get; set; }
        public double SalesPrice { get; set; }

        public string ProductNameSalesPrice
        {
            get { return ProductName + "\n(" + SalesPrice.ToString("N2") + " TL)"; }
        }

        public string CurrencyType { get; set; }
        public DateTime RecordDate { get; set; }
        public int Status { get; set; }

        #endregion

        #region Methods

        public static List<Product> GetProductByProductGroupId(int productGroupId)
        {
            List<Product> list = new List<Product>();
            DataTable dt = DAL.GetProductByProductGroupId(productGroupId);

            foreach (DataRow row in dt.Rows)
            {
                Product item = new Product()
                {
                    Id = row.Field<int>("Id"),
                    ProductGroup = new ProductGroup()
                    {
                        Id = row.Field<int>("ProductGroupId"),
                    },
                    SalesPrice = row.Field<double>("SalesPrice"),
                    CurrencyType = row.Field<string>("CurrencyType"),
                    ProductName = row.Field<string>("Name"),
                    RecordDate = row.Field<DateTime>("RecordDate")

                };
                list.Add(item);
            }

            return list;
        }

        public static List<Product> GetProductByAll()
        {
            List<Product> list = new List<Product>();
            DataTable dt = DAL.GetProductByAll();

            foreach (DataRow row in dt.Rows)
            {
                Product item = new Product()
                {
                    Id = row.Field<int>("Id"),
                    ProductGroup = new ProductGroup()
                    {
                        Id = row.Field<int>("ProductGroupId"),
                        ProductGroupName = row.Field<string>("ProductGroupName")
                    },
                    SalesPrice = row.Field<double>("SalesPrice"),
                    CurrencyType = row.Field<string>("CurrencyType"),
                    ProductName = row.Field<string>("Name"),
                    RecordDate = row.Field<DateTime>("RecordDate")

                };
                list.Add(item);
            }

            return list;
        }

        #endregion

        public static int InsertProduct(int pProductGroupId, string pName, double pPrice, string pCurrency)
        {
            var dt = DAL.InsertProduct(pProductGroupId, pName, pPrice, pCurrency);
            return dt.Rows.Count;
        }

        public void Update()
        {
            DAL.UpdateProduct(Id, ProductName, SalesPrice);
        }

        public void Delete()
        {
            DAL.DeleteProduct(Id);
        }
    }

}
public partial class DataAccessLayer
{

    public DataTable GetProductByAll()
    {
        try
        {
            return UtilMySqlHelper.ExecuteDataTable(conString, CommandType.StoredProcedure, SpNameCollection.GetProductByAll,
                MySQLParameterGeneratorEx.GenerateParam(((MethodInfo)MethodBase.GetCurrentMethod()).GetParameters()));
        }
        catch (Exception ex)
        {
            return new DataTable();
        }
    }

    public DataTable GetProductByProductGroupId(int pProductGroupId)
    {
        try
        {
            return UtilMySqlHelper.ExecuteDataTable(conString, CommandType.StoredProcedure, SpNameCollection.GetProductByProductGroupId,
                MySQLParameterGeneratorEx.GenerateParam(((MethodInfo)MethodBase.GetCurrentMethod()).GetParameters(), pProductGroupId));
        }
        catch (Exception ex)
        {
            return new DataTable();
        }
    }

    public DataTable InsertProduct(int pProductGroupId, string pName, double pPrice, string pCurrency)
    {
        try
        {
            return UtilMySqlHelper.ExecuteDataTable(conString, CommandType.StoredProcedure,
                SpNameCollection.InsertProduct,
                MySQLParameterGeneratorEx.GenerateParam(((MethodInfo)MethodBase.GetCurrentMethod()).GetParameters(),
                    pProductGroupId, pName, pPrice, pCurrency));
        }
        catch (Exception ex)
        {
            return new DataTable();
        }
    }

    public void UpdateProduct(int pId, string pProductName, double pPrice)
    {
        try
        {
            UtilMySqlHelper.ExecuteNonQuery(conString, CommandType.StoredProcedure,
                SpNameCollection.UpdateProduct,
                MySQLParameterGeneratorEx.GenerateParam(((MethodInfo)MethodBase.GetCurrentMethod()).GetParameters(),
                    pId, pProductName, pPrice));
        }
        catch (Exception ex)
        {
        }
    }

    public void DeleteProduct(int pId)
    {
        try
        {
            UtilMySqlHelper.ExecuteNonQuery(conString, CommandType.StoredProcedure,
                SpNameCollection.DeleteProduct,
                MySQLParameterGeneratorEx.GenerateParam(((MethodInfo)MethodBase.GetCurrentMethod()).GetParameters(),
                    pId));
        }
        catch (Exception ex)
        {
        }
    }
}
