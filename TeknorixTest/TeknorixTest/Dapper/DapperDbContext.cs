using Microsoft.Extensions.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace TeknorixTest.Dapper
{
    public class DapperDbContext
    {
        private readonly IConfiguration _configuration;
        private readonly string connectionString;
        public DapperDbContext(IConfiguration configuration)
        {
            this._configuration = configuration;               
        }
        public IDbConnection GetOpenConnection()
        {
            var connectionString = _configuration.GetConnectionString("DBConnectionString");
            var connection = new SqlConnection(connectionString);
            connection.Open();
            return connection;
        }

    }
}



