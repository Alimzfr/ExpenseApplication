namespace ExpenseApplication.Server.Application.Features.AdminExpenseUseCase.Queries.GetExpenseStatusTypeMonthlyCountReport;

public class GetExpenseStatusTypeMonthlyCountReportHandler(IUnitOfWork unitOfWork) : IQueryHandler<GetExpenseStatusTypeMonthlyCountReportQuery, GetExpenseStatusTypeMonthlyCountReportQueryResult>
{
    public async Task<GetExpenseStatusTypeMonthlyCountReportQueryResult> Handle(GetExpenseStatusTypeMonthlyCountReportQuery request, CancellationToken cancellationToken)
    {
        var expenseDbSet = unitOfWork.Set<Expense>();

        var expenseStatusTypeMonthlyCounts = await expenseDbSet.AsNoTracking()
            .Where(expense => expense.CreatedDateTime.Year == request.Year)
            .GroupBy(expense => new { expense.ExpenseStatus, expense.CreatedDateTime.Month })
            .Select(grouping => new ExpenseStatusTypeMonthlyCountDto
            {
                MonthNumber = grouping.Key.Month,
                ExpenseStatusTypeCount = new ExpenseStatusTypeCountDto
                {
                    Count = grouping.Count(),
                    ExpenseStatus = grouping.Key.ExpenseStatus
                }
            })
            .OrderBy(expenseStatusTypeMonthlyCount => expenseStatusTypeMonthlyCount.MonthNumber)
            .ToListAsync(cancellationToken);

        return new GetExpenseStatusTypeMonthlyCountReportQueryResult(expenseStatusTypeMonthlyCounts);
    }
}