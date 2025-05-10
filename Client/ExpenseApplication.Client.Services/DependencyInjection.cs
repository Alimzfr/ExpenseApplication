namespace ExpenseApplication.Client.Services;

public static class DependencyInjection
{
    public static IServiceCollection AddCustomServices(this IServiceCollection services)
    {
        services.AddMudServices(configuration =>
        {
            configuration.SnackbarConfiguration.NewestOnTop = true;
            configuration.SnackbarConfiguration.PositionClass = Defaults.Classes.Position.BottomRight;
        });
        services.AddMudExtensions();
        services.AddBlazoredLocalStorage();
        services.AddScoped<ICustomLocalStorageService, CustomLocalStorageService>();
        services.AddScoped<AuthenticationStateProvider, CustomAuthStateProvider>();
        services.AddScoped<IMessageService, MessageService>();
        services.AddScoped<IDarkModeService, DarkModeService>();
        services.AddScoped<IApiService, ApiService>();
        services.AddScoped<IAccountService, AccountService>();
        services.AddScoped<IExpenseService, ExpenseService>();
        services.AddScoped<IExpenseTransactionService, ExpenseTransactionService>();
        services.AddScoped<ILogService, LogService>();
        services.AddScoped<IReportService, ReportService>();

        return services;
    }
}