using FluentValidation;

namespace IdentityService.WebAPI.Controllers.Login;
/// <summary>
/// Request to send a code by phone.
/// </summary>
public record SendCodeByPhoneRequest(string PhoneNumber);
/// <summary>
/// Validator for SendCodeByPhoneRequest.
/// </summary>
public class SendCodeByPhoneRequestValidator : AbstractValidator<SendCodeByPhoneRequest>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="SendCodeByPhoneRequestValidator"/> class.
    /// </summary>
    public SendCodeByPhoneRequestValidator()
    {
        RuleFor(e => e.PhoneNumber).NotNull().NotEmpty();
    }
}
