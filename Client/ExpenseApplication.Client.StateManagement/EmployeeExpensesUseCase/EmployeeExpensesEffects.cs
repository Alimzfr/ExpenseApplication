namespace ExpenseApplication.Client.StateManagement.EmployeeExpensesUseCase;

public class EmployeeExpensesEffects(IState<EmployeeExpensesState> employeeExpensesState, NavigationManager navigationManager, IExpenseService expenseService, IMessageService messageService)
{
    [EffectMethod]
    public async Task EffectLoadEmployeeExpensesAction(EmployeeExpensesActions.LoadEmployeeExpensesAction action, IDispatcher dispatcher)
    {
        dispatcher.Dispatch(new EmployeeExpensesActions.SetEmployeeExpensesLoadingAction(true));
        dispatcher.Dispatch(new EmployeeExpensesActions.SetExpenseRequestFilterAction(action.ExpenseRequestFilter));
        var result = await expenseService.GetEmployeeExpensesAsync(action.ExpenseRequestFilter, action.CancellationToken);
        if (result.HttpStatusCode is HttpStatusCode.OK && result.Data is not null)
        {
            dispatcher.Dispatch(new EmployeeExpensesActions.SetEmployeeExpensesAction(result.Data));
            dispatcher.Dispatch(new EmployeeExpensesActions.SetEmployeeExpensesInitializedAction(true));
            dispatcher.Dispatch(new EmployeeExpensesActions.SetEmployeeExpensesLoadingAction(false));
        }
        else
        {
            messageService.Show(result.ResponseInformation, MessageSeverityType.Error);
            dispatcher.Dispatch(new EmployeeExpensesActions.SetEmployeeExpensesInitializedAction(false));
            dispatcher.Dispatch(new EmployeeExpensesActions.SetEmployeeExpensesLoadingAction(false));
        }
    }

    [EffectMethod]
    public async Task EffectLoadEmployeeEditingExpenseAction(EmployeeExpensesActions.LoadEmployeeEditingExpenseAction action, IDispatcher dispatcher)
    {
        dispatcher.Dispatch(new EmployeeExpensesActions.SetEmployeeExpensesLoadingAction(true));
        var result = await expenseService.GetUserExpenseFormByIdAsync(action.ExpenseId, action.CancellationToken);
        if (result.HttpStatusCode is HttpStatusCode.OK && result.Data is not null)
        {
            dispatcher.Dispatch(new EmployeeExpensesActions.SetEmployeeEditingExpenseAction(result.Data));
            dispatcher.Dispatch(new EmployeeExpensesActions.SetEmployeeExpensesLoadingAction(false));
        }
        else
        {
            messageService.Show(result.ResponseInformation, MessageSeverityType.Error);
            navigationManager.NavigateTo(PageAddressConstants.EmployeeExpensesPage);
            dispatcher.Dispatch(new EmployeeExpensesActions.SetEmployeeExpensesLoadingAction(false));
        }
    }

    [EffectMethod]
    public async Task EffectSubmitCreateExpenseAction(EmployeeExpensesActions.SubmitCreateExpenseAction action, IDispatcher dispatcher)
    {
        dispatcher.Dispatch(new EmployeeExpensesActions.SetEmployeeExpensesLoadingAction(true));
        var result = await expenseService.CreateExpenseAsync(action.ExpenseForm, action.CancellationToken);
        if (result.HttpStatusCode is HttpStatusCode.OK && result.Data is not null)
        {
            messageService.Show(result.ResponseInformation, MessageSeverityType.Success);
            var expenses = new List<ExpenseDto>(employeeExpensesState.Value.EmployeeExpenses);
            expenses.Add(result.Data);
            dispatcher.Dispatch(new EmployeeExpensesActions.SetEmployeeExpensesAction(expenses.OrderByDescending(expense => expense.ModifyDate).ToList()));
            navigationManager.NavigateTo(PageAddressConstants.EmployeeExpensesPage);
            dispatcher.Dispatch(new EmployeeExpensesActions.SetEmployeeExpensesInitializedAction(true));
            dispatcher.Dispatch(new EmployeeExpensesActions.SetEmployeeExpensesLoadingAction(false));
        }
        else
        {
            messageService.Show(result.ResponseInformation, MessageSeverityType.Error);
            dispatcher.Dispatch(new EmployeeExpensesActions.SetEmployeeExpensesInitializedAction(false));
            dispatcher.Dispatch(new EmployeeExpensesActions.SetEmployeeExpensesLoadingAction(false));
        }
    }

    [EffectMethod]
    public async Task EffectSubmitEditExpenseAction(EmployeeExpensesActions.SubmitEditExpenseAction action, IDispatcher dispatcher)
    {
        dispatcher.Dispatch(new EmployeeExpensesActions.SetEmployeeExpensesLoadingAction(true));
        var result = await expenseService.UpdateExpenseAsync(action.ExpenseForm, action.CancellationToken);
        if (result.HttpStatusCode is HttpStatusCode.OK && result.Data is not null)
        {
            messageService.Show(result.ResponseInformation, MessageSeverityType.Success);
            var expenses = new List<ExpenseDto>(employeeExpensesState.Value.EmployeeExpenses);
            var oldExpense = expenses.First(x => x.Id == action.ExpenseForm.Id);
            expenses.Remove(oldExpense);
            expenses.Add(result.Data);
            dispatcher.Dispatch(new EmployeeExpensesActions.SetEmployeeExpensesAction(expenses.OrderByDescending(expense => expense.ModifyDate).ToList()));
            navigationManager.NavigateTo(PageAddressConstants.EmployeeExpensesPage);
            dispatcher.Dispatch(new EmployeeExpensesActions.SetEmployeeExpensesInitializedAction(true));
            dispatcher.Dispatch(new EmployeeExpensesActions.SetEmployeeExpensesLoadingAction(false));
        }
        else
        {
            messageService.Show(result.ResponseInformation, MessageSeverityType.Error);
            dispatcher.Dispatch(new EmployeeExpensesActions.SetEmployeeExpensesInitializedAction(false));
            dispatcher.Dispatch(new EmployeeExpensesActions.SetEmployeeExpensesLoadingAction(false));
        }
    }
}