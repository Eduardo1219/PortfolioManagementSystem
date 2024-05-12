using Domain.Product.Entity;
using Microsoft.EntityFrameworkCore;


namespace Infraestructure.Context
{
    public class PortfolioManagementContext : DbContext
    {
        public PortfolioManagementContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<ProductEntity> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
