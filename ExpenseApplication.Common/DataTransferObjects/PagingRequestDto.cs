namespace ExpenseApplication.Common.DataTransferObjects;

public class PagingRequestDto
{
    public int PageSize { get; set; }
    public int PageNumber { get; set; }
}