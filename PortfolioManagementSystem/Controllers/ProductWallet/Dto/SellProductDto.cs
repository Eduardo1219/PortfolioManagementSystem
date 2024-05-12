using FluentValidation;
using System.Text.Json.Serialization;

namespace PortfolioManagementSystem.Controllers.ProductWallet.Dto
{
    public class SellProductDto
    {
        [JsonPropertyName("productWalletId")]
        public Guid ProductWalletId { get; set; }
        [JsonPropertyName("quantity")]
        public int Quantity { get; set; }
    }

    public class SellProductValidator : AbstractValidator<SellProductDto>
    {
        public SellProductValidator()
        {
            RuleFor(x => x.ProductWalletId)
                .NotNull().WithMessage("ProductWalletId must not be null")
                .NotEmpty().WithMessage("ProductWalletId must not be empty");

            RuleFor(x => x.Quantity)
                .NotNull().WithMessage("Price must not be null")
                .GreaterThan(0).WithMessage("Quantity must be greater than 0");
        }
    }
}
