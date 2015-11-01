using System;
using System.Collections.Generic;
using System.Data;
using System.Reflection;
using Utilities;

namespace Restaurant.DataClass
{
    public class MySettings : DataAccess
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Value { get; set; }

        public static List<MySettings> GetListPrinter()
        {
            var dt = DAL.GetListPrinters();
            var vSetting = new List<MySettings>();
            foreach (DataRow dr in dt.Rows)
            {
                vSetting.Add(new MySettings
                {
                    Id = dr.Field<int>("Id"),
                    Name = dr.Field<string>("Name"),
                    Value = dr.Field<string>("Value")
                });
            }
            return vSetting;
        }

        public static void AddPrinter(string pName, string pValue)
        {
            DAL.InsertPrinter(pName, pValue);
        }
    }
}
public partial class DataAccessLayer
{

    public DataTable GetListPrinters()
    {
        try
        {
            return UtilMySqlHelper.ExecuteDataTable(conString, CommandType.StoredProcedure, SpNameCollection.GetListPrinters,
                MySQLParameterGeneratorEx.GenerateParam(((MethodInfo)MethodBase.GetCurrentMethod()).GetParameters()));
        }
        catch (Exception ex)
        {
            return new DataTable();
        }
    }
    public void InsertPrinter(string pName, string pValue)
    {
        try
        {
            UtilMySqlHelper.ExecuteNonQuery(conString, CommandType.StoredProcedure, SpNameCollection.InsertPrinter,
                MySQLParameterGeneratorEx.GenerateParam(((MethodInfo)MethodBase.GetCurrentMethod()).GetParameters(), pName, pValue));
        }
        catch (Exception ex)
        {
        }
    }
}
