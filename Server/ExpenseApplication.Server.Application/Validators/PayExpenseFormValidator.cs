namespace ExpenseApplication.Server.Application.Validators;

public class PayExpenseFormValidator : AbstractValidator<PayExpenseFormDto>
{
    public PayExpenseFormValidator()
    {
        RuleFor(payExpenseForm => payExpenseForm.ExpenseId)
            .NotNull()
            .NotEqual(default(int))
            .WithMessage("ExpenseId is required!")
            .WithName(payExpenseForm => nameof(payExpenseForm.ExpenseId));

        RuleFor(payExpenseForm => payExpenseForm.Comments)
            .MaximumLength(450)
            .WithMessage("Maximum length of Comments is 450 characters!")
            .WithName(payExpenseForm => nameof(payExpenseForm.Comments));
    }
}