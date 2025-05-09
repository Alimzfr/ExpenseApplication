namespace ExpenseApplication.Server.Application.Validators;

public class RejectExpenseCommandValidator : AbstractValidator<RejectExpenseCommand>
{
    public RejectExpenseCommandValidator()
    {
        RuleFor(rejectExpenseCommand => rejectExpenseCommand.UserId)
            .NotNull()
            .NotEqual(default(int))
            .WithMessage("UserId is required!")
            .WithName(rejectExpenseCommand => nameof(rejectExpenseCommand.UserId));

        RuleFor(rejectExpenseCommand => rejectExpenseCommand.CurrentDateTime)
            .NotNull()
            .NotEqual(default(DateTime))
            .WithMessage("CurrentDateTime is required!")
            .WithName(rejectExpenseCommand => nameof(rejectExpenseCommand.CurrentDateTime));

        RuleFor(rejectExpenseCommand => rejectExpenseCommand.RejectExpenseForm)
            .Cascade(CascadeMode.Stop)
            .NotNull()
            .WithMessage("RejectExpenseForm is required!")
            .WithName(rejectExpenseCommand => nameof(rejectExpenseCommand.RejectExpenseForm))
            .DependentRules(() => RuleFor(rejectExpenseCommand => rejectExpenseCommand.RejectExpenseForm).SetValidator(new RejectExpenseFormValidator()));
    }
}