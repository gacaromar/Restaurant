using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using Utilities;

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
        public static List<ProductGroup> GetAllProductGroups()
        {
            List<ProductGroup> list = new List<ProductGroup>();
            DataTable dt = DAL.GetAllProductGroups();

            foreach (DataRow row in dt.Rows)
            {
                ProductGroup item = new ProductGroup()
                {
                    Id = row.Field<int>("Id"),
                    ProductGroupName = row.Field<string>("Name"),
                    RecordDate = row.Field<DateTime>("RecordDate")

                };
                list.Add(item);
            }

            return list;
        }

        public bool Save()
        {
            return DAL.InsertProductGroup(ProductGroupName);
        }

        public bool Update()
        {
            return DAL.UpdateProductGroup(Id, ProductGroupName);
        }

        public bool Delete()
        {
            return DAL.DeleteProductGroup(Id);
        }

        
        #endregion

    }
   
}
public partial class DataAccessLayer
{
    public bool DeleteProductGroup(int pId)
    {
        try
        {
            UtilMySqlHelper.ExecuteNonQuery(conString, CommandType.StoredProcedure, SpNameCollection.DeleteProductGroup,
                MySQLParameterGeneratorEx.GenerateParam(((MethodInfo)MethodBase.GetCurrentMethod()).GetParameters(), pId));
            return true;
        }
        catch (Exception ex)
        {
            return false;
        }
    }


    public bool UpdateProductGroup(int pId, string pName)
    {
        try
        {
            UtilMySqlHelper.ExecuteNonQuery(conString, CommandType.StoredProcedure, SpNameCollection.UpdateProductGroup,
                MySQLParameterGeneratorEx.GenerateParam(((MethodInfo)MethodBase.GetCurrentMethod()).GetParameters(), pId, pName));
            return true;
        }
        catch (Exception ex)
        {
            return false;
        }
    }


    public bool InsertProductGroup(string pName)
    {
        try
        {
            UtilMySqlHelper.ExecuteNonQuery(conString, CommandType.StoredProcedure, SpNameCollection.InsertProductGroup,
                MySQLParameterGeneratorEx.GenerateParam(((MethodInfo)MethodBase.GetCurrentMethod()).GetParameters(), pName));
            return true;
        }
        catch (Exception ex)
        {
            return false;
        }
    }

    public DataTable GetAllProductGroups()
    {
        try
        {
            return UtilMySqlHelper.ExecuteDataTable(conString, CommandType.StoredProcedure, SpNameCollection.GetAllProductGroups,
                MySQLParameterGeneratorEx.GenerateParam(((MethodInfo)MethodBase.GetCurrentMethod()).GetParameters()));
        }
        catch (Exception ex)
        {
            return null;
        }
    }
}
