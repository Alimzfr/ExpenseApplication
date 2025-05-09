namespace ExpenseApplication.Client.StateManagement.ManagerExpensesUseCase;

public class ManagerExpensesEffects(IState<ManagerExpensesState> managerExpensesState, IExpenseService expenseService, IMessageService messageService)
{
    [EffectMethod]
    public async Task EffectLoadManagerExpensesAction(ManagerExpensesActions.LoadManagerExpensesAction action, IDispatcher dispatcher)
    {
        dispatcher.Dispatch(new ManagerExpensesActions.SetManagerExpensesLoadingAction(true));
        dispatcher.Dispatch(new ManagerExpensesActions.SetExpenseRequestFilterAction(action.ExpenseRequestFilter));
        var result = await expenseService.GetManagerExpensesAsync(action.ExpenseRequestFilter, action.CancellationToken);
        if (result.HttpStatusCode is HttpStatusCode.OK && result.Data is not null)
        {
            dispatcher.Dispatch(new ManagerExpensesActions.SetManagerExpensesAction(result.Data));
            dispatcher.Dispatch(new ManagerExpensesActions.SetManagerExpensesInitializedAction(true));
            dispatcher.Dispatch(new ManagerExpensesActions.SetManagerExpensesLoadingAction(false));
        }
        else
        {
            messageService.Show(result.ResponseInformation, MessageSeverityType.Error);
            dispatcher.Dispatch(new ManagerExpensesActions.SetManagerExpensesInitializedAction(false));
            dispatcher.Dispatch(new ManagerExpensesActions.SetManagerExpensesLoadingAction(false));
        }
    }

    [EffectMethod]
    public async Task EffectApproveExpenseAction(ManagerExpensesActions.ApproveExpenseAction action, IDispatcher dispatcher)
    {
        dispatcher.Dispatch(new ManagerExpensesActions.SetManagerExpensesLoadingAction(true));
        var result = await expenseService.ApproveExpenseAsync(action.ApproveExpenseForm, action.CancellationToken);
        if (result.HttpStatusCode is HttpStatusCode.OK && result.Data is not null)
        {
            messageService.Show(result.ResponseInformation, MessageSeverityType.Success);
            var expenses = new List<ExpenseDto>(managerExpensesState.Value.ManagerExpenses);
            var oldExpense = expenses.First(x => x.Id == action.ApproveExpenseForm.ExpenseId);
            expenses.Remove(oldExpense);
            expenses.Add(result.Data);
            dispatcher.Dispatch(new ManagerExpensesActions.SetManagerExpensesAction(expenses.OrderByDescending(expense => expense.ModifyDate).ToList()));
            dispatcher.Dispatch(new ManagerExpensesActions.SetManagerExpensesInitializedAction(true));
            dispatcher.Dispatch(new ManagerExpensesActions.SetManagerExpensesLoadingAction(false));
        }
        else
        {
            messageService.Show(result.ResponseInformation, MessageSeverityType.Error);
            dispatcher.Dispatch(new ManagerExpensesActions.SetManagerExpensesInitializedAction(false));
            dispatcher.Dispatch(new ManagerExpensesActions.SetManagerExpensesLoadingAction(false));
        }
    }

    [EffectMethod]
    public async Task EffectRejectExpenseAction(ManagerExpensesActions.RejectExpenseAction action, IDispatcher dispatcher)
    {
        dispatcher.Dispatch(new ManagerExpensesActions.SetManagerExpensesLoadingAction(true));
        var result = await expenseService.RejectExpenseAsync(action.RejectExpenseForm, action.CancellationToken);
        if (result.HttpStatusCode is HttpStatusCode.OK && result.Data is not null)
        {
            messageService.Show(result.ResponseInformation, MessageSeverityType.Success);
            var expenses = new List<ExpenseDto>(managerExpensesState.Value.ManagerExpenses);
            var oldExpense = expenses.First(x => x.Id == action.RejectExpenseForm.ExpenseId);
            expenses.Remove(oldExpense);
            expenses.Add(result.Data);
            dispatcher.Dispatch(new ManagerExpensesActions.SetManagerExpensesAction(expenses.OrderByDescending(expense => expense.ModifyDate).ToList()));
            dispatcher.Dispatch(new ManagerExpensesActions.SetManagerExpensesInitializedAction(true));
            dispatcher.Dispatch(new ManagerExpensesActions.SetManagerExpensesLoadingAction(false));
        }
        else
        {
            messageService.Show(result.ResponseInformation, MessageSeverityType.Error);
            dispatcher.Dispatch(new ManagerExpensesActions.SetManagerExpensesInitializedAction(false));
            dispatcher.Dispatch(new ManagerExpensesActions.SetManagerExpensesLoadingAction(false));
        }
    }
}