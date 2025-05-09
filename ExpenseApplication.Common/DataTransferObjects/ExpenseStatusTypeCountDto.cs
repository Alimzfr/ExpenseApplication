using ExpenseApplication.Common.Enums;

namespace ExpenseApplication.Common.DataTransferObjects;

public class ExpenseStatusTypeCountDto
{
    public ExpenseStatus ExpenseStatus { get; set; }
    public int Count { get; set; }
}