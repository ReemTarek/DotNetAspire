using System.Data;

namespace Aspire.ApiService.DbAccess
{
    public interface ISqlDbContext
    {
        IDbConnection CreateConnection();
        void SetConnectionString(string connectionName);
    }
}