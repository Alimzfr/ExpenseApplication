namespace ExpenseApplication.Server.Application.Validators;

public class RefreshTokenFormValidator : AbstractValidator<RefreshTokenFormDto>
{
    public RefreshTokenFormValidator()
    {
        RuleFor(refreshTokenForm => refreshTokenForm.RefreshToken)
            .NotNull()
            .NotEmpty()
            .WithMessage("RefreshToken is required!")
            .WithName(refreshTokenForm => nameof(refreshTokenForm.RefreshToken));
    }
}