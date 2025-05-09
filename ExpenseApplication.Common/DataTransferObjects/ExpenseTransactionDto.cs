using ExpenseApplication.Common.Enums;

namespace ExpenseApplication.Common.DataTransferObjects;

public class ExpenseTransactionDto
{
    public int Id { get; set; }
    public int ExpenseTraceId { get; set; }
    public string ExpenseTitle { get; set; }
    public CurrencyType CurrencyType { get; set; }
    public string ExpenseUsername { get; set; }
    public string TransactedByUsername { get; set; }
    public ExpenseActionType ActionType { get; set; }
    public DateTime ActionDateTime { get; set; }
    public string? Comments { get; set; }
}