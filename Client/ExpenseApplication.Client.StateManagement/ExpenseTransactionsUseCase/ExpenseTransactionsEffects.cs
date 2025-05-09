namespace ExpenseApplication.Client.StateManagement.ExpenseTransactionsUseCase;

public class ExpenseTransactionsEffects(IExpenseTransactionService expenseTransactionService, IMessageService messageService)
{
    [EffectMethod]
    public async Task EffectLoadExpenseTransactionsAction(ExpenseTransactionsActions.LoadExpenseTransactionsAction action, IDispatcher dispatcher)
    {
        dispatcher.Dispatch(new ExpenseTransactionsActions.SetExpenseTransactionsLoadingAction(true));
        dispatcher.Dispatch(new ExpenseTransactionsActions.SetExpenseTransactionsFilterAction(action.ExpenseTransactionRequestFilter));
        var result = await expenseTransactionService.GetExpenseTransactions(action.ExpenseTransactionRequestFilter, action.CancellationToken);
        if (result.HttpStatusCode is HttpStatusCode.OK && result.Data is not null)
        {
            dispatcher.Dispatch(new ExpenseTransactionsActions.SetExpenseTransactionsAction(result.Data));
            dispatcher.Dispatch(new ExpenseTransactionsActions.SetExpenseTransactionsInitializedAction(true));
            dispatcher.Dispatch(new ExpenseTransactionsActions.SetExpenseTransactionsLoadingAction(false));
        }
        else
        {
            messageService.Show(result.ResponseInformation, MessageSeverityType.Error);
            dispatcher.Dispatch(new ExpenseTransactionsActions.SetExpenseTransactionsInitializedAction(false));
            dispatcher.Dispatch(new ExpenseTransactionsActions.SetExpenseTransactionsLoadingAction(false));
        }
    }
}