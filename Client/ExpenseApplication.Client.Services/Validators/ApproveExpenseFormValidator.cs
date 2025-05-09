using FluentValidation;

namespace ExpenseApplication.Client.Services.Validators;

public class ApproveExpenseFormValidator : AbstractValidator<ApproveExpenseFormDto>
{
    public ApproveExpenseFormValidator()
    {
        RuleFor(approveExpenseForm => approveExpenseForm.ExpenseId)
            .NotNull()
            .NotEqual(default(int))
            .WithMessage("ExpenseId is required!")
            .WithName(approveExpenseForm => nameof(approveExpenseForm.ExpenseId));

        RuleFor(approveExpenseForm => approveExpenseForm.Comments)
            .MaximumLength(450)
            .WithMessage("Maximum length of Comments is 450 characters!")
            .WithName(approveExpenseForm => nameof(approveExpenseForm.Comments));
    }
}