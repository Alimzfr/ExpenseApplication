namespace ExpenseApplication.Client.StateManagement;

public static class DependencyInjection
{
    public static IServiceCollection AddStateManagementServices(this IServiceCollection services)
    {
        services.AddFluxor(options =>
        {
            options.ScanAssemblies(Assembly.GetExecutingAssembly());
#if DEBUG
            Fluxor.Blazor.Web.ReduxDevTools.OptionsReduxDevToolsExtensions.UseReduxDevTools(options);
#endif
        });

        return services;
    }
}