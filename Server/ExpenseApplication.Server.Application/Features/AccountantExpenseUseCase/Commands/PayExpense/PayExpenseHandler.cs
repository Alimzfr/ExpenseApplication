namespace ExpenseApplication.Server.Application.Features.AccountantExpenseUseCase.Commands.PayExpense;

public class PayExpenseHandler(IUnitOfWork unitOfWork) : ICommandHandler<PayExpenseCommand, PayExpenseCommandResult>
{
    public async Task<PayExpenseCommandResult> Handle(PayExpenseCommand request, CancellationToken cancellationToken)
    {
        var userDbSet = unitOfWork.Set<User>();
        var expenseDbSet = unitOfWork.Set<Expense>();
        var expenseTransactionDbSet = unitOfWork.Set<ExpenseTransaction>();

        var user = userDbSet.FirstOrDefault(user => user.Id == request.UserId);
        if (user is null)
        {
            throw new InValidUserException("User is not valid!");
        }

        var expense = await expenseDbSet.FirstOrDefaultAsync(expense => expense.Id == request.PayExpenseForm.ExpenseId, cancellationToken);
        if (expense is null)
        {
            throw new NotFoundException("Expense does not exist!");
        }

        if (expense?.ExpenseStatus is not ExpenseStatus.Approved)
        {
            throw new BadRequestException("Expenses can not be paid in this status!");
        }

        expense.ExpenseStatus = ExpenseStatus.Paid;
        expense.ModifiedDateTime = request.CurrentDateTime;
        expense.ModifiedBy = user.Username;
        expenseTransactionDbSet.Add(new ExpenseTransaction
        {
            UserId = request.UserId,
            ActionDateTime = request.CurrentDateTime,
            ActionType = ExpenseActionType.Payment,
            ExpenseId = request.PayExpenseForm.ExpenseId,
            Comments = request.PayExpenseForm.Comments
        });
        await unitOfWork.SaveChangesAsync(cancellationToken);

        return new PayExpenseCommandResult(true);
    }
}