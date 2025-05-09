namespace ExpenseApplication.Common.DataTransferObjects;

public class ExpenseItemDto
{
    public int Id { get; set; }
    public string Purpose { get; set; }
    public decimal Amount { get; set; }
}