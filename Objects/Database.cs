using System.Data;
using System.Data.SqlClient;

namespace LibraryApp.Objects
{
  public class DB
  {
    public static SqlConnection Connection()
    {
      SqlConnection conn = new SqlConnection(DBConfiguration.ConnectionString);
      return conn;
    }
  }
}
