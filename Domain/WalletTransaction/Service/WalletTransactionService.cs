using Domain.WalletTransaction.Entity;
using Domain.WalletTransaction.Repository;
using MongoDB.Bson.Serialization.Serializers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace Domain.WalletTransaction.Service
{
    public class WalletTransactionService : IWalletTransactionService
    {
        private readonly IWalletTransactionRepository _repository;

        public WalletTransactionService(IWalletTransactionRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<WalletTransactionItem>> GetByIdAndPeriod(Guid id, DateTime? initialDate, DateTime? endDate)
        {
            var walletTransactions = await _repository.GetManyAsync(t => t.WalletId == id.ToString() &&
            (initialDate.HasValue ? initialDate.Value.Month >= t.MonthTransactions : true) &&
            (endDate.HasValue ? endDate.Value.Month <= t.MonthTransactions : true));

            if (!walletTransactions.Any())
                return new List<WalletTransactionItem>();

            var transactions = walletTransactions
                .SelectMany(w => w.WalletTransactionItems
                .Where(t => initialDate.HasValue ? t.OperationDate >= initialDate.Value: true &&
                (endDate.HasValue ? t.OperationDate <= endDate.Value : true)))
                .ToList();

            return transactions;
        }

        public async Task<WalletTransactionEntity> GetById(Guid id, int month)
        {
            return await _repository.GetAsync(t => t.WalletId == id.ToString() && t.MonthTransactions == month);
        }

        public async Task AddTransaction(WalletTransactionItem entity, Guid walletId, int month)
        {
            var walletTransactions = await GetById(walletId, month);
            if (walletTransactions == null)
            {
                await NewWalletTransactions(entity, walletId, month);
                return;
            } 

            walletTransactions.AddTransaction(entity);
            await _repository.UpdateAsync(walletTransactions);
        }

        private async Task NewWalletTransactions(WalletTransactionItem entity, Guid walletId, int month)
        {
            WalletTransactionEntity walletTransactions = new WalletTransactionEntity
            {
                LastModificationDate = DateTime.UtcNow.AddHours(-3),
                MonthTransactions = month,
                WalletId = walletId.ToString()
            };

            walletTransactions.AddTransaction(entity);

            await _repository.AddAsync(walletTransactions);
        }
    }
}
