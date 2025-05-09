namespace ExpenseApplication.Server.Application.Features.AdminExpenseUseCase.Queries.GetAdminExpenses;

public record GetAdminExpensesQuery(ExpenseRequestFilterDto ExpenseRequestFilter) : IQuery<GetAdminExpensesQueryResult>;

public record GetAdminExpensesQueryResult(List<ExpenseDto> Expenses);