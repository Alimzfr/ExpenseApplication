namespace ExpenseApplication.Server.Application.Features.AccountantExpenseUseCase.Queries.GetAccountantExpenses;

public class GetAccountantExpensesHandler(IUnitOfWork unitOfWork, IMapper mapper) : IQueryHandler<GetAccountantExpensesQuery, GetAccountantExpensesQueryResult>
{
    public async Task<GetAccountantExpensesQueryResult> Handle(GetAccountantExpensesQuery request, CancellationToken cancellationToken)
    {
        var expenseDbSet = unitOfWork.Set<Expense>();

        var expenses = await expenseDbSet.AsNoTracking()
            .Where(expense => !request.ExpenseRequestFilter.TraceId.HasValue || (expense.TraceId == request.ExpenseRequestFilter.TraceId))
            .Where(expense => !request.ExpenseRequestFilter.ExpenseStatus.HasValue || (expense.ExpenseStatus == request.ExpenseRequestFilter.ExpenseStatus))
            .Where(expense => !request.ExpenseRequestFilter.CurrencyType.HasValue || (expense.CurrencyType == request.ExpenseRequestFilter.CurrencyType))
            .Where(expense => !request.ExpenseRequestFilter.MaxTotalAmount.HasValue || (expense.ExpenseItems.Sum(expenseItem => expenseItem.Amount) <= request.ExpenseRequestFilter.MaxTotalAmount))
            .Include(expense => expense.User)
            .Include(expense => expense.ExpenseItems)
            .Include(expense => expense.ExpenseTransactions)
            .OrderByDescending(expense => expense.ModifyDate)
            .ToListAsync(cancellationToken);

        var mappedExpenses = mapper.Map<List<ExpenseDto>>(expenses);

        return new GetAccountantExpensesQueryResult(mappedExpenses);
    }
}