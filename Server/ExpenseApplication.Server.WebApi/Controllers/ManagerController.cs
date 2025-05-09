namespace ExpenseApplication.Server.WebApi.Controllers;

[ApiController]
[Route("api/[controller]/[action]")]
[EnableCors(policyName: "CorsPolicy")]
[Authorize(Policy = CustomRoleConstants.Manager)]
public class ManagerController(ISender sender) : ControllerBase
{
    [HttpGet]
    [ProducesResponseType(typeof(BaseResponseDto<List<ExpenseDto>>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(BaseResponseDto), StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(typeof(BaseResponseDto), StatusCodes.Status403Forbidden)]
    public async Task<ActionResult<BaseResponseDto<List<ExpenseDto>>>> GetExpenses([FromQuery] ExpenseRequestFilterDto expenseRequestFilter)
    {
        var claimsIdentity = User.Identity as ClaimsIdentity;
        var userDataClaim = claimsIdentity?.FindFirst(ClaimTypes.UserData);
        var userId = (!string.IsNullOrEmpty(userDataClaim?.Value) && int.TryParse(userDataClaim.Value, out var parsedUserId)) ? parsedUserId : default;
        if (userId is default(int))
        {
            throw new InValidUserException("User is not valid!");
        }

        var result = await sender.Send(new GetManagerExpensesQuery(userId, expenseRequestFilter));
        return Ok(new BaseResponseDto<List<ExpenseDto>>
        {
            Data = result.Expenses,
            HttpStatusCode = HttpStatusCode.OK,
            ResponseInformation = "Expenses sent successfully."
        });
    }

    [HttpPatch]
    [ProducesResponseType(typeof(BaseResponseDto<ExpenseDto>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(BaseResponseDto), StatusCodes.Status500InternalServerError)]
    [ProducesResponseType(typeof(BaseResponseDto), StatusCodes.Status404NotFound)]
    [ProducesResponseType(typeof(BaseResponseDto), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(BaseResponseDto), StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(typeof(BaseResponseDto), StatusCodes.Status403Forbidden)]
    public async Task<ActionResult<BaseResponseDto<ExpenseDto>>> ApproveExpense([FromBody] ApproveExpenseFormDto approveExpenseForm)
    {
        var claimsIdentity = User.Identity as ClaimsIdentity;
        var userDataClaim = claimsIdentity?.FindFirst(ClaimTypes.UserData);
        var userId = (!string.IsNullOrEmpty(userDataClaim?.Value) && int.TryParse(userDataClaim.Value, out var parsedUserId)) ? parsedUserId : default;
        if (userId is default(int))
        {
            throw new InValidUserException("User is not valid!");
        }

        var currentDateTime = DateTime.Now;
        var approveExpenseResult = await sender.Send(new ApproveExpenseCommand(userId, approveExpenseForm, currentDateTime));
        if (approveExpenseResult?.IsSuccess is not true)
        {
            throw new InternalServerException("Expense approval failed!");
        }

        var getExpenseResult = await sender.Send(new GetExpenseByIdQuery(approveExpenseForm.ExpenseId));
        return Ok(new BaseResponseDto<ExpenseDto>
        {
            Data = getExpenseResult.Expense,
            HttpStatusCode = HttpStatusCode.OK,
            ResponseInformation = "Expense approved successfully."
        });
    }

    [HttpPatch]
    [ProducesResponseType(typeof(BaseResponseDto<ExpenseDto>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(BaseResponseDto), StatusCodes.Status500InternalServerError)]
    [ProducesResponseType(typeof(BaseResponseDto), StatusCodes.Status404NotFound)]
    [ProducesResponseType(typeof(BaseResponseDto), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(BaseResponseDto), StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(typeof(BaseResponseDto), StatusCodes.Status403Forbidden)]
    public async Task<ActionResult<BaseResponseDto<ExpenseDto>>> RejectExpense([FromBody] RejectExpenseFormDto rejectExpenseForm)
    {
        var claimsIdentity = User.Identity as ClaimsIdentity;
        var userDataClaim = claimsIdentity?.FindFirst(ClaimTypes.UserData);
        var userId = (!string.IsNullOrEmpty(userDataClaim?.Value) && int.TryParse(userDataClaim.Value, out var parsedUserId)) ? parsedUserId : default;
        if (userId is default(int))
        {
            throw new InValidUserException("User is not valid!");
        }

        var currentDateTime = DateTime.Now;
        var rejectExpenseResult = await sender.Send(new RejectExpenseCommand(userId, rejectExpenseForm, currentDateTime));
        if (rejectExpenseResult?.IsSuccess is not true)
        {
            throw new InternalServerException("Expense rejection failed!");
        }

        var getExpenseResult = await sender.Send(new GetExpenseByIdQuery(rejectExpenseForm.ExpenseId));
        return Ok(new BaseResponseDto<ExpenseDto>
        {
            Data = getExpenseResult.Expense,
            HttpStatusCode = HttpStatusCode.OK,
            ResponseInformation = "Expense rejected successfully."
        });
    }
}