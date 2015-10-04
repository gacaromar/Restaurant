using System.Reflection;
using MySql.Data.MySqlClient;

public partial class DataAccessLayer
{
	public DataAccessLayer() { }

    public static string conString
    {
        get
        {
            string cs = string.Empty;
            MySqlConnectionStringBuilder mcsb = new MySqlConnectionStringBuilder();
            mcsb.ConnectionString =
    System.Configuration.ConfigurationManager.ConnectionStrings["RestaurantConstr"].ConnectionString;
            mcsb.ConnectionTimeout = 120;
            cs = mcsb.ToString();
            
            return cs;
        }
    }

}

public sealed class MySQLParameterGeneratorEx
{
    private const string ReturnValueParameterName = "RETURN_VALUE";

    public static MySqlParameter[] GenerateParam(ParameterInfo[] methodParameters, params object[] Values)
    {
        int length = methodParameters.Length;
        MySqlParameter[] sqlParams = new MySqlParameter[length];

        for (int i = 0; i < length; i++)
        {
            MySqlParameter parameter = new MySqlParameter();
            parameter.ParameterName = "@" + methodParameters[i].Name;
            parameter.Value = Values[i];
            sqlParams[i] = parameter;
        }

        return sqlParams;
    }
}