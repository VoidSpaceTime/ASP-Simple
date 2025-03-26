using FluentValidation;

namespace IdentityService.WebAPI.Controllers.Login;
/// <summary>
/// Represents a request to login using a phone number and code.
/// </summary>
public record LoginByPhoneAndCodeRequest
{
    /// <summary>
    /// Initializes a new instance of the <see cref="LoginByPhoneAndCodeRequest"/> class.
    /// </summary>
    /// <param name="PhoneNum">The phone number.</param>
    /// <param name="Code">The code.</param>
    public LoginByPhoneAndCodeRequest(string PhoneNum, string Code)
    {
        this.PhoneNum = PhoneNum;
        this.Code = Code;
    }

    /// <summary>
    /// Gets the phone number.
    /// </summary>
    public string PhoneNum { get; init; }

    /// <summary>
    /// Gets the code.
    /// </summary>
    public string Code { get; init; }
}
/// <summary>
/// Validator for <see cref="LoginByPhoneAndCodeRequest"/>.
/// </summary>
public class LoginByPhoneAndCodeRequestValidator : AbstractValidator<LoginByPhoneAndCodeRequest>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="LoginByPhoneAndCodeRequestValidator"/> class.
    /// </summary>
    public LoginByPhoneAndCodeRequestValidator()
    {
        RuleFor(e => e.PhoneNum).NotNull().NotEmpty();
        RuleFor(e => e.Code).NotNull().NotEmpty();
    }
}
