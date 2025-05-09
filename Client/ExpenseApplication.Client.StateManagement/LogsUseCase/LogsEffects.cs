namespace ExpenseApplication.Client.StateManagement.LogsUseCase;

public class LogsEffects(ILogService logService, IMessageService messageService)
{
    [EffectMethod]
    public async Task EffectLoadLogsAction(LogsActions.LoadLogsAction action, IDispatcher dispatcher)
    {
        dispatcher.Dispatch(new LogsActions.SetLogsLoadingAction(true));
        dispatcher.Dispatch(new LogsActions.SetLogsFilterAction(action.LogRequestFilter));
        var result = await logService.GetLogsAsync(action.LogRequestFilter, action.PagingRequest, action.CancellationToken);
        if (result.HttpStatusCode is HttpStatusCode.OK && result.Data is not null)
        {
            dispatcher.Dispatch(new LogsActions.SetLogsPagingInformationAction(result.PagingInformation));
            dispatcher.Dispatch(new LogsActions.SetLogsAction(result.Data));
            dispatcher.Dispatch(new LogsActions.SetLogsInitializedAction(true));
            dispatcher.Dispatch(new LogsActions.SetLogsLoadingAction(false));
        }
        else
        {
            messageService.Show(result.ResponseInformation, MessageSeverityType.Error);
            dispatcher.Dispatch(new LogsActions.SetLogsInitializedAction(false));
            dispatcher.Dispatch(new LogsActions.SetLogsLoadingAction(false));
        }
    }

    [EffectMethod]
    public async Task EffectSubmitDeleteAllLogsAction(LogsActions.SubmitDeleteAllLogsAction action, IDispatcher dispatcher)
    {
        dispatcher.Dispatch(new LogsActions.SetLogsLoadingAction(true));
        var result = await logService.DeleteAllLogsAsync(action.CancellationToken);
        if (result.HttpStatusCode is HttpStatusCode.OK && result.Data is true)
        {
            messageService.Show(result.ResponseInformation, MessageSeverityType.Success);
            dispatcher.Dispatch(new LogsActions.SetLogsAction([]));
            dispatcher.Dispatch(new LogsActions.SetLogsPagingInformationAction(new PagingInformationDto()));
            dispatcher.Dispatch(new LogsActions.SetLogsFilterAction(new LogRequestFilterDto()));
            dispatcher.Dispatch(new LogsActions.SetLogsInitializedAction(true));
            dispatcher.Dispatch(new LogsActions.SetLogsLoadingAction(false));
        }
        else
        {
            messageService.Show(result.ResponseInformation, MessageSeverityType.Error);
            dispatcher.Dispatch(new LogsActions.SetLogsInitializedAction(false));
            dispatcher.Dispatch(new LogsActions.SetLogsLoadingAction(false));
        }
    }
}