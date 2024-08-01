using Aspire.ApiService.Model;
using Microsoft.EntityFrameworkCore;

namespace Aspire.ApiService.Data
{
    public class CountriesService : ICountriesService
    {
        private readonly AspireAPIDbContext _context;
        public CountriesService(AspireAPIDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Country>> GetTestObjList()
        {
            return await _context.Countries.ToListAsync();
        }
    }
}
