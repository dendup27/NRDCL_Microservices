using Microsoft.EntityFrameworkCore;
using NRDCL.Product.Service.Entities;

namespace NRDCL.Product.Service.DBContexts
{
    public class ProductDbContext : DbContext
    {
        public ProductDbContext(DbContextOptions<ProductDbContext> options) : base(options)
        {
        }

        public DbSet<ProductEntity> Product_tbl { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
        }
    }
}