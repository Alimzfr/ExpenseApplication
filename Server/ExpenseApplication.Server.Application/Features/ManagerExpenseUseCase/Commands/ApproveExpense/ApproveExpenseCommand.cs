namespace ExpenseApplication.Server.Application.Features.ManagerExpenseUseCase.Commands.ApproveExpense;

public record ApproveExpenseCommand(int UserId, ApproveExpenseFormDto ApproveExpenseForm, DateTime CurrentDateTime) : ICommand<ApproveExpenseCommandResult>;

public record ApproveExpenseCommandResult(bool IsSuccess);