using ExpenseApplication.Client.Helper;
using ExpenseApplication.Client.Services.Services;
using ExpenseApplication.Client.StateManagement.LoginUseCase;
using Fluxor;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using System.Net;
using System.Net.Http.Headers;
using Toolbelt.Blazor;

namespace ExpenseApplication.Client.Blazor;

public class HttpClientInterceptor : IDisposable
{
    private readonly IHttpClientInterceptor _httpClientInterceptor;
    private readonly ICustomLocalStorageService _customLocalStorageService;
    private readonly IDispatcher _dispatcher;
    private readonly CancellationTokenSource _cancellationTokenSource = new();

    public HttpClientInterceptor(IHttpClientInterceptor httpClientInterceptor, ICustomLocalStorageService customLocalStorageService, IDispatcher dispatcher)
    {
        _httpClientInterceptor = httpClientInterceptor;
        _customLocalStorageService = customLocalStorageService;
        _dispatcher = dispatcher;
        _httpClientInterceptor.BeforeSendAsync += BeforeSendHandler;
        _httpClientInterceptor.AfterSendAsync += AfterSendHandler;
    }

    private async Task BeforeSendHandler(object sender, HttpClientInterceptorEventArgs httpClientInterceptorEventArgs)
    {
        var accessToken = await _customLocalStorageService.GetItemAsync<string?>(LocalStorageConstants.AccessToken, _cancellationTokenSource.Token);
        httpClientInterceptorEventArgs.Request.Headers.Authorization = string.IsNullOrEmpty(accessToken) ? null : new AuthenticationHeaderValue("bearer", accessToken);
    }

    private async Task AfterSendHandler(object sender, HttpClientInterceptorEventArgs httpClientInterceptorEventArgs)
    {
        if (httpClientInterceptorEventArgs?.Response?.IsSuccessStatusCode is true) return;
        if (httpClientInterceptorEventArgs?.Response is { IsSuccessStatusCode: false, StatusCode: HttpStatusCode.Unauthorized or HttpStatusCode.Forbidden })
        {
            _dispatcher.Dispatch(new LoginActions.SubmitRefreshLoginAction(_cancellationTokenSource.Token));
        }
    }

    public void Dispose()
    {
        _httpClientInterceptor.BeforeSendAsync -= BeforeSendHandler;
        _httpClientInterceptor.AfterSendAsync -= AfterSendHandler;
        _cancellationTokenSource.Dispose();
    }
}

public static class SubscribeHttpClientInterceptor
{
    public static void SubscribeHttpClientInterceptorEvents(this WebAssemblyHost host)
    {
        host.Services.GetService<HttpClientInterceptor>();
    }
}