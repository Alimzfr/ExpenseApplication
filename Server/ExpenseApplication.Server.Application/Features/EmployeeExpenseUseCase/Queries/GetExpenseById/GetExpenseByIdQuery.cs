namespace ExpenseApplication.Server.Application.Features.EmployeeExpenseUseCase.Queries.GetExpenseById;

public record GetExpenseByIdQuery(int ExpenseId) : IQuery<GetExpenseByIdQueryResult>;

public record GetExpenseByIdQueryResult(ExpenseDto? Expense);