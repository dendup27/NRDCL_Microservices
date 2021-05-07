using Microsoft.EntityFrameworkCore;
using NRDCL.Order.Service.Entities;

namespace NRDCL.Order.Service.DBContexts
{
    public class OrderDbContext : DbContext
    {
        public OrderDbContext(DbContextOptions<OrderDbContext> options) : base(options)
        {
        }

        public DbSet<OrderEntity> Order_tbl { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
        }
    }
}