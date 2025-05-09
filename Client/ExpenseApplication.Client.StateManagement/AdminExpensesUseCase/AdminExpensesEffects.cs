namespace ExpenseApplication.Client.StateManagement.AdminExpensesUseCase;

public class AdminExpensesEffects(IExpenseService expenseService, IMessageService messageService)
{
    [EffectMethod]
    public async Task EffectLoadAdminExpensesAction(AdminExpensesActions.LoadAdminExpensesAction action, IDispatcher dispatcher)
    {
        dispatcher.Dispatch(new AdminExpensesActions.SetAdminExpensesLoadingAction(true));
        dispatcher.Dispatch(new AdminExpensesActions.SetExpenseRequestFilterAction(action.ExpenseRequestFilter));
        var result = await expenseService.GetAdminExpensesAsync(action.ExpenseRequestFilter, action.CancellationToken);
        if (result.HttpStatusCode is HttpStatusCode.OK && result.Data is not null)
        {
            dispatcher.Dispatch(new AdminExpensesActions.SetAdminExpensesAction(result.Data));
            dispatcher.Dispatch(new AdminExpensesActions.SetAdminExpensesInitializedAction(true));
            dispatcher.Dispatch(new AdminExpensesActions.SetAdminExpensesLoadingAction(false));
        }
        else
        {
            messageService.Show(result.ResponseInformation, MessageSeverityType.Error);
            dispatcher.Dispatch(new AdminExpensesActions.SetAdminExpensesInitializedAction(false));
            dispatcher.Dispatch(new AdminExpensesActions.SetAdminExpensesLoadingAction(false));
        }
    }
}