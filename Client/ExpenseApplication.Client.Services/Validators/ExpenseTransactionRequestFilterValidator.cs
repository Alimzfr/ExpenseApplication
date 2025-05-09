using FluentValidation;

namespace ExpenseApplication.Client.Services.Validators;

public class ExpenseTransactionRequestFilterValidator : AbstractValidator<ExpenseTransactionRequestFilterDto>
{
    public ExpenseTransactionRequestFilterValidator()
    {
        RuleFor(expenseTransactionRequestFilter => expenseTransactionRequestFilter.StartActionDate)
            .LessThanOrEqualTo(expenseTransactionRequestFilter => expenseTransactionRequestFilter.EndActionDate)
            .When(expenseTransactionRequestFilter => expenseTransactionRequestFilter.EndActionDate.HasValue)
            .WithMessage("Start date should be less than or equal to end date!")
            .WithName(expenseTransactionRequestFilter => nameof(expenseTransactionRequestFilter.StartActionDate));

        RuleFor(expenseTransactionRequestFilter => expenseTransactionRequestFilter.EndActionDate)
            .GreaterThanOrEqualTo(expenseTransactionRequestFilter => expenseTransactionRequestFilter.StartActionDate)
            .When(expenseTransactionRequestFilter => expenseTransactionRequestFilter.StartActionDate.HasValue)
            .WithMessage("End date should be greater than or equal to start date!")
            .WithName(expenseTransactionRequestFilter => nameof(expenseTransactionRequestFilter.EndActionDate));

        RuleFor(expenseTransactionRequestFilter => expenseTransactionRequestFilter.ExpenseTraceId)
            .Cascade(CascadeMode.Stop)
            .GreaterThan(0)
            .WithMessage("Expense trace Id should be greater than 0!")
            .WithName(expenseTransactionRequestFilter => nameof(expenseTransactionRequestFilter.ExpenseTraceId));
    }
}