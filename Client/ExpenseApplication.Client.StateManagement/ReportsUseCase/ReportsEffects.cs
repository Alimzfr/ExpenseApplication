namespace ExpenseApplication.Client.StateManagement.ReportsUseCase;

public class ReportsEffects(IReportService reportService, IMessageService messageService)
{
    [EffectMethod]
    public async Task EffectLoadExpenseStatusTypeCountsAction(ReportsActions.LoadExpenseStatusTypeCountsAction action, IDispatcher dispatcher)
    {
        dispatcher.Dispatch(new ReportsActions.SetExpenseStatusTypeCountsLoadingAction(true));
        var result = await reportService.GetExpenseStatusTypeCountReport(action.CancellationToken);
        if (result.HttpStatusCode is HttpStatusCode.OK && result.Data is not null)
        {
            dispatcher.Dispatch(new ReportsActions.SetExpenseStatusTypeCountsAction(result.Data));
            dispatcher.Dispatch(new ReportsActions.SetExpenseStatusTypeCountsInitializedAction(true));
            dispatcher.Dispatch(new ReportsActions.SetExpenseStatusTypeCountsLoadingAction(false));
        }
        else
        {
            messageService.Show(result.ResponseInformation, MessageSeverityType.Error);
            dispatcher.Dispatch(new ReportsActions.SetExpenseStatusTypeCountsInitializedAction(false));
            dispatcher.Dispatch(new ReportsActions.SetExpenseStatusTypeCountsLoadingAction(false));
        }
    }

    [EffectMethod]
    public async Task EffectLoadExpenseStatusTypeCountsAction(ReportsActions.LoadSystemLogLevelCountsAction action, IDispatcher dispatcher)
    {
        dispatcher.Dispatch(new ReportsActions.SetSystemLogLevelCountsLoadingAction(true));
        var result = await reportService.GetSystemLogLevelCountReport(action.CancellationToken);
        if (result.HttpStatusCode is HttpStatusCode.OK && result.Data is not null)
        {
            dispatcher.Dispatch(new ReportsActions.SetSystemLogLevelCountsAction(result.Data));
            dispatcher.Dispatch(new ReportsActions.SetSystemLogLevelCountsInitializedAction(true));
            dispatcher.Dispatch(new ReportsActions.SetSystemLogLevelCountsLoadingAction(false));
        }
        else
        {
            messageService.Show(result.ResponseInformation, MessageSeverityType.Error);
            dispatcher.Dispatch(new ReportsActions.SetSystemLogLevelCountsInitializedAction(false));
            dispatcher.Dispatch(new ReportsActions.SetSystemLogLevelCountsLoadingAction(false));
        }
    }

    [EffectMethod]
    public async Task EffectLoadTotalPaidExpensesMonthlyAmountsAction(ReportsActions.LoadTotalPaidExpensesMonthlyAmountsAction action, IDispatcher dispatcher)
    {
        dispatcher.Dispatch(new ReportsActions.SetTotalPaidExpensesMonthlyAmountsLoadingAction(true));
        var result = await reportService.GetTotalPaidExpensesMonthlyAmountReport(action.Year, action.CancellationToken);
        if (result.HttpStatusCode is HttpStatusCode.OK && result.Data is not null)
        {
            dispatcher.Dispatch(new ReportsActions.SetTotalPaidExpensesMonthlyAmountsAction(result.Data));
            dispatcher.Dispatch(new ReportsActions.SetTotalPaidExpensesMonthlyAmountsInitializedAction(true));
            dispatcher.Dispatch(new ReportsActions.SetTotalPaidExpensesMonthlyAmountsLoadingAction(false));
        }
        else
        {
            messageService.Show(result.ResponseInformation, MessageSeverityType.Error);
            dispatcher.Dispatch(new ReportsActions.SetTotalPaidExpensesMonthlyAmountsInitializedAction(false));
            dispatcher.Dispatch(new ReportsActions.SetTotalPaidExpensesMonthlyAmountsLoadingAction(false));
        }
    }

    [EffectMethod]
    public async Task EffectExpenseStatusTypeMonthlyCountsAction(ReportsActions.LoadExpenseStatusTypeMonthlyCountsAction action, IDispatcher dispatcher)
    {
        dispatcher.Dispatch(new ReportsActions.SetExpenseStatusTypeMonthlyCountsLoadingAction(true));
        var result = await reportService.GetExpenseStatusTypeMonthlyCountReport(action.Year, action.CancellationToken);
        if (result.HttpStatusCode is HttpStatusCode.OK && result.Data is not null)
        {
            dispatcher.Dispatch(new ReportsActions.SetExpenseStatusTypeMonthlyCountsAction(result.Data));
            dispatcher.Dispatch(new ReportsActions.SetExpenseStatusTypeMonthlyCountsInitializedAction(true));
            dispatcher.Dispatch(new ReportsActions.SetExpenseStatusTypeMonthlyCountsLoadingAction(false));
        }
        else
        {
            messageService.Show(result.ResponseInformation, MessageSeverityType.Error);
            dispatcher.Dispatch(new ReportsActions.SetExpenseStatusTypeMonthlyCountsInitializedAction(false));
            dispatcher.Dispatch(new ReportsActions.SetExpenseStatusTypeMonthlyCountsLoadingAction(false));
        }
    }

    [EffectMethod]
    public async Task EffectExpenseActionTypeMonthlyCountsAction(ReportsActions.LoadExpenseActionTypeMonthlyCountsAction action, IDispatcher dispatcher)
    {
        dispatcher.Dispatch(new ReportsActions.SetExpenseActionTypeMonthlyCountsLoadingAction(true));
        var result = await reportService.GetExpenseActionTypeMonthlyCountReport(action.Year, action.CancellationToken);
        if (result.HttpStatusCode is HttpStatusCode.OK && result.Data is not null)
        {
            dispatcher.Dispatch(new ReportsActions.SetExpenseActionTypeMonthlyCountsAction(result.Data));
            dispatcher.Dispatch(new ReportsActions.SetExpenseActionTypeMonthlyCountsInitializedAction(true));
            dispatcher.Dispatch(new ReportsActions.SetExpenseActionTypeMonthlyCountsLoadingAction(false));
        }
        else
        {
            messageService.Show(result.ResponseInformation, MessageSeverityType.Error);
            dispatcher.Dispatch(new ReportsActions.SetExpenseActionTypeMonthlyCountsInitializedAction(false));
            dispatcher.Dispatch(new ReportsActions.SetExpenseActionTypeMonthlyCountsLoadingAction(false));
        }
    }
}