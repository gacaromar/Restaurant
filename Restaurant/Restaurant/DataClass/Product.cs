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
        public string ProductName { get; set; }
        public double SalesPrice { get; set; }

        public string ProductNameSalesPrice
        {
            get { return ProductName + "\n(" + SalesPrice.ToString("N2") +" TL)"; }
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
}
