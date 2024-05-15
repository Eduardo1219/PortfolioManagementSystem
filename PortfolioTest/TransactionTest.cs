using Domain.Wallet.Repository;
using Domain.Wallet.Service;
using Domain.WalletTransaction.Entity;
using Domain.WalletTransaction.Repository;
using Domain.WalletTransaction.Service;
using Microsoft.AspNetCore.Mvc;
using Moq;
using PortfolioManagementSystem.Controllers.Transactions.Http;
using PortfolioTest.Data;
using System;

namespace PortfolioTest
{
    public class TransactionTest
    {

        private readonly Mock<IWalletTransactionService> _walletTransactionService;
        private readonly Mock<IWalletService> _walletService;
        private readonly Mock<IWalletTransactionRepository> _repositoryTransaction;

        public TransactionTest()
        {
            _walletTransactionService = new Mock<IWalletTransactionService>();
            _walletService = new Mock<IWalletService>();
        }

        [Fact]
        public async Task Test1Async()
        {
            Guid walletId = Guid.Parse("56f90381-9c86-4b78-89af-4fedb8179e36");
            var title = new List<WalletTransactionItem>(){
                new WalletTransactionItem
                {
                    Amount = 10,
                    LaterBalance = 10,
                    ModificationType = ModificationType.Positive,
                    OperationDate = DateTime.Now,
                    OperationType = OperationType.Deposit,
                    PreviousBalance = 10,
                }
            };


            //WalletMoq
            _walletTransactionService
                .Setup(r => r.GetByIdAndPeriod(walletId, null, null))
                .Returns(Task.FromResult(title));

            _walletService
                .Setup(r => r.GetWalletByIdAsync(walletId))
                .Returns(Task.FromResult(WalletMoq.MoqWallet()));

            var controller = new TransactionsController(_walletTransactionService.Object, _walletService.Object);


            var result = await controller.GetTransactions(walletId, null, null);
            var okObjectResult = result as ObjectResult;
            var valor = okObjectResult.Value;

            Assert.Equal(title, valor);
        }
    }
}