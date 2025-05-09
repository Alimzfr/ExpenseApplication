using ExpenseApplication.Client.Helper;
using Toolbelt.Blazor.Extensions.DependencyInjection;

namespace ExpenseApplication.Client.Blazor;

public static class DependencyInjection
{
    public static IServiceCollection AddBlazorApplicationServices(this IServiceCollection services)
    {
        services.AddHttpClientInterceptor();
        services.AddHttpClient(HttpClientTypeConstants.DefaultClient, (provider, client) =>
        {
            client.BaseAddress = new Uri("https://localhost:7161");
            client.EnableIntercept(provider);
        });
        services.AddScoped<HttpClientInterceptor>();
        services.AddAuthorizationCore();

        return services;
    }
}