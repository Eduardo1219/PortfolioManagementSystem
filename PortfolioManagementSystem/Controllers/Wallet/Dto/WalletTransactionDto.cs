using Domain.WalletTransaction.Entity;

namespace PortfolioManagementSystem.Controllers.Wallet.Dto
{
    public class WalletTransactionDto
    {
        public decimal Amount { get; set; }
        public OperationType OperationType { get; set; }
    }
}
