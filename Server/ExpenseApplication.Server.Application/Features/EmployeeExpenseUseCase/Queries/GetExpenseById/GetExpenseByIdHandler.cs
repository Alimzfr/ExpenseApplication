namespace ExpenseApplication.Server.Application.Features.EmployeeExpenseUseCase.Queries.GetExpenseById;

public class GetExpenseByIdHandler(IUnitOfWork unitOfWork, IMapper mapper) : IQueryHandler<GetExpenseByIdQuery, GetExpenseByIdQueryResult>
{
    public async Task<GetExpenseByIdQueryResult> Handle(GetExpenseByIdQuery request, CancellationToken cancellationToken)
    {
        var expenseDbSet = unitOfWork.Set<Expense>();

        var expenses = await expenseDbSet.AsNoTracking()
            .Where(expense => expense.Id == request.ExpenseId)
            .Include(expense => expense.User)
            .Include(expense => expense.ExpenseItems)
            .Include(expense => expense.ExpenseTransactions)
            .FirstOrDefaultAsync(cancellationToken);

        if (expenses is null)
        {
            return new GetExpenseByIdQueryResult(null);
        }

        var mappedExpenses = mapper.Map<ExpenseDto>(expenses);

        return new GetExpenseByIdQueryResult(mappedExpenses);
    }
}