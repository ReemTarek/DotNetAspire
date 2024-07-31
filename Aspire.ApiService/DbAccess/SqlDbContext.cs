using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Data;

namespace Aspire.ApiService.DbAccess
{
    public class SqlDbContext : ISqlDbContext
    {
        private readonly IConfiguration _configuration;
        private string ?_connectionString;
        public SqlDbContext(IConfiguration configuration)
        {
            _configuration = configuration;
            _connectionString = _configuration.GetConnectionString("AspireAPI");
        }
        public IDbConnection CreateConnection()
            => new SqlConnection(_connectionString);
        public void SetConnectionString(string connectionName)
        {
            _connectionString = _configuration.GetConnectionString(connectionName);

        }
    }
}
