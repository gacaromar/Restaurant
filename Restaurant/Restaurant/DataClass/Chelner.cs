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




        public static int Insert(string pName)
        {
            var dt = DAL.InsertChelner(pName);
            return dt.Rows.Count;
        }

        public void Update()
        {
            DAL.UpdateChelner(Id, ChelnerName);
        }

        public void Delete()
        {
            DAL.DeleteChelner(Id);
        }
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

    public DataTable InsertChelner(string pName)
    {
        try
        {
            return UtilMySqlHelper.ExecuteDataTable(conString, CommandType.StoredProcedure, SpNameCollection.InsertChelner,
                MySQLParameterGeneratorEx.GenerateParam(((MethodInfo)MethodBase.GetCurrentMethod()).GetParameters(), pName));
        }
        catch (Exception ex)
        {
            return new DataTable();
        }
    }

    public void UpdateChelner(int pId, string pChelnerName)
    {
        try
        {
            UtilMySqlHelper.ExecuteNonQuery(conString, CommandType.StoredProcedure, SpNameCollection.UpdateChelner,
                            MySQLParameterGeneratorEx.GenerateParam(((MethodInfo)MethodBase.GetCurrentMethod()).GetParameters(), pId, pChelnerName));
        }
        catch (Exception ex)
        {
        }
    }

    public void DeleteChelner(int pId)
    {
        try
        {
            UtilMySqlHelper.ExecuteNonQuery(conString, CommandType.StoredProcedure, SpNameCollection.DeleteChelner,
                            MySQLParameterGeneratorEx.GenerateParam(((MethodInfo)MethodBase.GetCurrentMethod()).GetParameters(), pId));
        }
        catch (Exception ex)
        {
        }
    }
}
