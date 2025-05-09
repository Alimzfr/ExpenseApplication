namespace ExpenseApplication.Common.DataTransferObjects;

public class BaseResponsePagingDto<T> : BaseResponseDto<T>
{
    public PagingInformationDto PagingInformation { get; set; }
}