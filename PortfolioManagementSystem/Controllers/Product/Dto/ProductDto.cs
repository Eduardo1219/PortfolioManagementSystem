using System.Text.Json.Serialization;
using FluentValidation;

namespace PortfolioManagementSystem.Controllers.Product.Dto
{
    public class ProductDto
    {
        /// <summary>
        /// Description of the product
        /// </summary>
        [JsonPropertyName("description")]
        public string Description { get; set; }

        /// <summary>
        /// Price of the product
        /// </summary>
        [JsonPropertyName("price")]
        public decimal Price { get; set; }

        /// <summary>
        /// Due Date of the product
        /// </summary>
        [JsonPropertyName("dueDate")]
        public DateTime DueDate { get; set; }

        /// <summary>
        /// Product is active
        /// </summary>
        [JsonPropertyName("active")]
        public bool Active { get; set; }
    }

    public class ProductValidator : AbstractValidator<ProductDto>
    {
        public ProductValidator()
        {
            RuleFor(x => x.Description)
                .NotNull().WithMessage("Description must not be null")
                .NotEmpty().WithMessage("Description must not be empty");

            RuleFor(x => x.Price)
                .NotNull().WithMessage("Price must not be null");

            RuleFor(x => x.DueDate)
                .NotNull().WithMessage("Date must not be null")
                .Must(ValidDate).WithMessage("Date should not be in the past");

            RuleFor(x => x.Active)
                .NotNull().WithMessage("Status must not be null");
        }

        private bool ValidDate(DateTime date)
        {
            var currentDateGreater =  date.Date >= DateTime.UtcNow.Date;
            return currentDateGreater;
        }
    }
}
