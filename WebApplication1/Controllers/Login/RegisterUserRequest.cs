using FluentValidation;

namespace WebApplication1.Controllers.Login
{
    public record RegisterUserRequest(string Name, string Password, string? Email, string PhoneNumber);

    public class RegisterUserRequestValidator : AbstractValidator<RegisterUserRequest>
    {
        public RegisterUserRequestValidator()
        {
            RuleFor(e => e.Name).NotNull().NotEmpty();
            RuleFor(e => e.Password).NotNull().NotEmpty();
            //RuleFor(e => e.Email).NotNull().NotEmpty();
            RuleFor(e => e.PhoneNumber).NotNull().NotEmpty();

        }
    }
}
