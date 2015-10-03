using System;

[Serializable]
public class DataAccess
{
    public DataAccess()
    {
    }

    public static string NullControl(string value)
    {
        return String.IsNullOrEmpty(value) ? "-" : value;
    }

    private static DataAccessLayer dal;
    protected static DataAccessLayer DAL
    {
        get
        {
            if (dal == null)
                dal = new DataAccessLayer();
            return dal;
        }
    }
}
