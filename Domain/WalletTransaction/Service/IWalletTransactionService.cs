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
        Task AddTransaction(WalletTransactionEntity entity);
        Task<WalletTransactionEntity> GetById(Guid id);
    }
}
