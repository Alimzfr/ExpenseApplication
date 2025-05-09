using ExpenseApplication.Common.Enums;

namespace ExpenseApplication.Common.DataTransferObjects;

public class CurrencyTypeTotalPaidExpensesAmountDto
{
    public CurrencyType CurrencyType { get; set; }
    public decimal TotalPaidExpensesAmount { get; set; }
}