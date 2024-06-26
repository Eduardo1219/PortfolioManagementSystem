﻿using Domain.Product.Entity;
using Domain.Wallet.Entity;
using Domain.WalletTransaction.Entity;

namespace PortfolioManagementSystem.Helpers.Mappers
{
    public static class WalletTransactionMapper
    {
        public static WalletTransactionEntity WalletTransactionEntityMapper(WalletEntity wallet, decimal amount, OperationType operationType)
        {
            var mofificationType = operationType.OperationTypeModification();
            var walletTransaction = new WalletTransactionEntity
            {
                Amount = amount,
                PreviousBalance = wallet.Balance,
                LaterBalance = mofificationType == ModificationType.Positive ?  wallet.Balance + amount : wallet.Balance - amount,
                ModificationType = mofificationType,
                OperationType = operationType,
                OperationDate = DateTime.UtcNow.AddHours(-3),
                WalletId = wallet.Id.ToString(),
            };

            return walletTransaction;

        }

        public static ModificationType OperationTypeModification(this OperationType operationType)
        {
            switch (operationType)
            {
                case OperationType.Buy:
                case OperationType.Withdraw:
                    return ModificationType.Negative;
                    break;
                default: return ModificationType.Positive;
            }
        }
    }
}
