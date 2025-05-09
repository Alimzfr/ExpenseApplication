namespace ExpenseApplication.Server.Application.Features.EmployeeExpenseUseCase.Queries.GetUserExpenseFormById;

public class GetUserExpenseFormByIdHandler(IUnitOfWork unitOfWork, IMapper mapper) : IQueryHandler<GetUserExpenseFormByIdQuery, GetUserExpenseFormByIdQueryResult>
{
    public async Task<GetUserExpenseFormByIdQueryResult> Handle(GetUserExpenseFormByIdQuery request, CancellationToken cancellationToken)
    {
        var expenseDbSet = unitOfWork.Set<Expense>();

        var expense = await expenseDbSet.AsNoTracking()
            .Where(expense => expense.UserId == request.UserId)
            .Where(expense => expense.Id == request.ExpenseId)
            .Include(expense => expense.User)
            .Include(expense => expense.ExpenseItems)
            .FirstOrDefaultAsync(cancellationToken);

        if (expense is null)
        {
            throw new NotFoundException("Expense form does not exist.");
        }

        var mappedExpense = mapper.Map<ExpenseFormDto>(expense);

        return new GetUserExpenseFormByIdQueryResult(mappedExpense);
    }
}