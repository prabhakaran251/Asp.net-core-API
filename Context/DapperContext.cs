using Microsoft.Extensions.Configuration;
using System.Data;
using System.Data.SqlClient;
namespace Telex.Context
{
    public class DapperContext
    {
        private readonly IConfiguration _configuration;
        private readonly string _connectionString;
        public DapperContext(IConfiguration configuration)
        {
            _configuration = configuration;
            _connectionString = configuration.GetConnectionString("SqlConnection");
        }
        public IDbConnection Createconnection()
            => new SqlConnection(_connectionString);
    }
}
