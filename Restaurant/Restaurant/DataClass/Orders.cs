using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Windows.Forms.VisualStyles;
using Utilities;

namespace Restaurant.DataClass
{
    public class Orders : DataAccess
    {
        #region Properties
        public int Id { get; set; }
        public Table Table { get; set; }
        public Chelner Chelner { get; set; }
        public int Quantity { get; set; }
        public double Total { get; set; }
        public DateTime RecordDate { get; set; }
        public int Status { get; set; }
        #endregion
        #region Methods

        public static int InsertOrder(int pTableId, int pChelnerId, int pQuantity, double pTotal)
        {
            var dt = DAL.InsertOrder(pTableId, pChelnerId, pQuantity, pTotal);
            if (dt.Rows.Count == 0) return -1;
            return Convert.ToInt32(dt.Rows[0][0]);
        }
        #endregion

        //public static Orders GetOrderByTableId(int pTableId)
        //{
        //    var dt = DAL.GetOrderByTableId(pTableId);
        //    var vOrder = new Orders();
        //    foreach (DataRow dr in dt.Rows)
        //    {
        //        vOrder.Product = new Product
        //        {
        //            Id = dr.Field<int>("ProductId"),
        //            ProductName = dr.Field<string>("ProductName")
        //        };
        //        vOrder.Chelner = new Chelner { Id = dr.Field<int>("ChelnerId") };
        //        vOrder.Id = dr.Field<int>("Id");
        //        vOrder.Quantity = dr.Field<int>("Quantity");
        //        vOrder.RecordDate = dr.Field<DateTime>("RecordDate");
        //        vOrder.Table = new Table { Id = dr.Field<int>("TableId") };
        //        vOrder.Total = dr.Field<double>("Total");
        //    }
        //    return vOrder;
        //}
    }

}
public partial class DataAccessLayer
{

    public DataTable InsertOrder(int pTableId, int pChelnerId, double pQuantity, double pTotal)
    {
        try
        {
            return UtilMySqlHelper.ExecuteDataTable(conString, CommandType.StoredProcedure, SpNameCollection.InsertOrders,
                MySQLParameterGeneratorEx.GenerateParam(((MethodInfo)MethodBase.GetCurrentMethod()).GetParameters(), pTableId, pChelnerId,  pQuantity, pTotal));
        }
        catch (Exception ex)
        {
            return new DataTable();
        }
    }

    public DataTable GetOrderByTableId(int pTableId)
    {
        try
        {
            return UtilMySqlHelper.ExecuteDataTable(conString, CommandType.StoredProcedure, SpNameCollection.GetOrderByTableId,
                MySQLParameterGeneratorEx.GenerateParam(((MethodInfo)MethodBase.GetCurrentMethod()).GetParameters(), pTableId));
        }
        catch (Exception ex)
        {
            return new DataTable();
        }
    }
}
