using ExpenseApplication.Client.Blazor;
using ExpenseApplication.Client.Services;
using ExpenseApplication.Client.StateManagement;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddCustomServices();
builder.Services.AddStateManagementServices();
builder.Services.AddBlazorApplicationServices();

var host = builder.Build();
host.SubscribeHttpClientInterceptorEvents();
await host.RunAsync();
