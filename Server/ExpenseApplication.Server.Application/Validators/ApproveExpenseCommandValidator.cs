namespace ExpenseApplication.Server.Application.Validators;

public class ApproveExpenseCommandValidator : AbstractValidator<ApproveExpenseCommand>
{
    public ApproveExpenseCommandValidator()
    {
        RuleFor(approveExpenseCommand => approveExpenseCommand.UserId)
            .NotNull()
            .NotEqual(default(int))
            .WithMessage("UserId is required!")
            .WithName(approveExpenseCommand => nameof(approveExpenseCommand.UserId));

        RuleFor(approveExpenseCommand => approveExpenseCommand.CurrentDateTime)
            .NotNull()
            .NotEqual(default(DateTime))
            .WithMessage("CurrentDateTime is required!")
            .WithName(approveExpenseCommand => nameof(approveExpenseCommand.CurrentDateTime));

        RuleFor(approveExpenseCommand => approveExpenseCommand.ApproveExpenseForm)
            .Cascade(CascadeMode.Stop)
            .NotNull()
            .WithMessage("ApproveExpenseForm is required!")
            .WithName(approveExpenseCommand => nameof(approveExpenseCommand.ApproveExpenseForm))
            .DependentRules(() => RuleFor(approveExpenseCommand => approveExpenseCommand.ApproveExpenseForm).SetValidator(new ApproveExpenseFormValidator()));
    }
}