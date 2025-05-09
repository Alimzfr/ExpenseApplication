namespace ExpenseApplication.Server.Application.Features.EmployeeExpenseUseCase.Queries.GetEmployeeExpenses;

public class GetEmployeeExpensesHandler(IUnitOfWork unitOfWork, IMapper mapper) : IQueryHandler<GetEmployeeExpensesQuery, GetEmployeeExpensesQueryResult>
{
    public async Task<GetEmployeeExpensesQueryResult> Handle(GetEmployeeExpensesQuery request, CancellationToken cancellationToken)
    {
        var expenseDbSet = unitOfWork.Set<Expense>();

        var expensesQuery = expenseDbSet.AsNoTracking()
            .Where(expense => expense.UserId == request.UserId)
            .Where(expense => !request.ExpenseRequestFilter.TraceId.HasValue || (expense.TraceId == request.ExpenseRequestFilter.TraceId))
            .Where(expense => !request.ExpenseRequestFilter.ExpenseStatus.HasValue || (expense.ExpenseStatus == request.ExpenseRequestFilter.ExpenseStatus))
            .Where(expense => !request.ExpenseRequestFilter.CurrencyType.HasValue || (expense.CurrencyType == request.ExpenseRequestFilter.CurrencyType))
            .Where(expense => !request.ExpenseRequestFilter.MaxTotalAmount.HasValue || (expense.ExpenseItems.Sum(expenseItem => expenseItem.Amount) <= request.ExpenseRequestFilter.MaxTotalAmount))
            .Include(expense => expense.User)
            .Include(expense => expense.ExpenseItems)
            .Include(expense => expense.ExpenseTransactions)
            .OrderByDescending(expense => expense.ModifyDate);

        var expenses = await expensesQuery.ToListAsync(cancellationToken);

        var mappedExpenses = mapper.Map<List<ExpenseDto>>(expenses);

        return new GetEmployeeExpensesQueryResult(mappedExpenses);
    }
}