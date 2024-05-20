using Domain.User.Entity.Enum;
using FluentValidation;
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
            var currentDate = DateTime.UtcNow.AddHours(-3);

            if (date.AddYears(18).Year > currentDate.Year)
                return false;

            if ((currentDate.Month < date.Month || (currentDate.Month == date.Month && currentDate.Day < date.Day)) && date.AddYears(18).Year == currentDate.Year)
                return false;

            return true;
        }
    }
}
