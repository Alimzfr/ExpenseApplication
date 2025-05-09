using FluentValidation;

namespace ExpenseApplication.Client.Services.Validators;

public class ExpenseItemValidator : AbstractValidator<ExpenseItemDto>
{
    public ExpenseItemValidator()
    {
        RuleFor(v => v.Purpose)
            .Cascade(CascadeMode.Stop)
            .NotEmpty()
            .WithMessage("Purpose is required!")
            .MinimumLength(3)
            .WithMessage("Minimum length of Purpose is 3 characters!")
            .MaximumLength(100)
            .WithMessage("Maximum length of Purpose is 100 characters!")
            .WithName(expenseForm => nameof(expenseForm.Purpose));

        RuleFor(v => v.Amount)
            .Cascade(CascadeMode.Stop)
            .NotNull()
            .WithMessage("Amount is required!")
            .GreaterThan(0)
            .WithMessage("Amount should be greater than 0!")
            .LessThanOrEqualTo(5000)
            .WithMessage("Amount should be less than or equal to 5000!")
            .WithName(expenseForm => nameof(expenseForm.Amount));
    }
}