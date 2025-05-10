namespace ExpenseApplication.Server.Application.Features.EmployeeExpenseUseCase.Commands.CreateExpense;

public class CreateExpenseHandler(IUnitOfWork unitOfWork, IMapper mapper) : ICommandHandler<CreateExpenseCommand, CreateExpenseCommandResult>
{
    public async Task<CreateExpenseCommandResult> Handle(CreateExpenseCommand request, CancellationToken cancellationToken)
    {
        var userDbSet = unitOfWork.Set<User>();
        var expenseDbSet = unitOfWork.Set<Expense>();
        var expenseTransactionDbSet = unitOfWork.Set<ExpenseTransaction>();

        var user = userDbSet.FirstOrDefault(user => user.Id == request.UserId);
        if (user is null)
        {
            throw new InValidUserException("User is not valid!");
        }

        var mappedExpense = mapper.Map<Expense>(request.ExpenseForm);
        var mappedExpenseItems = mapper.Map<List<ExpenseItem>>(request.ExpenseForm.ExpenseItems);
        mappedExpense.UserId = request.UserId;
        mappedExpense.TraceId = (1000 + expenseDbSet.AsNoTracking().Count());
        mappedExpense.ExpenseStatus = ExpenseStatus.Pending;
        mappedExpense.CreatedDateTime = request.CurrentDateTime;
        mappedExpense.CreatedBy = user.Username;
        mappedExpense.ExpenseItems = mappedExpenseItems;

        var expenseTransaction = new ExpenseTransaction
        {
            UserId = request.UserId,
            ActionType = ExpenseActionType.Submit,
            ActionDateTime = request.CurrentDateTime,
            Comments = null,
            Expense = mappedExpense
        };

        var expenseTransactionEntityEntry = expenseTransactionDbSet.Add(expenseTransaction);

        await unitOfWork.SaveChangesAsync(cancellationToken);

        return new CreateExpenseCommandResult(expenseTransactionEntityEntry.Entity.ExpenseId);
    }
}