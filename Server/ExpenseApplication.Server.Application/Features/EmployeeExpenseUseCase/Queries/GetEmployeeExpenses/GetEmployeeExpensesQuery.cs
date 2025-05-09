namespace ExpenseApplication.Server.Application.Features.EmployeeExpenseUseCase.Queries.GetEmployeeExpenses;

public record GetEmployeeExpensesQuery(int UserId, ExpenseRequestFilterDto ExpenseRequestFilter) : IQuery<GetEmployeeExpensesQueryResult>;

public record GetEmployeeExpensesQueryResult(List<ExpenseDto> Expenses);