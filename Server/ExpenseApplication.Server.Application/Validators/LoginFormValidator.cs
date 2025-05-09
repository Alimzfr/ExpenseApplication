namespace ExpenseApplication.Server.Application.Validators;

public class LoginFormValidator : AbstractValidator<LoginFormDto>
{
    public LoginFormValidator()
    {
        RuleFor(loginForm => loginForm.Username)
            .Cascade(CascadeMode.Stop)
            .NotEmpty()
            .WithMessage("Username is required!")
            .MaximumLength(100)
            .WithMessage("Maximum length of Username is 100 characters!")
            .WithName(loginForm => nameof(loginForm.Username));

        RuleFor(loginForm => loginForm.Password)
            .Cascade(CascadeMode.Stop)
            .NotEmpty()
            .WithMessage("Password is required!")
            .MaximumLength(100)
            .WithMessage("Maximum length of Password is 100 characters!")
            .WithName(loginForm => nameof(loginForm.Password));
    }
}