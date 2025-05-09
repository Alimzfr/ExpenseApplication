namespace ExpenseApplication.Server.Application.Validators;

public class PayExpenseCommandValidator : AbstractValidator<PayExpenseCommand>
{
    public PayExpenseCommandValidator()
    {
        RuleFor(payExpenseCommand => payExpenseCommand.UserId)
            .NotNull()
            .NotEqual(default(int))
            .WithMessage("UserId is required!")
            .WithName(payExpenseCommand => nameof(payExpenseCommand.UserId));

        RuleFor(payExpenseCommand => payExpenseCommand.CurrentDateTime)
            .NotNull()
            .NotEqual(default(DateTime))
            .WithMessage("CurrentDateTime is required!")
            .WithName(payExpenseCommand => nameof(payExpenseCommand.CurrentDateTime));

        RuleFor(payExpenseCommand => payExpenseCommand.PayExpenseForm)
            .Cascade(CascadeMode.Stop)
            .NotNull()
            .WithMessage("PayExpenseForm is required!")
            .WithName(payExpenseCommand => nameof(payExpenseCommand.PayExpenseForm))
            .DependentRules(() => RuleFor(payExpenseCommand => payExpenseCommand.PayExpenseForm).SetValidator(new PayExpenseFormValidator()));
    }
}