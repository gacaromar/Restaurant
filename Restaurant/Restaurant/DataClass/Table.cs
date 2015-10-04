﻿using System;
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
        public string TableName { get; set; }
        public bool Active { get; set; }
        public DateTime RecordDate { get; set; }
        #endregion

        #region Methods

        public static List<Table> GetAllTables()
        {
            List<Table> list = new List<Table>();
            DataTable dt = DAL.GetAllTables();

            foreach (DataRow row in dt.Rows)
            {
                Table item = new Table()
                {
                    Id = row.Field<int>("Id"),
                    TableName = row.Field<string>("Name"),
                    Active = row.Field<bool>("Active"),
                    RecordDate = row.Field<DateTime>("RecordDate")
                    
                };
                list.Add(item);
            }

            return list;
        }

        public bool Save()
        {
          return  DAL.InsertTable(TableName);
        }

        #endregion

    }

 
}

public partial class DataAccessLayer
{
    public DataTable GetAllTables()
    {
        try
        {
            return UtilMySqlHelper.ExecuteDataTable(conString, CommandType.StoredProcedure, SpNameCollection.GetAllTables,
                MySQLParameterGeneratorEx.GenerateParam(((MethodInfo)MethodBase.GetCurrentMethod()).GetParameters()));
        }
        catch (Exception ex)
        {
            return null;
        }
    }

    public bool InsertTable(string pName)
    {
        try
        {
            UtilMySqlHelper.ExecuteDataTable(conString, CommandType.StoredProcedure, SpNameCollection.InsertTable,
                MySQLParameterGeneratorEx.GenerateParam(((MethodInfo)MethodBase.GetCurrentMethod()).GetParameters(), pName));
            return true;
        }
        catch (Exception ex)
        {
            return false;
        }
    }

}
