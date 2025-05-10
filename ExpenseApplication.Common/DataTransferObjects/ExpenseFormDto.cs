using ExpenseApplication.Common.Enums;

namespace ExpenseApplication.Common.DataTransferObjects;

public class ExpenseFormDto
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string? Description { get; set; }
    public CurrencyType CurrencyType { get; set; }
    public List<ExpenseItemDto> ExpenseItems { get; set; } = [];
}