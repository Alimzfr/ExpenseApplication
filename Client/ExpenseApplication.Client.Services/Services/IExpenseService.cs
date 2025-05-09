namespace ExpenseApplication.Client.Services.Services;

public interface IExpenseService
{
    Task<BaseResponseDto<List<ExpenseDto>>> GetEmployeeExpensesAsync(ExpenseRequestFilterDto expenseRequestFilter, CancellationToken cancellationToken = default(CancellationToken));
    Task<BaseResponseDto<ExpenseFormDto>> GetUserExpenseFormByIdAsync(int expenseId, CancellationToken cancellationToken = default(CancellationToken));
    Task<BaseResponseDto<List<ExpenseDto>>> GetManagerExpensesAsync(ExpenseRequestFilterDto expenseRequestFilter, CancellationToken cancellationToken = default(CancellationToken));
    Task<BaseResponseDto<List<ExpenseDto>>> GetAccountantExpensesAsync(ExpenseRequestFilterDto expenseRequestFilter, CancellationToken cancellationToken = default(CancellationToken));
    Task<BaseResponseDto<List<ExpenseDto>>> GetAdminExpensesAsync(ExpenseRequestFilterDto expenseRequestFilter, CancellationToken cancellationToken = default(CancellationToken));
    Task<BaseResponseDto<ExpenseDto>> ApproveExpenseAsync(ApproveExpenseFormDto approveExpenseForm, CancellationToken cancellationToken = default(CancellationToken));
    Task<BaseResponseDto<ExpenseDto>> RejectExpenseAsync(RejectExpenseFormDto rejectExpenseForm, CancellationToken cancellationToken = default(CancellationToken));
    Task<BaseResponseDto<ExpenseDto>> PayExpenseAsync(PayExpenseFormDto payExpenseForm, CancellationToken cancellationToken = default(CancellationToken));
    Task<BaseResponseDto<ExpenseDto>> CreateExpenseAsync(ExpenseFormDto expenseForm, CancellationToken cancellationToken = default(CancellationToken));
    Task<BaseResponseDto<ExpenseDto>> UpdateExpenseAsync(ExpenseFormDto expenseForm, CancellationToken cancellationToken = default(CancellationToken));
}