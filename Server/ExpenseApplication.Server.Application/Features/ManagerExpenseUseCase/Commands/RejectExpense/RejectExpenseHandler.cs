using System.Linq;

namespace ExpenseApplication.Server.Application.Features.ManagerExpenseUseCase.Commands.RejectExpense;

public class RejectExpenseHandler(IUnitOfWork unitOfWork) : ICommandHandler<RejectExpenseCommand, RejectExpenseCommandResult>
{
    public async Task<RejectExpenseCommandResult> Handle(RejectExpenseCommand request, CancellationToken cancellationToken)
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
            .Where(expense => expense.Id == request.RejectExpenseForm.ExpenseId)
            .Where(expense => expense.User.EmployeeManagers.Select(employeeManagers => employeeManagers.Manager.Id).Contains(request.UserId))
            .FirstOrDefaultAsync(cancellationToken: cancellationToken);
        if (expense is null)
        {
            throw new NotFoundException("Expense does not exist!");
        }

        if (expense?.ExpenseStatus is not ExpenseStatus.Pending)
        {
            throw new BadRequestException("Expenses can not be rejected in this status!");
        }

        expense.ExpenseStatus = ExpenseStatus.Rejected;
        expense.ModifiedDateTime = request.CurrentDateTime;
        expense.ModifiedBy = user.Username;
        expenseTransactionDbSet.Add(new ExpenseTransaction
        {
            UserId = request.UserId,
            ActionDateTime = request.CurrentDateTime,
            ActionType = ExpenseActionType.Reject,
            ExpenseId = request.RejectExpenseForm.ExpenseId,
            Comments = request.RejectExpenseForm.Comments
        });
        await unitOfWork.SaveChangesAsync(cancellationToken);

        return new RejectExpenseCommandResult(true);
    }
}