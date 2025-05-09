namespace ExpenseApplication.Server.Application.Features.AdminExpenseUseCase.Queries.GetExpenseStatusTypeCountReport;

public class GetExpenseStatusTypeCountReportHandler(IUnitOfWork unitOfWork) : IQueryHandler<GetExpenseStatusTypeCountReportQuery, GetExpenseStatusTypeCountReportQueryResult>
{
    public async Task<GetExpenseStatusTypeCountReportQueryResult> Handle(GetExpenseStatusTypeCountReportQuery request, CancellationToken cancellationToken)
    {
        var expenseDbSet = unitOfWork.Set<Expense>();

        var expenseStatusTypeCounts = await expenseDbSet.AsNoTracking()
            .GroupBy(expense => expense.ExpenseStatus)
            .Select(grouping => new ExpenseStatusTypeCountDto
            {
                ExpenseStatus = grouping.Key,
                Count = grouping.Count()
            })
            .ToListAsync(cancellationToken);

        var expenseStatuses = Enum.GetValues(typeof(ExpenseStatus)).Cast<ExpenseStatus>();
        foreach (var expenseStatus in expenseStatuses)
        {
            if (!expenseStatusTypeCounts.Select(expenseStatusTypeCount => expenseStatusTypeCount.ExpenseStatus).Contains(expenseStatus))
            {
                expenseStatusTypeCounts.Add(new ExpenseStatusTypeCountDto
                {
                    ExpenseStatus = expenseStatus,
                    Count = 0
                });
            }
        }

        var sortedExpenseStatusTypeCounts = expenseStatusTypeCounts.OrderBy(dto => dto.ExpenseStatus).ToList();

        return new GetExpenseStatusTypeCountReportQueryResult(sortedExpenseStatusTypeCounts);
    }
}