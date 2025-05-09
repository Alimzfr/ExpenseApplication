namespace ExpenseApplication.Client.Services.Services;

public class ApiService(IHttpClientFactory httpClientFactory) : IApiService
{
    public async Task<TResponse> Get<TResponse>(string url, Dictionary<string, string?>? queryParams = null, CancellationToken cancellationToken = default(CancellationToken)) where TResponse : BaseResponseDto
    {
        using var httpClient = httpClientFactory.CreateClient(HttpClientTypeConstants.DefaultClient);
        var enrichedUrl = QueryStringHelper.AppendQueryStringToUrl(url, queryParams);
        var httpResponseMessage = await httpClient.GetAsync(enrichedUrl, cancellationToken);
        var response = await httpResponseMessage.Content.ReadFromJsonAsync<TResponse>(cancellationToken: cancellationToken);
        return (TResponse)(response ?? new BaseResponseDto
        {
            HttpStatusCode = httpResponseMessage.StatusCode,
            ResponseInformation = "Something went wrong!"
        });
    }

    public async Task<TResponse> Post<TRequest, TResponse>(string url, TRequest? data, CancellationToken cancellationToken = default(CancellationToken)) where TResponse : BaseResponseDto
    {
        using var httpClient = httpClientFactory.CreateClient(HttpClientTypeConstants.DefaultClient);
        var httpResponseMessage = data is not null
            ? await httpClient.PostAsJsonAsync(url, data, cancellationToken)
            : await httpClient.PostAsync(url, null, cancellationToken);
        var response = await httpResponseMessage.Content.ReadFromJsonAsync<TResponse>(cancellationToken: cancellationToken);
        return (TResponse)(response ?? new BaseResponseDto
        {
            HttpStatusCode = httpResponseMessage.StatusCode,
            ResponseInformation = "Something went wrong!"
        });
    }

    public async Task<TResponse> Put<TRequest, TResponse>(string url, TRequest? data, CancellationToken cancellationToken = default(CancellationToken)) where TResponse : BaseResponseDto
    {
        using var httpClient = httpClientFactory.CreateClient(HttpClientTypeConstants.DefaultClient);
        var httpResponseMessage = data is not null
            ? await httpClient.PutAsJsonAsync(url, data, cancellationToken)
            : await httpClient.PutAsync(url, null, cancellationToken);
        var response = await httpResponseMessage.Content.ReadFromJsonAsync<TResponse>(cancellationToken: cancellationToken);
        return (TResponse)(response ?? new BaseResponseDto
        {
            HttpStatusCode = httpResponseMessage.StatusCode,
            ResponseInformation = "Something went wrong!"
        });
    }

    public async Task<TResponse> Patch<TRequest, TResponse>(string url, TRequest? data, CancellationToken cancellationToken = default(CancellationToken)) where TResponse : BaseResponseDto
    {
        using var httpClient = httpClientFactory.CreateClient(HttpClientTypeConstants.DefaultClient);
        var httpResponseMessage = data is not null
            ? await httpClient.PatchAsJsonAsync(url, data, cancellationToken)
            : await httpClient.PatchAsync(url, null, cancellationToken);
        var response = await httpResponseMessage.Content.ReadFromJsonAsync<TResponse>(cancellationToken: cancellationToken);
        return (TResponse)(response ?? new BaseResponseDto
        {
            HttpStatusCode = httpResponseMessage.StatusCode,
            ResponseInformation = "Something went wrong!"
        });
    }

    public async Task<TResponse> Delete<TResponse>(string url, Dictionary<string, string?>? queryParams = null, CancellationToken cancellationToken = default(CancellationToken)) where TResponse : BaseResponseDto
    {
        using var httpClient = httpClientFactory.CreateClient(HttpClientTypeConstants.DefaultClient);
        var enrichedUrl = QueryStringHelper.AppendQueryStringToUrl(url, queryParams);
        var httpResponseMessage = await httpClient.DeleteAsync(enrichedUrl, cancellationToken);
        var response = await httpResponseMessage.Content.ReadFromJsonAsync<TResponse>(cancellationToken: cancellationToken);
        return (TResponse)(response ?? new BaseResponseDto
        {
            HttpStatusCode = httpResponseMessage.StatusCode,
            ResponseInformation = "Something went wrong!"
        });
    }
}