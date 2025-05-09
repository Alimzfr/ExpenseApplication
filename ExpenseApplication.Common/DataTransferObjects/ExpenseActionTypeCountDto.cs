using ExpenseApplication.Common.Enums;

namespace ExpenseApplication.Common.DataTransferObjects;

public class ExpenseActionTypeCountDto
{
    public ExpenseActionType ExpenseActionType { get; set; }
    public int Count { get; set; }
}