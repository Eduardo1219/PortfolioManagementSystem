using Domain.Product.Entity;
using Domain.ProductWallet.Entity;
using Domain.User.Entity;
using Domain.Wallet.Entity;
using Infraestructure.Migrations;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata;


namespace Infraestructure.Context
{
    public class PortfolioManagementContext : DbContext
    {
        public PortfolioManagementContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<ProductEntity> Products { get; set; }
        public DbSet<UserEntity> Users { get; set; }
        public DbSet<WalletEntity> Wallet { get; set; }
        public DbSet<ProductWalletEntity> ProductWallet { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ProductEntity>().HasData(
            new ProductEntity
            {
                Id = Guid.NewGuid(),
                Active = true,
                AddedDate = DateTime.UtcNow.AddHours(-3),
                Description = "LCI",
                DueDate = DateTime.UtcNow.AddDays(10),
                Price = 100
            },
            new ProductEntity
            {
                Id = Guid.NewGuid(),
                Active = true,
                AddedDate = DateTime.UtcNow.AddHours(-3),
                Description = "LCA",
                DueDate = DateTime.UtcNow.AddDays(15),
                Price = 180
            });


            base.OnModelCreating(modelBuilder);
        }
    }
}
