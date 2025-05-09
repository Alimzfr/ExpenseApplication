namespace ExpenseApplication.Server.Application.Validators;

public class LoginCommandValidator : AbstractValidator<LoginCommand>
{
    public LoginCommandValidator()
    {
        RuleFor(loginCommand => loginCommand.LoginForm)
            .NotNull()
            .NotEmpty()
            .WithMessage("LoginForm is required!")
            .WithName(loginCommand => nameof(loginCommand.LoginForm))
            .DependentRules(() => RuleFor(loginCommand => loginCommand.LoginForm).SetValidator(new LoginFormValidator()));
    }
}