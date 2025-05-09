using ExpenseApplication.Server.Application.Features.AccountUseCase.Commands.RefreshToken;

namespace ExpenseApplication.Server.Application.Validators;

public class RefreshTokenCommandValidator : AbstractValidator<RefreshTokenCommand>
{
    public RefreshTokenCommandValidator()
    {
        RuleFor(refreshTokenCommand => refreshTokenCommand.RefreshTokenForm)
            .NotNull()
            .NotEmpty()
            .WithMessage("RefreshTokenForm is required!")
            .WithName(refreshTokenCommand => nameof(refreshTokenCommand.RefreshTokenForm))
            .DependentRules(() => RuleFor(refreshTokenCommand => refreshTokenCommand.RefreshTokenForm).SetValidator(new RefreshTokenFormValidator()));
    }
}