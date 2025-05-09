namespace ExpenseApplication.Server.Application.Features.EmployeeExpenseUseCase.Queries.GetUserExpenseFormById;

public record GetUserExpenseFormByIdQuery(int UserId, int ExpenseId) : IQuery<GetUserExpenseFormByIdQueryResult>;

public record GetUserExpenseFormByIdQueryResult(ExpenseFormDto? ExpenseForm);