namespace ExpenseApplication.Server.Application.Mapster;

/// <summary>
/// Configures mappings between domain entities and DTOs using Mapster.
/// </summary>
public static class MapsterConfig
{
    /// <summary>
    /// Configures the mappings.
    /// </summary>
    public static void Configure()
    {
        TypeAdapterConfig<Expense, ExpenseDto>.NewConfig()
            .Map(destination => destination.Username, source => source.User.Username)
            .Map(destination => destination.Comments,
                source => source.ExpenseTransactions
                    .OrderBy(history => history.ActionDateTime)
                    .Select(history => history.Comments)
                    .LastOrDefault());

        TypeAdapterConfig<ExpenseTransaction, ExpenseTransactionDto>.NewConfig()
            .Map(destination => destination.ExpenseTraceId, source => source.Expense.TraceId)
            .Map(destination => destination.ExpenseUsername, source => source.Expense.User.Username)
            .Map(destination => destination.TransactedByUsername, source => source.User.Username)
            .Map(destination => destination.ExpenseTitle, source => source.Expense.Title)
            .Map(destination => destination.CurrencyType, source => source.Expense.CurrencyType);
    }
}