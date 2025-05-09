namespace ExpenseApplication.Server.Application.Features.AccountantExpenseUseCase.Commands.PayExpense;

public record PayExpenseCommand(int UserId, PayExpenseFormDto PayExpenseForm, DateTime CurrentDateTime) : ICommand<PayExpenseCommandResult>;

public record PayExpenseCommandResult(bool IsSuccess);