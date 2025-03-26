using FluentValidation;

namespace WebApplication1.Controllers.Login
{
    /// <summary>
    /// Represents a request to register a new user.
    /// </summary>
    /// <param name="Name">The name of the user.</param>
    /// <param name="Password">The password of the user.</param>
    /// <param name="Email">The email of the user.</param>
    /// <param name="PhoneNumber">The phone number of the user.</param>
    public record RegisterUserRequest(string Name, string Password, string? Email, string PhoneNumber);

    /// <summary>
    /// Validator for <see cref="RegisterUserRequest"/>.
    /// </summary>
    public class RegisterUserRequestValidator : AbstractValidator<RegisterUserRequest>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="RegisterUserRequestValidator"/> class.
        /// </summary>
        public RegisterUserRequestValidator()
        {
            RuleFor(e => e.Name).NotNull().NotEmpty();
            RuleFor(e => e.Password).NotNull().NotEmpty();
            //RuleFor(e => e.Email).NotNull().NotEmpty();
            RuleFor(e => e.PhoneNumber).NotNull().NotEmpty();
        }
    }
}
