namespace ExpenseApplication.Server.Application.Features.ManagerExpenseUseCase.Commands.RejectExpense;

public record RejectExpenseCommand(int UserId, RejectExpenseFormDto RejectExpenseForm, DateTime CurrentDateTime) : ICommand<RejectExpenseCommandResult>;

public record RejectExpenseCommandResult(bool IsSuccess);