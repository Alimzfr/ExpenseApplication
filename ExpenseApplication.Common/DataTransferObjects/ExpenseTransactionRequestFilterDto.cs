using ExpenseApplication.Common.Enums;

namespace ExpenseApplication.Common.DataTransferObjects;

public class ExpenseTransactionRequestFilterDto
{
    public int? ExpenseTraceId { get; set; }
    public ExpenseActionType? ActionType { get; set; }
    public DateTime? StartActionDate { get; set; }
    public DateTime? EndActionDate { get; set; }
}