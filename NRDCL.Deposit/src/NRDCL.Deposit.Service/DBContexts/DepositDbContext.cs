using Microsoft.EntityFrameworkCore;
using NRDCL.Deposit.Service.Entities;

namespace NRDCL.Deposit.Service.DBContexts
{
    public class DepositDbContext : DbContext
    {
        public DepositDbContext(DbContextOptions<DepositDbContext> options) : base(options)
        {
        }

        public DbSet<DepositEntity> Deposit_tbl { get; set; }
        public DbSet<CustomerEntity> Customer_tbl { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
        }
    }
}