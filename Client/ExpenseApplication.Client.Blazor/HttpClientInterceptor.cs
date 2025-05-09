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
    private readonly IHttpClientInterceptor httpClientInterceptor;
    private readonly ICustomLocalStorageService customLocalStorageService;
    private readonly IDispatcher dispatcher;
    private readonly CancellationTokenSource cancellationTokenSource = new();

    public HttpClientInterceptor(IHttpClientInterceptor httpClientInterceptor, ICustomLocalStorageService customLocalStorageService, IDispatcher dispatcher)
    {
        this.httpClientInterceptor = httpClientInterceptor;
        this.customLocalStorageService = customLocalStorageService;
        this.dispatcher = dispatcher;
        this.httpClientInterceptor.BeforeSendAsync += BeforeSendHandler;
        this.httpClientInterceptor.AfterSendAsync += AfterSendHandler;
    }

    private async Task BeforeSendHandler(object sender, HttpClientInterceptorEventArgs httpClientInterceptorEventArgs)
    {
        var accessToken = await customLocalStorageService.GetItemAsync<string?>(LocalStorageConstants.AccessToken, cancellationTokenSource.Token);
        httpClientInterceptorEventArgs.Request.Headers.Authorization = string.IsNullOrEmpty(accessToken) ? null : new AuthenticationHeaderValue("bearer", accessToken);
    }

    private async Task AfterSendHandler(object sender, HttpClientInterceptorEventArgs httpClientInterceptorEventArgs)
    {
        if (httpClientInterceptorEventArgs?.Response?.IsSuccessStatusCode is true) return;
        if (httpClientInterceptorEventArgs?.Response is { IsSuccessStatusCode: false, StatusCode: HttpStatusCode.Unauthorized or HttpStatusCode.Forbidden })
        {
            dispatcher.Dispatch(new LoginActions.SubmitRefreshLoginAction(cancellationTokenSource.Token));
        }
    }

    public void Dispose()
    {
        httpClientInterceptor.BeforeSendAsync -= BeforeSendHandler;
        httpClientInterceptor.AfterSendAsync -= AfterSendHandler;
        cancellationTokenSource.Dispose();
    }
}

public static class SubscribeHttpClientInterceptor
{
    public static void SubscribeHttpClientInterceptorEvents(this WebAssemblyHost host)
    {
        host.Services.GetService<HttpClientInterceptor>();
    }
}