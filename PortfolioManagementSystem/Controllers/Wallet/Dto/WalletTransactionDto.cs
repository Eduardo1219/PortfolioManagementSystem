using Domain.WalletTransaction.Entity;
using FluentValidation;

namespace PortfolioManagementSystem.Controllers.Wallet.Dto
{
    public class WalletTransactionDto
    {
        public decimal Amount { get; set; }
        public OperationType OperationType { get; set; }
    }

    public class WalletTransactionValidator : AbstractValidator<WalletTransactionDto>
    {
        public WalletTransactionValidator()
        {
            RuleFor(x => x.OperationType)
                .NotNull().WithMessage("Description must not be null")
                .NotEmpty().WithMessage("Description must not be empty");

            RuleFor(x => x.Amount)
                .NotNull().WithMessage("Price must not be null")
                .GreaterThan(0).WithMessage("Price must be greater than 0");
        }
    }
}
