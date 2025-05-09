namespace ExpenseApplication.Client.StateManagement.DarkModeUseCase;

public class DarkModeReducers
{
    [ReducerMethod]
    public static DarkModeState ReduceSetDarkModeLoadingAction(DarkModeState state, DarkModeActions.SetDarkModeLoadingAction action)
    {
        return state with
        {
            Loading = action.IsLoading
        };
    }

    [ReducerMethod]
    public static DarkModeState ReduceSetDarkModeInitializedAction(DarkModeState state, DarkModeActions.SetDarkModeInitializedAction action)
    {
        return state with
        {
            Initialized = action.IsInitialized
        };
    }

    [ReducerMethod]
    public static DarkModeState ReduceSetIsDarkModeEnableAction(DarkModeState state, DarkModeActions.SetIsDarkModeEnableAction action)
    {
        return state with
        {
            IsDarkModeEnable = action.IsDarkModeEnable
        };
    }

    [ReducerMethod]
    public static DarkModeState ReduceSwitchIsDarkModeEnableAction(DarkModeState state, DarkModeActions.SwitchIsDarkModeEnableAction action)
    {
        return state;
    }

    [ReducerMethod]
    public static DarkModeState ReduceLoadIsDarkModeEnableAction(DarkModeState state, DarkModeActions.LoadIsDarkModeEnableAction action)
    {
        return state;
    }

    [ReducerMethod]
    public static DarkModeState ReduceClearDarkModeStateAction(DarkModeState state, DarkModeActions.ClearDarkModeStateAction action)
    {
        return state with
        {
            IsDarkModeEnable = false
        };
    }
}