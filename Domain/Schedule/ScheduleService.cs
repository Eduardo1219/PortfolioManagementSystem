using Domain.Product.Repository;
using Domain.Schedule.Entity;
using Domain.User.Entity;
using Domain.User.Entity.Enum;
using Domain.User.Repository;
using Domain.WalletTransaction.Entity;
using Domain.WalletTransaction.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Schedule
{
    public class ScheduleService : ISchedule
    {
        private readonly IWalletTransactionRepository _walletTransactionRepository;

        public ScheduleService(IWalletTransactionRepository walletTransactionRepository)
        {
            _walletTransactionRepository = walletTransactionRepository;
        }

        public async Task AddTransaction(WalletTransactionEntity transaction)
        {
            await _walletTransactionRepository.AddAsync(transaction);
        }
    }
}
