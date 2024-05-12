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
        private IWalletTransactionRepository _walletTransactionRepository;

        public ScheduleService(IWalletTransactionRepository walletTransactionRepository)
        {
            _walletTransactionRepository = walletTransactionRepository;
        }

        public Task<bool> SendNotification()
        {
            throw new NotImplementedException();
        }

        public Task<bool> SendSms(string customerCel, int minutes)
        {
            throw new NotImplementedException();
        }

        public async Task AddTransaction(WalletTransactionEntity transaction)
        {
            await _walletTransactionRepository.AddAsync(transaction);
        }
    }
}
