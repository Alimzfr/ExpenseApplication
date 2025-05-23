﻿namespace ExpenseApplication.Server.Application.Features.AdminExpenseUseCase.Queries.GetExpenseStatusTypeCountReport;

public record GetExpenseStatusTypeCountReportQuery : IQuery<GetExpenseStatusTypeCountReportQueryResult>;

public record GetExpenseStatusTypeCountReportQueryResult(List<ExpenseStatusTypeCountDto> ExpenseStatusTypeCounts);