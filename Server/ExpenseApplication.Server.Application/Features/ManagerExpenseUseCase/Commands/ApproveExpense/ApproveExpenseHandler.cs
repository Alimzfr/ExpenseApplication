namespace ExpenseApplication.Server.Application.Features.ManagerExpenseUseCase.Commands.ApproveExpense;

public class ApproveExpenseHandler(IUnitOfWork unitOfWork) : ICommandHandler<ApproveExpenseCommand, ApproveExpenseCommandResult>
{
    public async Task<ApproveExpenseCommandResult> Handle(ApproveExpenseCommand request, CancellationToken cancellationToken)
    {
        var userDbSet = unitOfWork.Set<User>();
        var expenseDbSet = unitOfWork.Set<Expense>();
        var expenseTransactionDbSet = unitOfWork.Set<ExpenseTransaction>();

        var user = userDbSet.FirstOrDefault(user => user.Id == request.UserId);
        if (user is null)
        {
            throw new InValidUserException("User is not valid!");
        }

        var expense = await expenseDbSet
            .Where(expense => expense.Id == request.ApproveExpenseForm.ExpenseId)
            .Where(expense => expense.User.EmployeeManagers.Select(employeeManagers => employeeManagers.Manager.Id).Contains(request.UserId))
            .FirstOrDefaultAsync(cancellationToken);
        if (expense is null)
        {
            throw new NotFoundException("Expense does not exist!");
        }

        if (expense?.ExpenseStatus is not ExpenseStatus.Pending)
        {
            throw new BadRequestException("Expenses can not be approved in this status!");
        }

        expense.ExpenseStatus = ExpenseStatus.Approved;
        expense.ModifiedDateTime = request.CurrentDateTime;
        expense.ModifiedBy = user.Username;
        expenseTransactionDbSet.Add(new ExpenseTransaction
        {
            UserId = request.UserId,
            ActionDateTime = request.CurrentDateTime,
            ActionType = ExpenseActionType.Approve,
            ExpenseId = request.ApproveExpenseForm.ExpenseId,
            Comments = request.ApproveExpenseForm.Comments
        });
        await unitOfWork.SaveChangesAsync(cancellationToken);

        return new ApproveExpenseCommandResult(true);
    }
}