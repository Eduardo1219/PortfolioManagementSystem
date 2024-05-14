using Domain.WalletTransaction.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.WalletTransaction.Service
{
    public interface IWalletTransactionService
    {
        Task AddTransaction(WalletTransactionItem entity, Guid walletId, int month);
        Task<List<WalletTransactionItem>> GetByIdAndPeriod(Guid id, DateTime? initialDate, DateTime? endDate);
        Task<WalletTransactionEntity> GetById(Guid id, int month);
    }
}
