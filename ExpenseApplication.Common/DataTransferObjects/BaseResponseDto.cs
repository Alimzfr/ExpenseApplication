using System.Net;

namespace ExpenseApplication.Common.DataTransferObjects;

public class BaseResponseDto
{
    public HttpStatusCode HttpStatusCode { get; set; }
    public string ResponseInformation { get; set; }
}

public class BaseResponseDto<T> : BaseResponseDto
{
    public T? Data { get; set; }
}