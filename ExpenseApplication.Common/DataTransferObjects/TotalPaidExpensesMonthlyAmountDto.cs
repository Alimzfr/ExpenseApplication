namespace ExpenseApplication.Common.DataTransferObjects;

public class TotalPaidExpensesMonthlyAmountDto
{
    public int MonthNumber { get; set; }
    public CurrencyTypeTotalPaidExpensesAmountDto CurrencyTypeTotalPaidExpensesAmount { get; set; }
}