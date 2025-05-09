using FluentValidation;

namespace ExpenseApplication.Client.Services.Validators;

public class RejectExpenseFormValidator : AbstractValidator<RejectExpenseFormDto>
{
    public RejectExpenseFormValidator()
    {
        RuleFor(rejectExpenseForm => rejectExpenseForm.ExpenseId)
            .NotNull()
            .NotEqual(default(int))
            .WithMessage("ExpenseId is required!")
            .WithName(rejectExpenseForm => nameof(rejectExpenseForm.ExpenseId));

        RuleFor(rejectExpenseForm => rejectExpenseForm.Comments)
            .Cascade(CascadeMode.Stop)
            .NotEmpty()
            .WithMessage("Comments is required!")
            .MinimumLength(3)
            .WithMessage("Minimum length of Comments is 3 characters!")
            .MaximumLength(450)
            .WithMessage("Maximum length of Comments is 450 characters!")
            .WithName(rejectExpenseForm => nameof(rejectExpenseForm.Comments));
    }
}