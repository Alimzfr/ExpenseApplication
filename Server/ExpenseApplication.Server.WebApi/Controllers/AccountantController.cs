namespace ExpenseApplication.Server.WebApi.Controllers;

[ApiController]
[Route("api/[controller]/[action]")]
[EnableCors(policyName: "CorsPolicy")]
[Authorize(Policy = CustomRoleConstants.Accountant)]
public class AccountantController(ISender sender) : ControllerBase
{
    [HttpGet]
    [ProducesResponseType(typeof(BaseResponseDto<List<ExpenseDto>>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(BaseResponseDto), StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(typeof(BaseResponseDto), StatusCodes.Status403Forbidden)]
    public async Task<ActionResult<BaseResponseDto<List<ExpenseDto>>>> GetExpenses([FromQuery] ExpenseRequestFilterDto expenseRequestFilter)
    {
        var result = await sender.Send(new GetAccountantExpensesQuery(expenseRequestFilter));
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
    public async Task<ActionResult<BaseResponseDto<ExpenseDto>>> PayExpense([FromBody] PayExpenseFormDto payExpenseForm)
    {
        var claimsIdentity = User.Identity as ClaimsIdentity;
        var userDataClaim = claimsIdentity?.FindFirst(ClaimTypes.UserData);
        var userId = (!string.IsNullOrEmpty(userDataClaim?.Value) && int.TryParse(userDataClaim.Value, out var parsedUserId)) ? parsedUserId : default;
        if (userId is default(int))
        {
            throw new InValidUserException("User is not valid!");
        }

        var currentDateTime = DateTime.Now;
        var payResult = await sender.Send(new PayExpenseCommand(userId, payExpenseForm, currentDateTime));
        if (payResult?.IsSuccess is not true)
        {
            throw new InternalServerException("Expense payment failed!");
        }

        var getResult = await sender.Send(new GetExpenseByIdQuery(payExpenseForm.ExpenseId));
        return Ok(new BaseResponseDto<ExpenseDto>
        {
            Data = getResult.Expense,
            HttpStatusCode = HttpStatusCode.OK,
            ResponseInformation = "Expense paid successfully."
        });
    }
}