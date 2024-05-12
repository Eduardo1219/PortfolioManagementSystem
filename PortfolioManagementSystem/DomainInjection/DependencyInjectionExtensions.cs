using Domain.Product.Repository;
using Domain.Product.Service;
using Domain.ProductWallet.Repository;
using Domain.ProductWallet.Service;
using Domain.User.Repository;
using Domain.User.Service;
using Domain.Wallet.Repository;
using Domain.Wallet.Service;
using Infraestructure.Context;
using Infraestructure.Repository.Product;
using Infraestructure.Repository.ProductWallet;
using Infraestructure.Repository.User;
using Infraestructure.Repository.Wallet;
using Microsoft.EntityFrameworkCore;

namespace PortfolioManagementSystem.DomainInjection
{
    public static class DependencyInjectionExtensions
    {
        public static IServiceCollection AddInfraestructure(this IServiceCollection services, IConfiguration configuration)
        {
            ConfigureContext(services, configuration);
            ConfigureProducts(services);
            ConfigureUser(services);
            ConfigureWallet(services);
            ConfigureProductWallet(services);

            return services;
        }

        public static void ConfigureContext(IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<PortfolioManagementContext>(options => options.UseSqlServer(configuration.GetConnectionString("Default")));
        }

        public static void ConfigureProducts(this IServiceCollection services)
        {
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<IProductService, ProductService>();
        }

        public static void ConfigureUser(this IServiceCollection services)
        {
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IUserService, UserService>();
        }

        public static void ConfigureWallet(this IServiceCollection services)
        {
            services.AddScoped<IWalletRepository, WalletRepository>();
            services.AddScoped<IWalletService, WalletService>();
        }

        public static void ConfigureProductWallet(this IServiceCollection services)
        {
            services.AddScoped<IProductWalletRepository, ProductWalletRepository>();
            services.AddScoped<IProductWalletService, ProductWalletService>();
        }
    }
}
