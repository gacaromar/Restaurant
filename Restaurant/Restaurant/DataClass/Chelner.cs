using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using Utilities;

namespace Restaurant.DataClass
{
    public class Chelner : DataAccess
    {

        #region Properties

        public int Id { get; set; }
        public string ChelnerName { get; set; }
        public int Status { get; set; }

        #endregion

        #region Methods
        public static List<Chelner> GetList()
        {
            var dt = DAL.GetChelnerList();
            var vList = new List<Chelner>();
            foreach (DataRow dr in dt.Rows)
            {
                var vChelner = new Chelner
                {
                    Id = dr.Field<int>("Id"),
                    ChelnerName = dr.Field<string>("Name")
                };
                vList.Add(vChelner);
            }
            return vList;
        }
        #endregion



    }

}
public partial class DataAccessLayer
{

    public DataTable GetChelnerList()
    {
        try
        {
            return UtilMySqlHelper.ExecuteDataTable(conString, CommandType.StoredProcedure, SpNameCollection.GetChelnerList,
                MySQLParameterGeneratorEx.GenerateParam(((MethodInfo)MethodBase.GetCurrentMethod()).GetParameters()));
        }
        catch (Exception ex)
        {
            return new DataTable();
        }
    }
}
