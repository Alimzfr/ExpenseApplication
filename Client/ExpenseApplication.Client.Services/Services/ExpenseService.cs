namespace ExpenseApplication.Client.Services.Services;

public class ExpenseService(IApiService apiService) : IExpenseService
{
    public async Task<BaseResponseDto<List<ExpenseDto>>> GetEmployeeExpensesAsync(ExpenseRequestFilterDto expenseRequestFilter, CancellationToken cancellationToken = default(CancellationToken))
    {
        var queryParams = new Dictionary<string, string?>
        {
            { nameof(expenseRequestFilter.TraceId), expenseRequestFilter.TraceId?.ToString() },
            { nameof(expenseRequestFilter.MaxTotalAmount), expenseRequestFilter.MaxTotalAmount?.ToString() },
            { nameof(expenseRequestFilter.ExpenseStatus), expenseRequestFilter.ExpenseStatus?.ToString() },
            { nameof(expenseRequestFilter.CurrencyType), expenseRequestFilter.CurrencyType?.ToString() }
        };
        var response = await apiService.Get<BaseResponseDto<List<ExpenseDto>>>(ApiAddressConstants.EmployeeGetExpenses, queryParams, cancellationToken);
        return response;
    }

    public async Task<BaseResponseDto<ExpenseFormDto>> GetUserExpenseFormByIdAsync(int expenseId, CancellationToken cancellationToken = default(CancellationToken))
    {
        var queryParams = new Dictionary<string, string?>
        {
            { nameof(expenseId), expenseId.ToString() }
        };
        var response = await apiService.Get<BaseResponseDto<ExpenseFormDto>>(ApiAddressConstants.EmployeeGetUserExpenseFormById, queryParams, cancellationToken);
        return response;
    }

    public async Task<BaseResponseDto<List<ExpenseDto>>> GetManagerExpensesAsync(ExpenseRequestFilterDto expenseRequestFilter, CancellationToken cancellationToken = default(CancellationToken))
    {
        var queryParams = new Dictionary<string, string?>
        {
            { nameof(expenseRequestFilter.TraceId), expenseRequestFilter.TraceId?.ToString() },
            { nameof(expenseRequestFilter.MaxTotalAmount), expenseRequestFilter.MaxTotalAmount?.ToString() },
            { nameof(expenseRequestFilter.ExpenseStatus), expenseRequestFilter.ExpenseStatus?.ToString() },
            { nameof(expenseRequestFilter.CurrencyType), expenseRequestFilter.CurrencyType?.ToString() }
        };
        var response = await apiService.Get<BaseResponseDto<List<ExpenseDto>>>(ApiAddressConstants.ManagerGetExpenses, queryParams, cancellationToken);
        return response;
    }

    public async Task<BaseResponseDto<List<ExpenseDto>>> GetAccountantExpensesAsync(ExpenseRequestFilterDto expenseRequestFilter, CancellationToken cancellationToken = default(CancellationToken))
    {
        var queryParams = new Dictionary<string, string?>
        {
            { nameof(expenseRequestFilter.TraceId), expenseRequestFilter.TraceId?.ToString() },
            { nameof(expenseRequestFilter.MaxTotalAmount), expenseRequestFilter.MaxTotalAmount?.ToString() },
            { nameof(expenseRequestFilter.ExpenseStatus), expenseRequestFilter.ExpenseStatus?.ToString() },
            { nameof(expenseRequestFilter.CurrencyType), expenseRequestFilter.CurrencyType?.ToString() }
        };
        var response = await apiService.Get<BaseResponseDto<List<ExpenseDto>>>(ApiAddressConstants.AccountantGetExpenses, queryParams, cancellationToken);
        return response;
    }

    public async Task<BaseResponseDto<List<ExpenseDto>>> GetAdminExpensesAsync(ExpenseRequestFilterDto expenseRequestFilter, CancellationToken cancellationToken = default(CancellationToken))
    {
        var queryParams = new Dictionary<string, string?>
        {
            { nameof(expenseRequestFilter.TraceId), expenseRequestFilter.TraceId?.ToString() },
            { nameof(expenseRequestFilter.MaxTotalAmount), expenseRequestFilter.MaxTotalAmount?.ToString() },
            { nameof(expenseRequestFilter.ExpenseStatus), expenseRequestFilter.ExpenseStatus?.ToString() },
            { nameof(expenseRequestFilter.CurrencyType), expenseRequestFilter.CurrencyType?.ToString() }
        };
        var response = await apiService.Get<BaseResponseDto<List<ExpenseDto>>>(ApiAddressConstants.AdminGetExpenses, queryParams, cancellationToken);
        return response;
    }

    public async Task<BaseResponseDto<ExpenseDto>> ApproveExpenseAsync(ApproveExpenseFormDto approveExpenseForm, CancellationToken cancellationToken = default(CancellationToken))
    {
        var response = await apiService.Patch<ApproveExpenseFormDto, BaseResponseDto<ExpenseDto>>(ApiAddressConstants.ManagerApproveExpense, approveExpenseForm, cancellationToken);
        return response;
    }

    public async Task<BaseResponseDto<ExpenseDto>> RejectExpenseAsync(RejectExpenseFormDto rejectExpenseForm, CancellationToken cancellationToken = default(CancellationToken))
    {
        var response = await apiService.Patch<RejectExpenseFormDto, BaseResponseDto<ExpenseDto>>(ApiAddressConstants.ManagerRejectExpense, rejectExpenseForm, cancellationToken);
        return response;
    }

    public async Task<BaseResponseDto<ExpenseDto>> PayExpenseAsync(PayExpenseFormDto payExpenseForm, CancellationToken cancellationToken = default(CancellationToken))
    {
        var response = await apiService.Patch<PayExpenseFormDto, BaseResponseDto<ExpenseDto>>(ApiAddressConstants.AccountantPayExpense, payExpenseForm, cancellationToken);
        return response;
    }

    public async Task<BaseResponseDto<ExpenseDto>> CreateExpenseAsync(ExpenseFormDto expenseForm, CancellationToken cancellationToken = default(CancellationToken))
    {
        var response = await apiService.Post<ExpenseFormDto, BaseResponseDto<ExpenseDto>>(ApiAddressConstants.EmployeeCreateExpense, expenseForm, cancellationToken);
        return response;
    }

    public async Task<BaseResponseDto<ExpenseDto>> UpdateExpenseAsync(ExpenseFormDto expenseForm, CancellationToken cancellationToken = default(CancellationToken))
    {
        var response = await apiService.Put<ExpenseFormDto, BaseResponseDto<ExpenseDto>>(ApiAddressConstants.EmployeeUpdateExpense, expenseForm, cancellationToken);
        return response;
    }
}