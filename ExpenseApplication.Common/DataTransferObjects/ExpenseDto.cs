using ExpenseApplication.Common.Enums;

namespace ExpenseApplication.Common.DataTransferObjects;

public class ExpenseDto
{
    public int Id { get; set; }
    public int TraceId { get; set; }
    public string Username { get; set; }
    public string Title { get; set; }
    public string? Description { get; set; }
    public CurrencyType CurrencyType { get; set; }
    public ExpenseStatus ExpenseStatus { get; set; }
    public DateTime CreatedDate { get; set; }
    public DateTime ModifyDate { get; set; }
    public string? Comments { get; set; }
    public List<ExpenseItemDto> ExpenseItems { get; set; }
}