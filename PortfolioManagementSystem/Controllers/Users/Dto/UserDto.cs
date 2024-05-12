using Domain.User.Entity.Enum;
using FluentValidation;
using PortfolioManagementSystem.Controllers.Product.Dto;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace PortfolioManagementSystem.Controllers.Users.Dto
{
    public class UserDto
    {
        /// <summary>
        /// User email
        /// </summary>
        [JsonPropertyName("email")]
        public string Email { get; set; }

        /// <summary>
        /// User name
        /// </summary>
        [JsonPropertyName("name")]
        public string Name { get; set; }

        /// <summary>
        /// User lastname
        /// </summary>
        [JsonPropertyName("lastName")]
        public string LastName { get; set; }

        /// <summary>
        /// User birthdate
        /// </summary>
        [JsonPropertyName("birthDate")]
        public DateTime BirthDate { get; set; }

        /// <summary>
        /// User status
        /// </summary>
        [JsonPropertyName("active")]
        public bool Active { get; set; }

        /// <summary>
        /// User permission (profile)
        /// </summary>
        [JsonPropertyName("permission")]
        public UserEnum Permission { get; set; }
    }

    public class UserValidator : AbstractValidator<UserDto>
    {
        public UserValidator()
        {
            RuleFor(x => x.Email)
                .NotNull().WithMessage("email must not be null")
                .NotEmpty().WithMessage("email must not be empty")
                .EmailAddress().WithMessage("email is not valid");

            RuleFor(x => x.Name)
                .NotNull().WithMessage("name must not be null")
                .NotEmpty().WithMessage("name must not be empty");

            RuleFor(x => x.LastName)
                .NotNull().WithMessage("lastName must not be null")
                .NotEmpty().WithMessage("lastName must not be empty");

            RuleFor(x => x.BirthDate)
                .NotNull().WithMessage("birthDate must not be null")
                .Must(ValidDate).WithMessage("User should not be a minor");

            RuleFor(x => x.Active)
                .NotNull().WithMessage("status must not be null");

            RuleFor(x => x.Active)
                .NotNull().WithMessage("permission must not be null");
        }

        private bool ValidDate(DateTime date)
        {
            var minorAge = date.Date.AddYears(+18).Year < DateTime.UtcNow.AddDays(-3).Year;
            return !minorAge;
        }
    }
}
