using Microsoft.EntityFrameworkCore;
using NRDCL.Site.Service.Entities;

namespace NRDCL.Site.Service.DBContexts
{
    public class SiteDbContext : DbContext
    {
        public SiteDbContext(DbContextOptions<SiteDbContext> options) : base(options)
        {
        }

        public DbSet<SiteEntity> Site_tbl { get; set; }
        public DbSet<CustomerEntity> Customer_tbl { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
        }
    }
}