namespace ExpenseApplication.Server.Application.Validators;

public class CreateExpenseCommandValidator : AbstractValidator<CreateExpenseCommand>
{
    public CreateExpenseCommandValidator()
    {
        RuleFor(createExpenseCommand => createExpenseCommand.UserId)
            .NotNull()
            .WithMessage("UserId is required!")
            .WithName(createExpenseCommand => nameof(createExpenseCommand.UserId));

        RuleFor(createExpenseCommand => createExpenseCommand.CurrentDateTime)
            .NotNull()
            .WithMessage("CurrentDateTime is required!")
            .WithName(createExpenseCommand => nameof(createExpenseCommand.CurrentDateTime));

        RuleFor(createExpenseCommand => createExpenseCommand.ExpenseForm)
            .Cascade(CascadeMode.Stop)
            .NotNull()
            .WithMessage("ExpenseForm is required!")
            .DependentRules(() => RuleFor(v => v.ExpenseForm).SetValidator(new ExpenseFormValidator()));
    }
}