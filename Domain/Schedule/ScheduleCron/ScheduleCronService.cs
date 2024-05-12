using Domain.Product.Repository;
using Domain.Schedule.Entity;
using Domain.User.Entity.Enum;
using Domain.User.Repository;
using Domain.Wallet.Entity;
using Domain.Wallet.Repository;
using Domain.WalletTransaction.Entity;
using Domain.WalletTransaction.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Schedule.ScheduleCron
{
    public class ScheduleCronService : IScheduleCronService
    {
        private readonly IProductRepository _productRepository;
        private readonly IUserRepository _userRepository;
        private readonly IWalletRepository _walletRepository;

        public ScheduleCronService(IWalletTransactionRepository walletTransactionRepository,
            IProductRepository productRepository,
            IUserRepository userRepository,
            IWalletRepository walletRepository)
        {
            _productRepository = productRepository;
            _userRepository = userRepository;
            _walletRepository = walletRepository;
        }

        public async Task SendNotification()
        {
            var expirationDate = DateTime.UtcNow.AddHours(-3).AddDays(30);
            var productsToExpire = await _productRepository.GetAsync(p => p.DueDate <= expirationDate);
            var usersToNotify = await _userRepository.GetAsync(u => u.Permission == UserEnum.Manager && u.Active);

            var notificationsTemplate = productsToExpire
                .Select(p => new NotificationTemplate
                {
                    DescriptionProduct = p.Description,
                    DueTime = p.DueDate
                }).ToList();

            usersToNotify.ToList().ForEach(async u =>
            {
                await SendNotificationToUser(u.Email, notificationsTemplate);
            });
        }

        private async Task SendNotificationToUser(string email, List<NotificationTemplate> notificationTemplate)
        {
            // Send to user.
        }

        public async Task CreateWallet(Guid id)
        {
            var walletEntity = new WalletEntity
            {
                Balance = 0,
                UserId = id,
            };

            await _walletRepository.AddAsync(walletEntity);
        }
    }
}
