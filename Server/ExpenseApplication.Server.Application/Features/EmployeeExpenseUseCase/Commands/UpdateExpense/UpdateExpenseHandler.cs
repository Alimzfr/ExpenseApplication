namespace ExpenseApplication.Server.Application.Features.EmployeeExpenseUseCase.Commands.UpdateExpense;

public class UpdateExpenseHandler(IUnitOfWork unitOfWork, IMapper mapper) : ICommandHandler<UpdateExpenseCommand, UpdateExpenseCommandResult>
{
    public async Task<UpdateExpenseCommandResult> Handle(UpdateExpenseCommand request, CancellationToken cancellationToken)
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
            .Where(expense => expense.Id == request.ExpenseForm.Id)
            .Where(expense => expense.UserId == request.UserId)
            .Include(expense => expense.ExpenseItems)
            .FirstOrDefaultAsync(cancellationToken: cancellationToken);
        if (expense is null)
        {
            throw new NotFoundException("Expense does not exist!");
        }

        if (expense?.ExpenseStatus is not (ExpenseStatus.Pending or ExpenseStatus.Rejected))
        {
            throw new BadRequestException("Expenses can not be edited in this status!");
        }

        expense = request.ExpenseForm.Adapt(expense);
        expense.ExpenseItems = request.ExpenseForm.ExpenseItems.Adapt(expense.ExpenseItems);
        expense.ExpenseStatus = ExpenseStatus.Pending;
        expense.ModifyDate = request.CurrentDateTime;
        expense.ModifiedBy = user.Username;
        expenseTransactionDbSet.Add(new ExpenseTransaction
        {
            UserId = request.UserId,
            ActionDateTime = request.CurrentDateTime,
            ActionType = ExpenseActionType.Edit,
            ExpenseId = request.ExpenseForm.Id,
            Comments = null
        });
        await unitOfWork.SaveChangesAsync(cancellationToken);

        return new UpdateExpenseCommandResult(true);
    }
}