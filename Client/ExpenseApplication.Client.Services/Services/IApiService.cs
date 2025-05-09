namespace ExpenseApplication.Client.Services.Services;

public interface IApiService
{
    Task<TResponse> Get<TResponse>(string url, Dictionary<string, string?>? queryParams = null, CancellationToken cancellationToken = default(CancellationToken)) where TResponse : BaseResponseDto;
    Task<TResponse> Post<TRequest, TResponse>(string url, TRequest? data, CancellationToken cancellationToken = default(CancellationToken)) where TResponse : BaseResponseDto;
    Task<TResponse> Put<TRequest, TResponse>(string url, TRequest? data, CancellationToken cancellationToken = default(CancellationToken)) where TResponse : BaseResponseDto;
    Task<TResponse> Patch<TRequest, TResponse>(string url, TRequest? data, CancellationToken cancellationToken = default(CancellationToken)) where TResponse : BaseResponseDto;
    Task<TResponse> Delete<TResponse>(string url, Dictionary<string, string?>? queryParams = null, CancellationToken cancellationToken = default(CancellationToken)) where TResponse : BaseResponseDto;
}