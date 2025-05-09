namespace ExpenseApplication.Client.StateManagement.EmployeeExpensesUseCase;

public class EmployeeExpensesStateFeature : Feature<EmployeeExpensesState>
{
    public override string GetName() => nameof(EmployeeExpensesState);

    protected override EmployeeExpensesState GetInitialState()
    {
        return new EmployeeExpensesState
        {
            Loading = false,
            Initialized = false,
            ExpenseRequestFilter = new ExpenseRequestFilterDto(),
            EmployeeExpenses = [],
            EmployeeEditingExpense = new ExpenseFormDto()
        };
    }
}