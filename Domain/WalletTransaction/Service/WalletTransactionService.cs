using Domain.WalletTransaction.Entity;
using Domain.WalletTransaction.Repository;
using MongoDB.Bson.Serialization.Serializers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.WalletTransaction.Service
{
    public class WalletTransactionService : IWalletTransactionService
    {
        private readonly IWalletTransactionRepository _repository;

        public WalletTransactionService(IWalletTransactionRepository repository)
        {
            _repository = repository;
        }


        public async Task AddTransaction(WalletTransactionEntity entity)
        {
            await _repository.AddAsync(entity);
        }

        public async Task<List<WalletTransactionEntity>> GetById(Guid id)
        {
            return await _repository.GetAsync(t => t.WalletId == id.ToString());
        }
    }
}
