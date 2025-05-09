namespace ExpenseApplication.Server.WebApi.Controllers;

[ApiController]
[Route("api/[controller]/[action]")]
[EnableCors(policyName: "CorsPolicy")]
[Authorize(Policy = CustomRoleConstants.Admin)]
public class AdminController(ISender sender) : ControllerBase
{
    [HttpGet]
    [ProducesResponseType(typeof(BaseResponseDto<List<ExpenseDto>>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(BaseResponseDto), StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(typeof(BaseResponseDto), StatusCodes.Status403Forbidden)]
    public async Task<ActionResult<BaseResponseDto<List<ExpenseDto>>>> GetExpenses([FromQuery] ExpenseRequestFilterDto expenseRequestFilter)
    {
        var result = await sender.Send(new GetAdminExpensesQuery(expenseRequestFilter));
        return Ok(new BaseResponseDto<List<ExpenseDto>>
        {
            Data = result.Expenses,
            HttpStatusCode = HttpStatusCode.OK,
            ResponseInformation = "Expenses sent successfully."
        });
    }

    [HttpGet]
    [ProducesResponseType(typeof(BaseResponseDto<List<ExpenseTransactionDto>>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(BaseResponseDto), StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(typeof(BaseResponseDto), StatusCodes.Status403Forbidden)]
    public async Task<ActionResult<BaseResponseDto<List<ExpenseTransactionDto>>>> GetExpenseTransactions([FromQuery] ExpenseTransactionRequestFilterDto expenseTransactionRequestFilter)
    {
        var result = await sender.Send(new GetExpenseTransactionsQuery(expenseTransactionRequestFilter));
        return Ok(new BaseResponseDto<List<ExpenseTransactionDto>>
        {
            Data = result.ExpenseTransactions,
            HttpStatusCode = HttpStatusCode.OK,
            ResponseInformation = "Expense transactions sent successfully."
        });
    }

    [HttpGet]
    [ProducesResponseType(typeof(BaseResponseDto<List<LogDto>>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(BaseResponseDto), StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(typeof(BaseResponseDto), StatusCodes.Status403Forbidden)]
    public async Task<ActionResult<BaseResponseDto<List<LogDto>>>> GetLogs([FromQuery] LogRequestFilterDto logRequestFilter, [FromQuery] PagingRequestDto pagingRequest)
    {
        var result = await sender.Send(new GetLogsQuery(logRequestFilter, pagingRequest));
        return Ok(new BaseResponsePagingDto<List<LogDto>>
        {
            Data = result.Logs,
            PagingInformation = result.PagingInformation,
            HttpStatusCode = HttpStatusCode.OK,
            ResponseInformation = "System logs sent successfully."
        });
    }

    [HttpGet]
    [ProducesResponseType(typeof(BaseResponseDto<List<ExpenseActionTypeMonthlyCountDto>>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(BaseResponseDto), StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(typeof(BaseResponseDto), StatusCodes.Status403Forbidden)]
    public async Task<ActionResult<BaseResponseDto<List<ExpenseActionTypeMonthlyCountDto>>>> GetExpenseActionTypeMonthlyCountReport([FromQuery] int year)
    {
        var result = await sender.Send(new GetExpenseActionTypeMonthlyCountReportQuery(year));
        return Ok(new BaseResponseDto<List<ExpenseActionTypeMonthlyCountDto>>
        {
            Data = result.ExpenseActionTypeMonthlyCounts,
            HttpStatusCode = HttpStatusCode.OK,
            ResponseInformation = "Expense action type monthly count report sent successfully."
        });
    }

    [HttpGet]
    [ProducesResponseType(typeof(BaseResponseDto<List<ExpenseStatusTypeMonthlyCountDto>>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(BaseResponseDto), StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(typeof(BaseResponseDto), StatusCodes.Status403Forbidden)]
    public async Task<ActionResult<BaseResponseDto<List<ExpenseStatusTypeMonthlyCountDto>>>> GetExpenseStatusTypeMonthlyCountReport([FromQuery] int year)
    {
        var result = await sender.Send(new GetExpenseStatusTypeMonthlyCountReportQuery(year));
        return Ok(new BaseResponseDto<List<ExpenseStatusTypeMonthlyCountDto>>
        {
            Data = result.ExpenseStatusTypeMonthlyCounts,
            HttpStatusCode = HttpStatusCode.OK,
            ResponseInformation = "Expense status type monthly count report sent successfully."
        });
    }

    [HttpGet]
    [ProducesResponseType(typeof(BaseResponseDto<List<TotalPaidExpensesMonthlyAmountDto>>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(BaseResponseDto), StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(typeof(BaseResponseDto), StatusCodes.Status403Forbidden)]
    public async Task<ActionResult<BaseResponseDto<List<TotalPaidExpensesMonthlyAmountDto>>>> GetTotalPaidExpensesMonthlyAmountReport([FromQuery] int year)
    {
        var result = await sender.Send(new GetTotalPaidExpensesMonthlyAmountReportQuery(year));
        return Ok(new BaseResponseDto<List<TotalPaidExpensesMonthlyAmountDto>>
        {
            Data = result.TotalPaidExpensesMonthlyAmounts,
            HttpStatusCode = HttpStatusCode.OK,
            ResponseInformation = "Total paid expenses monthly amount report sent successfully."
        });
    }

    [HttpGet]
    [ProducesResponseType(typeof(BaseResponseDto<List<SystemLogLevelCountDto>>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(BaseResponseDto), StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(typeof(BaseResponseDto), StatusCodes.Status403Forbidden)]
    public async Task<ActionResult<BaseResponseDto<List<SystemLogLevelCountDto>>>> GetSystemLogLevelCountReport()
    {
        var result = await sender.Send(new GetSystemLogLevelCountReportQuery());
        return Ok(new BaseResponseDto<List<SystemLogLevelCountDto>>
        {
            Data = result.SystemLogLevelCounts,
            HttpStatusCode = HttpStatusCode.OK,
            ResponseInformation = "System log level count report sent successfully."
        });
    }

    [HttpGet]
    [ProducesResponseType(typeof(BaseResponseDto<List<ExpenseStatusTypeCountDto>>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(BaseResponseDto), StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(typeof(BaseResponseDto), StatusCodes.Status403Forbidden)]
    public async Task<ActionResult<BaseResponseDto<List<ExpenseStatusTypeCountDto>>>> GetExpenseStatusTypeCountReport()
    {
        var result = await sender.Send(new GetExpenseStatusTypeCountReportQuery());
        return Ok(new BaseResponseDto<List<ExpenseStatusTypeCountDto>>
        {
            Data = result.ExpenseStatusTypeCounts,
            HttpStatusCode = HttpStatusCode.OK,
            ResponseInformation = "Expense status type count report sent successfully."
        });
    }

    [HttpDelete]
    [ProducesResponseType(typeof(BaseResponseDto<bool>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(BaseResponseDto), StatusCodes.Status500InternalServerError)]
    [ProducesResponseType(typeof(BaseResponseDto), StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(typeof(BaseResponseDto), StatusCodes.Status403Forbidden)]
    public async Task<ActionResult<BaseResponseDto<bool>>> DeleteAllLogs()
    {
        var result = await sender.Send(new DeleteAllLogsCommand());
        if (result?.IsSuccess is not true)
        {
            throw new InternalServerException("Delete all logs failed!");
        }

        return Ok(new BaseResponseDto<bool>
        {
            Data = result.IsSuccess,
            HttpStatusCode = HttpStatusCode.OK,
            ResponseInformation = "Success!"
        });
    }
}