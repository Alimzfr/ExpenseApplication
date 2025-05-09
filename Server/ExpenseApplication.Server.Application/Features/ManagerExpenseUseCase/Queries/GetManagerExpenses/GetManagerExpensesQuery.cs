namespace ExpenseApplication.Server.Application.Features.ManagerExpenseUseCase.Queries.GetManagerExpenses;

public record GetManagerExpensesQuery(int ManagerId, ExpenseRequestFilterDto ExpenseRequestFilter) : IQuery<GetManagerExpensesQueryResult>;

public record GetManagerExpensesQueryResult(List<ExpenseDto> Expenses);