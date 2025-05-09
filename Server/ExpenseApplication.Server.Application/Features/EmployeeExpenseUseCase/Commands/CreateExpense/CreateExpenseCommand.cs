namespace ExpenseApplication.Server.Application.Features.EmployeeExpenseUseCase.Commands.CreateExpense;

public record CreateExpenseCommand(int UserId, ExpenseFormDto ExpenseForm, DateTime CurrentDateTime) : ICommand<CreateExpenseCommandResult>;

public record CreateExpenseCommandResult(int ExpenseId);