namespace ExpenseApplication.Server.Application.Features.ManagerExpenseUseCase.Queries.GetManagerExpenses;

public class GetManagerExpensesHandler(IUnitOfWork unitOfWork, IMapper mapper) : IQueryHandler<GetManagerExpensesQuery, GetManagerExpensesQueryResult>
{
    public async Task<GetManagerExpensesQueryResult> Handle(GetManagerExpensesQuery request, CancellationToken cancellationToken)
    {
        var expenseDbSet = unitOfWork.Set<Expense>();
        var managerEmployeeDbSet = unitOfWork.Set<ManagerEmployee>();

        var employeeIds = await managerEmployeeDbSet.AsNoTracking()
            .Where(managerEmployee => managerEmployee.ManagerId == request.ManagerId)
            .Select(employee => employee.EmployeeId)
            .ToListAsync(cancellationToken);

        if (employeeIds?.Any() is not true)
        {
            return new GetManagerExpensesQueryResult([]);
        }

        var expenses = await expenseDbSet.AsNoTracking()
            .Where(expense => employeeIds.Contains(expense.UserId))
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

        return new GetManagerExpensesQueryResult(mappedExpenses);
    }
}