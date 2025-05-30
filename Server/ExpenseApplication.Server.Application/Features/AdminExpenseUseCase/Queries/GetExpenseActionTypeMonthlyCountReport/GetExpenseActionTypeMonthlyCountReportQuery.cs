﻿namespace ExpenseApplication.Server.Application.Features.AdminExpenseUseCase.Queries.GetExpenseActionTypeMonthlyCountReport;

public record GetExpenseActionTypeMonthlyCountReportQuery(int Year) : IQuery<GetExpenseActionTypeMonthlyCountReportQueryResult>;

public record GetExpenseActionTypeMonthlyCountReportQueryResult(List<ExpenseActionTypeMonthlyCountDto> ExpenseActionTypeMonthlyCounts);