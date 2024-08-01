using Aspire.ApiService.Model;
using Microsoft.EntityFrameworkCore;
using System.Net;

namespace Aspire.ApiService.Data
{
    public class AspireAPIDbContext : DbContext
    {
        public AspireAPIDbContext(DbContextOptions<AspireAPIDbContext> options) : base(options)
        {
        }

        public DbSet<Country> Countries => Set<Country>();
        
        protected override void OnModelCreating(ModelBuilder bldr)
        {
            base.OnModelCreating(bldr);

            

        }

    }
}
