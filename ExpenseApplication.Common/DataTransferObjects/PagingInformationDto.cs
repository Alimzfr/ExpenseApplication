namespace ExpenseApplication.Common.DataTransferObjects;

public class PagingInformationDto
{
    public int PageSize { get; set; }
    public int PageNumber { get; set; }
    public int TotalCount { get; set; }
}