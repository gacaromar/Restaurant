﻿
using System.ComponentModel;

public static class SpNameCollection
{
    #region Table

    public static string InsertTable = "Insert_Tables";
    public static string UpdateTable = "Update_Table";
    public static string GetAllTables = "GetList_AllTables";
    public static string DeleteTable = "Delete_Table";
    #endregion

    #region ProductGroup

    public static string GetAllProductGroups = "GetList_AllProductGroups";

    #endregion

    #region Product

    public static string GetProductByProductGroupId = "GetList_ProductByProductGroupId";

    #endregion
    #region Order
    /// <summary>
    /// Insert_Orders
    /// </summary>
    public const string InsertOrders = "Insert_Orders";
    /// <summary>
    /// GetList_OrderByTableId
    /// </summary>
    public const string GetOrderByTableId = "GetList_OrderByTableId";

    #endregion
    #region Basket
    /// <summary>
    /// GetList_Basket
    /// </summary>
    public const string GetBasketList = "GetList_Basket";

    #endregion
}