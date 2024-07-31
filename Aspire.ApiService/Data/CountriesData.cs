using Aspire.ApiService.DbAccess;
using Aspire.Shared.Models;
using Dapper;
using System.Data;

namespace Aspire.ApiService.Data
{
    public class CountriesData : ICountriesData
    {
        private readonly ISqlDbContext _context;
        public CountriesData(ISqlDbContext db)
        {
            _context = db;
        }
        public async Task<IEnumerable<CountriesModel>> Countries_Get()
        {

            var storedProcedureName = "dbo.usp_Countries_Get";

            using (var connection = _context.CreateConnection())
            {
                var results = await connection.QueryAsync<CountriesModel>(storedProcedureName, new { }, commandType: CommandType.StoredProcedure);
                return results;
            }
        }
    }
}
