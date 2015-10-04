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
        
        
        #endregion

    }
   
}
public partial class DataAccessLayer
{
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
