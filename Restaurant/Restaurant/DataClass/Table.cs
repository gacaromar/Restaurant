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
    public class Table : DataAccess
    {
        public Table()
        {

        }
        #region Properties
        public int Id { get; set; }
        public string Name { get; set; }
        public bool Active { get; set; } 
        #endregion

        #region Methods

        public void Save()
        {
            DAL.InsertTable();
        }

        #endregion

    }

 
}

public partial class DataAccessLayer
{
    //public DataTable GetOrderListByCustomerId(int pCustomerId)
    //{
    //    try
    //    {
    //        return UtilMySqlHelper.ExecuteDataTable(conString, CommandType.StoredProcedure, SpNameCollection.GetOrderListByCustomerId,
    //            MySQLParameterGeneratorEx.GenerateParam(((MethodInfo)MethodBase.GetCurrentMethod()).GetParameters(), pCustomerId));
    //    }
    //    catch (Exception ex)
    //    {
    //        Logger.LogGeneral(LogGeneralType.Error, ((MethodInfo)MethodBase.GetCurrentMethod()).Name, ex);
    //        return new DataTable();
    //    }
    //}

    public void InsertTable()
    {
        try
        {
            UtilMySqlHelper.ExecuteDataTable(conString, CommandType.StoredProcedure, SpNameCollection.InsertTable,
                MySQLParameterGeneratorEx.GenerateParam(((MethodInfo)MethodBase.GetCurrentMethod()).GetParameters()));
        }
        catch (Exception ex)
        {

        }
    }

}
