using Domain.Product.Repository;
using Domain.Schedule.Entity;
using Domain.User.Entity;
using Domain.User.Entity.Enum;
using Domain.User.Repository;
using Domain.Wallet.Service;
using Domain.WalletTransaction.Entity;
using Domain.WalletTransaction.Repository;
using Domain.WalletTransaction.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Schedule
{
    public class ScheduleService : ISchedule
    {
        private readonly IWalletTransactionService _walletTransactionService;

        public ScheduleService(IWalletTransactionService walletTransactionService)
        {
            _walletTransactionService = walletTransactionService;
        }

        public async Task AddTransaction(WalletTransactionItem transaction, Guid walletId, int month)
        {
            await _walletTransactionService.AddTransaction(transaction, walletId, month);
        }


    }
}
