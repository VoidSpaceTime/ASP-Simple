using FluentValidation;

namespace IdentityService.WebAPI.Controllers.Login;
/// <summary>
/// Represents a request to change the user's password.
/// </summary>
public record ChangeMyPasswordRequest
{
    /// <summary>
    /// Initializes a new instance of the <see cref="ChangeMyPasswordRequest"/> record.
    /// </summary>
    /// <param name="Password">The new password.</param>
    /// <param name="Password2">The confirmation of the new password.</param>
    public ChangeMyPasswordRequest(string Password, string Password2)
    {
        this.Password = Password;
        this.Password2 = Password2;
    }

    /// <summary>
    /// Gets the new password.
    /// </summary>
    public string Password { get; init; }

    /// <summary>
    /// Gets the confirmation of the new password.
    /// </summary>
    public string Password2 { get; init; }
}
/// <summary>
/// Validator for <see cref="ChangeMyPasswordRequest"/>.
/// </summary>
public class ChangePasswordRequestValidator : AbstractValidator<ChangeMyPasswordRequest>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="ChangePasswordRequestValidator"/> class.
    /// </summary>
    public ChangePasswordRequestValidator()
    {
        RuleFor(e => e.Password).NotNull().NotEmpty()
            .Equal(e => e.Password2);
        RuleFor(e => e.Password2).NotNull().NotEmpty();
    }
}
