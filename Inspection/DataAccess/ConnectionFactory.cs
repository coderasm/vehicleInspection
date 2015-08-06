using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace Inspection.DataAccess
{
    public class ConnectionFactory
    {
        public async static Task<IDbConnection> getOpenConnection()
        {
            var connection = new SqlConnection(ConfigurationManager.ConnectionStrings["ABS"].ConnectionString);
            await connection.OpenAsync();
            return connection;
        }
    }
}
