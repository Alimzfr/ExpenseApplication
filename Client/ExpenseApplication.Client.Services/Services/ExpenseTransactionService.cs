namespace ExpenseApplication.Client.Services.Services;

public class ExpenseTransactionService(IApiService apiService) : IExpenseTransactionService
{
    public async Task<BaseResponseDto<List<ExpenseTransactionDto>>> GetExpenseTransactions(ExpenseTransactionRequestFilterDto expenseTransactionRequestFilter, CancellationToken cancellationToken = default(CancellationToken))
    {
        var queryParams = new Dictionary<string, string?>
        {
            { nameof(expenseTransactionRequestFilter.ExpenseTraceId), expenseTransactionRequestFilter.ExpenseTraceId?.ToString() },
            { nameof(expenseTransactionRequestFilter.ActionType), expenseTransactionRequestFilter.ActionType?.ToString() },
            { nameof(expenseTransactionRequestFilter.StartActionDate), expenseTransactionRequestFilter.StartActionDate?.ToString() },
            { nameof(expenseTransactionRequestFilter.EndActionDate), expenseTransactionRequestFilter.EndActionDate?.ToString() }
        };
        var response = await apiService.Get<BaseResponseDto<List<ExpenseTransactionDto>>>(ApiAddressConstants.AdminGetExpenseTransactions, queryParams, cancellationToken);
        return response;
    }
}