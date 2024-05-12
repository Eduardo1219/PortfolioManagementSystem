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
            
            //modelBuilder.Entity<WalletEntity>()
            //    .HasOne<UserEntity>()
            //    .WithOne(e => e.Blog)
            //    .HasForeignKey<BlogHeader>(e => e.BlogId)
            //    .IsRequired();


            base.OnModelCreating(modelBuilder);
        }
    }
}
