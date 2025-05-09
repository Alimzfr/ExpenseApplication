using FluentValidation;

namespace ExpenseApplication.Client.Services.Validators;

public class ExpenseRequestFilterValidator : AbstractValidator<ExpenseRequestFilterDto>
{
    public ExpenseRequestFilterValidator()
    {
        RuleFor(expenseRequestFilter => expenseRequestFilter.TraceId)
            .GreaterThan(0)
            .WithMessage("Trace Id should be greater than 0!")
            .WithName(expenseRequestFilter => nameof(expenseRequestFilter.TraceId));

        RuleFor(expenseRequestFilter => expenseRequestFilter.MaxTotalAmount)
            .Cascade(CascadeMode.Stop)
            .GreaterThan(0)
            .WithMessage("Max Total Amount should be greater than 0!")
            .LessThanOrEqualTo(5000)
            .WithMessage("Max Total Amount should be less than or equal to 5000!")
            .WithName(expenseRequestFilter => nameof(expenseRequestFilter.MaxTotalAmount));
    }
}