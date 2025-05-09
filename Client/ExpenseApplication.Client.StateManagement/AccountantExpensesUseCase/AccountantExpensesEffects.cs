namespace ExpenseApplication.Client.StateManagement.AccountantExpensesUseCase;

public class AccountantExpensesEffects(IState<AccountantExpensesState> accountantExpensesState, IExpenseService expenseService, IMessageService messageService)
{
    [EffectMethod]
    public async Task EffectLoadAccountantExpensesAction(AccountantExpensesActions.LoadAccountantExpensesAction action, IDispatcher dispatcher)
    {
        dispatcher.Dispatch(new AccountantExpensesActions.SetAccountantExpensesLoadingAction(true));
        dispatcher.Dispatch(new AccountantExpensesActions.SetExpenseRequestFilterAction(action.ExpenseRequestFilter));
        var result = await expenseService.GetAccountantExpensesAsync(action.ExpenseRequestFilter, action.CancellationToken);
        if (result.HttpStatusCode is HttpStatusCode.OK && result.Data is not null)
        {
            dispatcher.Dispatch(new AccountantExpensesActions.SetAccountantExpensesAction(result.Data));
            dispatcher.Dispatch(new AccountantExpensesActions.SetAccountantExpensesInitializedAction(true));
            dispatcher.Dispatch(new AccountantExpensesActions.SetAccountantExpensesLoadingAction(false));
        }
        else
        {
            messageService.Show(result.ResponseInformation, MessageSeverityType.Error);
            dispatcher.Dispatch(new AccountantExpensesActions.SetAccountantExpensesInitializedAction(false));
            dispatcher.Dispatch(new AccountantExpensesActions.SetAccountantExpensesLoadingAction(false));
        }
    }

    [EffectMethod]
    public async Task EffectPayExpenseAction(AccountantExpensesActions.PayExpenseAction action, IDispatcher dispatcher)
    {
        dispatcher.Dispatch(new AccountantExpensesActions.SetAccountantExpensesLoadingAction(true));
        var result = await expenseService.PayExpenseAsync(action.PayExpenseForm, action.CancellationToken);
        if (result.HttpStatusCode is HttpStatusCode.OK && result.Data is not null)
        {
            messageService.Show(result.ResponseInformation, MessageSeverityType.Success);
            var expenses = new List<ExpenseDto>(accountantExpensesState.Value.AccountantExpenses);
            var oldExpense = expenses.First(x => x.Id == action.PayExpenseForm.ExpenseId);
            expenses.Remove(oldExpense);
            expenses.Add(result.Data);
            dispatcher.Dispatch(new AccountantExpensesActions.SetAccountantExpensesAction(expenses.OrderByDescending(expense => expense.ModifyDate).ToList()));
            dispatcher.Dispatch(new AccountantExpensesActions.SetAccountantExpensesInitializedAction(true));
            dispatcher.Dispatch(new AccountantExpensesActions.SetAccountantExpensesLoadingAction(false));
        }
        else
        {
            messageService.Show(result.ResponseInformation, MessageSeverityType.Error);
            dispatcher.Dispatch(new AccountantExpensesActions.SetAccountantExpensesInitializedAction(false));
            dispatcher.Dispatch(new AccountantExpensesActions.SetAccountantExpensesLoadingAction(false));
        }
    }
}