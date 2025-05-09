using FluentValidation;

namespace ExpenseApplication.Client.Services.Validators;

public class ExpenseFormValidator : AbstractValidator<ExpenseFormDto>
{
    public ExpenseFormValidator()
    {
        RuleFor(v => v.Title)
            .Cascade(CascadeMode.Stop)
            .NotEmpty()
            .WithMessage("Title is required!")
            .MinimumLength(3)
            .WithMessage("Minimum length of Title is 3 characters!")
            .MaximumLength(100)
            .WithMessage("Maximum length of Title is 100 characters!")
            .WithName(expenseForm => nameof(expenseForm.Title));

        RuleFor(v => v.CurrencyType)
            .NotNull()
            .WithMessage("CurrencyType is required!")
            .WithName(expenseForm => nameof(expenseForm.CurrencyType));

        RuleFor(v => v.Description)
            .MaximumLength(450)
            .WithMessage("Maximum length of Title is 450 characters!")
            .WithName(expenseForm => nameof(expenseForm.Description));

        RuleFor(dto => dto.ExpenseItems)
            .Cascade(CascadeMode.Stop)
            .NotNull()
            .WithMessage("ExpenseItems is required!")
            .NotEmpty()
            .WithMessage("ExpenseItems should have at least one item!")
            .Must(expenseItems => expenseItems.Sum(expenseItem => expenseItem.Amount) <= 5000)
            .WithMessage("Total amounts should be less than or equal to 5000!")
            .WithName(expenseForm => nameof(expenseForm.ExpenseItems));

        RuleForEach(expenseForm => expenseForm.ExpenseItems).SetValidator(new ExpenseItemValidator());
    }
}