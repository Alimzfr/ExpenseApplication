namespace ExpenseApplication.Common.DataTransferObjects;

public class ExpenseStatusTypeMonthlyCountDto
{
    public int MonthNumber { get; set; }
    public ExpenseStatusTypeCountDto ExpenseStatusTypeCount { get; set; }
}