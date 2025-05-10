namespace ExpenseApplication.Server.Application.Features.AdminExpenseUseCase.Queries.GetTotalPaidExpensesMonthlyAmountReport;

public class GetTotalPaidExpensesMonthlyAmountReportHandler(IUnitOfWork unitOfWork) : IQueryHandler<GetTotalPaidExpensesMonthlyAmountReportQuery, GetTotalPaidExpensesMonthlyAmountReportQueryResult>
{
    public async Task<GetTotalPaidExpensesMonthlyAmountReportQueryResult> Handle(GetTotalPaidExpensesMonthlyAmountReportQuery request, CancellationToken cancellationToken)
    {
        var expenseDbSet = unitOfWork.Set<Expense>();

        var totalPaidExpensesMonthlyAmounts = await expenseDbSet.AsNoTracking()
            .Where(expense => expense.CreatedDateTime.Year == request.Year)
            .GroupBy(expense => new { expense.CurrencyType, expense.CreatedDateTime.Month })
            .Select(grouping => new TotalPaidExpensesMonthlyAmountDto
            {
                MonthNumber = grouping.Key.Month,
                CurrencyTypeTotalPaidExpensesAmount = new CurrencyTypeTotalPaidExpensesAmountDto
                {
                    CurrencyType = grouping.Key.CurrencyType,
                    TotalPaidExpensesAmount = grouping.SelectMany(expense => expense.ExpenseItems).Sum(item => item.Amount)
                }
            })
            .OrderBy(dto => dto.MonthNumber)
            .ToListAsync(cancellationToken);

        return new GetTotalPaidExpensesMonthlyAmountReportQueryResult(totalPaidExpensesMonthlyAmounts);
    }
}