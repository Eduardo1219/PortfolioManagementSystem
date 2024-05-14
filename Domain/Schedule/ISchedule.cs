using Domain.WalletTransaction.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Schedule
{
    public interface ISchedule
    {
        Task AddTransaction(WalletTransactionItem transaction, Guid walletId, int month);
    }
}
