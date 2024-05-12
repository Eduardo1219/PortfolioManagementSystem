using Domain.MongoBase.Repository;
using Domain.MongoBase.Settings;
using Domain.Product.Repository;
using Domain.Product.Service;
using Domain.ProductWallet.Repository;
using Domain.ProductWallet.Service;
using Domain.Schedule;
using Domain.User.Repository;
using Domain.User.Service;
using Domain.Wallet.Repository;
using Domain.Wallet.Service;
using Domain.WalletTransaction.Repository;
using Domain.WalletTransaction.Service;
using Infraestructure.Context;
using Infraestructure.Repository.BaseMongo;
using Infraestructure.Repository.Product;
using Infraestructure.Repository.ProductWallet;
using Infraestructure.Repository.User;
using Infraestructure.Repository.Wallet;
using Infraestructure.Repository.WalletTransaction;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace PortfolioManagementSystem.DomainInjection
{
    public static class DependencyInjectionExtensions
    {
        public static IServiceCollection AddInfraestructure(this IServiceCollection services, IConfiguration configuration)
        {
            ConfigureContext(services, configuration);
            ConfigureMongo(services, configuration);
            ConfigureProducts(services);
            ConfigureUser(services);
            ConfigureWallet(services);
            ConfigureProductWallet(services);
            ConfigureWalletTransaction(services);
            ConfigureJobs(services);

            return services;
        }

        public static void ConfigureContext(IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<PortfolioManagementContext>(options => options.UseSqlServer(configuration.GetConnectionString("Default")));
        }

        public static void ConfigureMongo(IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<DatabaseSettings>(configuration.GetSection(nameof(DatabaseSettings)));
            services.AddSingleton<IDatabaseSettings>(m => m.GetRequiredService<IOptions<DatabaseSettings>>().Value);

            services.AddSingleton(typeof(IMongoRepository<>), typeof(MongoRepository<>));
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

        public static void ConfigureWalletTransaction(this IServiceCollection services)
        {
            services.AddSingleton<IWalletTransactionService, WalletTransactionService>();
            services.AddSingleton<IWalletTransactionRepository, WalletTransactionRepository>();
        }

        public static void ConfigureJobs(this IServiceCollection services)
        {
            services.AddSingleton<ISchedule, ScheduleService>();
            //services.AddSingleton<IWalletTransactionRepository, WalletTransactionRepository>();
        }
    }
}
