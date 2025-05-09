namespace ExpenseApplication.Server.Application.Validators;

public class UpdateExpenseCommandValidator : AbstractValidator<UpdateExpenseCommand>
{
    public UpdateExpenseCommandValidator()
    {
        RuleFor(updateExpenseCommand => updateExpenseCommand.UserId)
            .NotNull()
            .NotEqual(default(int))
            .WithMessage("UserId is required!")
            .WithName(updateExpenseCommand => nameof(updateExpenseCommand.UserId));

        RuleFor(updateExpenseCommand => updateExpenseCommand.CurrentDateTime)
            .NotNull()
            .NotEqual(default(DateTime))
            .WithMessage("CurrentDateTime is required!")
            .WithName(updateExpenseCommand => nameof(updateExpenseCommand.CurrentDateTime));

        RuleFor(updateExpenseCommand => updateExpenseCommand.ExpenseForm)
            .Cascade(CascadeMode.Stop)
            .NotNull()
            .WithMessage("ExpenseForm is required!")
            .WithName(updateExpenseCommand => nameof(updateExpenseCommand.ExpenseForm))
            .DependentRules(() => RuleFor(v => v.ExpenseForm).SetValidator(new ExpenseFormValidator()));

        RuleFor(command => command.ExpenseForm.Id)
            .NotNull()
            .NotEqual(default(int))
            .WithMessage("ExpenseFormId is required!")
            .WithName("ExpenseFormId");
    }
}