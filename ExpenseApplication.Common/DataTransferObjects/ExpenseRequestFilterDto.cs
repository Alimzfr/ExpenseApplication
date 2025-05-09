using ExpenseApplication.Common.Enums;

namespace ExpenseApplication.Common.DataTransferObjects;

public class ExpenseRequestFilterDto
{
    public int? TraceId { get; set; }
    public decimal? MaxTotalAmount { get; set; }
    public ExpenseStatus? ExpenseStatus { get; set; }
    public CurrencyType? CurrencyType { get; set; }
}