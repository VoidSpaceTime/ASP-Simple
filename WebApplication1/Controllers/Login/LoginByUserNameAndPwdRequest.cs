using FluentValidation;

namespace IdentityService.WebAPI.Controllers.Login;
/// <summary>
/// Represents a request to login using username and password.
/// </summary>
public record LoginByUserNameAndPwdRequest(string UserName, string Password);
/// <summary>
/// Validator for <see cref="LoginByUserNameAndPwdRequest"/>.
/// </summary>
public class LoginByUserNameAndPwdRequestValidator : AbstractValidator<LoginByUserNameAndPwdRequest>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="LoginByUserNameAndPwdRequestValidator"/> class.
    /// </summary>
    public LoginByUserNameAndPwdRequestValidator()
    {
        RuleFor(e => e.UserName).NotNull().NotEmpty();
        RuleFor(e => e.Password).NotNull().NotEmpty();
    }
}
