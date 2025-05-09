namespace ExpenseApplication.Common.DataTransferObjects;

public class ExpenseActionTypeMonthlyCountDto
{
    public int MonthNumber { get; set; }
    public ExpenseActionTypeCountDto ExpenseActionTypeCount { get; set; }
}