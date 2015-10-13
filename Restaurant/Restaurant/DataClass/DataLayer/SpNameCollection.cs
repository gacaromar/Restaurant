public static class SpNameCollection
{
    #region Table

    public static string InsertTable = "Insert_Tables";
    public static string UpdateTable = "Update_Table";
    public static string GetAllTables = "GetList_AllTables";
    public static string DeleteTable = "Delete_Table";
    public const string GetTableById = "GetItem_TableById";
    public const string UpdateTableActive = "Update_TableActiveById";
    #endregion

    #region ProductGroup

    public static string GetAllProductGroups = "GetList_AllProductGroups";
    public static string InsertProductGroup = "Insert_ProductGroup";
    public static string UpdateProductGroup = "Update_ProductGroup";
    public static string DeleteProductGroup = "Delete_ProductGroup";

    #endregion

    #region Product

    public static string GetProductByProductGroupId = "GetList_ProductByProductGroupId";
    public static string GetProductByAll = "GetList_ProductByAll";

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
    /// <summary>
    /// Insert_Basket
    /// </summary>
    public const string InsertBasket = "Insert_Basket";
    /// <summary>
    /// Update_Basket
    /// </summary>
    public const string UpdateBasket = "Update_Basket";

    #endregion
    #region Chelner
    /// <summary>
    /// GetList_ChelnerList 
    /// </summary>
    public const string GetChelnerList = "GetList_Chelner";

    #endregion
}