namespace ExpenseApplication.Server.Application.Features.AdminExpenseUseCase.Queries.GetExpenseActionTypeMonthlyCountReport;

public class GetExpenseActionTypeMonthlyCountReportHandler(IUnitOfWork unitOfWork) : IQueryHandler<GetExpenseActionTypeMonthlyCountReportQuery, GetExpenseActionTypeMonthlyCountReportQueryResult>
{
    public async Task<GetExpenseActionTypeMonthlyCountReportQueryResult> Handle(GetExpenseActionTypeMonthlyCountReportQuery request, CancellationToken cancellationToken)
    {
        var expenseTransactionDbSet = unitOfWork.Set<ExpenseTransaction>();

        var expenseActionTypeMonthlyCounts = await expenseTransactionDbSet.AsNoTracking()
            .Where(x => x.ActionDateTime.Year == request.Year)
            .GroupBy(expenseTransaction => new { expenseTransaction.ActionType, expenseTransaction.ActionDateTime.Month })
            .Select(grouping => new ExpenseActionTypeMonthlyCountDto
            {
                MonthNumber = grouping.Key.Month,
                ExpenseActionTypeCount = new ExpenseActionTypeCountDto
                {
                    Count = grouping.Count(),
                    ExpenseActionType = grouping.Key.ActionType
                }
            })
            .OrderBy(dto => dto.MonthNumber)
            .ToListAsync(cancellationToken);

        return new GetExpenseActionTypeMonthlyCountReportQueryResult(expenseActionTypeMonthlyCounts);
    }
}