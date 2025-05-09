namespace ExpenseApplication.Server.Application.Features.EmployeeExpenseUseCase.Commands.UpdateExpense;

public record UpdateExpenseCommand(int UserId, ExpenseFormDto ExpenseForm, DateTime CurrentDateTime) : ICommand<UpdateExpenseCommandResult>;

public record UpdateExpenseCommandResult(bool IsSuccess);