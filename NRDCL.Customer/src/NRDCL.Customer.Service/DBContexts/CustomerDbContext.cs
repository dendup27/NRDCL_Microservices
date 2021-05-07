using Microsoft.EntityFrameworkCore;
using NRDCL.Customer.Service.Entities;

namespace NRDCL.Customer.Service.DBContexts
{
    public class CustomerDbContext : DbContext
    {
        public CustomerDbContext(DbContextOptions<CustomerDbContext> options) : base(options)
        {
        }

        public DbSet<CustomerEntity> CustomerTable { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
        }
    }
}