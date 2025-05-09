namespace ExpenseApplication.Server.Application.Features.AdminExpenseUseCase.Queries.GetExpenseTransactions;

public class GetExpenseTransactionsHandler(IUnitOfWork unitOfWork, IMapper mapper) : IQueryHandler<GetExpenseTransactionsQuery, GetExpenseTransactionsQueryResult>
{
    public async Task<GetExpenseTransactionsQueryResult> Handle(GetExpenseTransactionsQuery request, CancellationToken cancellationToken)
    {
        var expenseTransactionDbSet = unitOfWork.Set<ExpenseTransaction>();

        var expenseTransactions = await expenseTransactionDbSet.AsNoTracking()
            .Where(expense => !request.ExpenseTransactionRequestFilter.ExpenseTraceId.HasValue || (expense.Expense.TraceId == request.ExpenseTransactionRequestFilter.ExpenseTraceId))
            .Where(expense => !request.ExpenseTransactionRequestFilter.ActionType.HasValue || (expense.ActionType == request.ExpenseTransactionRequestFilter.ActionType))
            .Where(expense => !request.ExpenseTransactionRequestFilter.StartActionDate.HasValue || expense.ActionDateTime.Date >= request.ExpenseTransactionRequestFilter.StartActionDate.Value.Date)
            .Where(expense => !request.ExpenseTransactionRequestFilter.EndActionDate.HasValue || expense.ActionDateTime.Date <= request.ExpenseTransactionRequestFilter.EndActionDate.Value.Date)
            .Include(expense => expense.User)
            .Include(expense => expense.Expense)
            .ThenInclude(expense => expense.User)
            .OrderByDescending(expenseTransaction => expenseTransaction.ActionDateTime)
            .ToListAsync(cancellationToken);

        var mappedExpenseTransactions = mapper.Map<List<ExpenseTransactionDto>>(expenseTransactions);

        return new GetExpenseTransactionsQueryResult(mappedExpenseTransactions);
    }
}