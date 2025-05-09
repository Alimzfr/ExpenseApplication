namespace ExpenseApplication.Client.StateManagement.LogsUseCase;

public class LogsReducers
{
    [ReducerMethod]
    public static LogsState ReduceSetLogsLoadingAction(LogsState state, LogsActions.SetLogsLoadingAction action)
    {
        return state with
        {
            Loading = action.IsLoading
        };
    }

    [ReducerMethod]
    public static LogsState ReduceSetLogsInitializedAction(LogsState state, LogsActions.SetLogsInitializedAction action)
    {
        return state with
        {
            Initialized = action.IsInitialized
        };
    }

    [ReducerMethod]
    public static LogsState ReduceSetLogsAction(LogsState state, LogsActions.SetLogsAction action)
    {
        return state with
        {
            Logs = action.Logs
        };
    }

    [ReducerMethod]
    public static LogsState ReduceSetLogsFilterAction(LogsState state, LogsActions.SetLogsFilterAction action)
    {
        return state with
        {
            LogRequestFilter = action.LogRequestFilter
        };
    }

    [ReducerMethod]
    public static LogsState ReduceSetLogsPagingInformationAction(LogsState state, LogsActions.SetLogsPagingInformationAction action)
    {
        return state with
        {
            PagingInformation = action.PagingInformation
        };
    }

    [ReducerMethod]
    public static LogsState ReduceLoadLogsAction(LogsState state, LogsActions.LoadLogsAction action)
    {
        return state;
    }

    [ReducerMethod]
    public static LogsState ReduceSubmitDeleteAllLogsAction(LogsState state, LogsActions.SubmitDeleteAllLogsAction action)
    {
        return state;
    }

    [ReducerMethod]
    public static LogsState ReduceClearLogsStateAction(LogsState state, LogsActions.ClearLogsStateAction action)
    {
        return state with
        {
            Loading = false,
            Initialized = false,
            LogRequestFilter = new LogRequestFilterDto(),
            PagingInformation = new PagingInformationDto(),
            Logs = []
        };
    }
}