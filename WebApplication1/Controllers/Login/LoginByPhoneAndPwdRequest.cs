
using FluentValidation;

namespace IdentityService.WebAPI.Controllers.Login;
/// <summary>
/// Represents a request to login using phone number and password.
/// </summary>
public record LoginByPhoneAndPwdRequest(string PhoneNum, string Password)
{
    /// <summary>
    /// Gets the phone number.
    /// </summary>
    public string PhoneNum { get; init; } = PhoneNum;

    /// <summary>
    /// Gets the password.
    /// </summary>
    public string Password { get; init; } = Password;
}
/// <summary>
/// Validator for <see cref="LoginByPhoneAndPwdRequest"/>.
/// </summary>
public class LoginByPhoneAndPwdRequestValidator : AbstractValidator<LoginByPhoneAndPwdRequest>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="LoginByPhoneAndPwdRequestValidator"/> class.
    /// </summary>
    public LoginByPhoneAndPwdRequestValidator()
    {
        RuleFor(e => e.PhoneNum).NotNull().NotEmpty();
        RuleFor(e => e.Password).NotNull().NotEmpty();
    }
}
