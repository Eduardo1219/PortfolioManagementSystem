using FluentValidation;
using PortfolioManagementSystem.Controllers.Product.Dto;
using System.Text.Json.Serialization;

namespace PortfolioManagementSystem.Controllers.ProductWallet.Dto
{
    public class BuyProductDto
    {
        [JsonPropertyName("WalletId")]
        public Guid WalletId { get; set; }
        [JsonPropertyName("ProductId")]
        public Guid ProductId { get; set; }
        [JsonPropertyName("Quantity")]
        public int Quantity {  get; set; }
    }

    public class BuyProductValidator : AbstractValidator<BuyProductDto>
    {
        public BuyProductValidator()
        {
            RuleFor(x => x.WalletId)
                .NotNull().WithMessage("WalletId must not be null")
                .NotEmpty().WithMessage("WalletId must not be empty");

            RuleFor(x => x.ProductId)
                .NotNull().WithMessage("ProductId must not be null")
                .NotEmpty().WithMessage("ProductId must not be empty");

            RuleFor(x => x.Quantity)
                .NotNull().WithMessage("Price must not be null")
                .GreaterThan(0).WithMessage("Quantity must be greater than 0");
        }
    }
}
