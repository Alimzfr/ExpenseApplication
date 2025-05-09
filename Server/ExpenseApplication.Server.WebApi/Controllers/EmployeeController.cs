namespace ExpenseApplication.Server.WebApi.Controllers;

[ApiController]
[Route("api/[controller]/[action]")]
[EnableCors(policyName: "CorsPolicy")]
[Authorize(Policy = CustomRoleConstants.Employee)]
public class EmployeeController(ISender sender) : ControllerBase
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

        var result = await sender.Send(new GetEmployeeExpensesQuery(userId, expenseRequestFilter));
        return Ok(new BaseResponseDto<List<ExpenseDto>>
        {
            Data = result.Expenses,
            HttpStatusCode = HttpStatusCode.OK,
            ResponseInformation = "Expenses sent successfully."
        });
    }

    [HttpGet]
    [ProducesResponseType(typeof(BaseResponseDto<ExpenseFormDto>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(BaseResponseDto), StatusCodes.Status404NotFound)]
    [ProducesResponseType(typeof(BaseResponseDto), StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(typeof(BaseResponseDto), StatusCodes.Status403Forbidden)]
    public async Task<ActionResult<BaseResponseDto<ExpenseFormDto>>> GetUserExpenseFormById([FromQuery] int expenseId)
    {
        var claimsIdentity = User.Identity as ClaimsIdentity;
        var userDataClaim = claimsIdentity?.FindFirst(ClaimTypes.UserData);
        var userId = (!string.IsNullOrEmpty(userDataClaim?.Value) && int.TryParse(userDataClaim.Value, out var parsedUserId)) ? parsedUserId : default;
        if (userId is default(int))
        {
            throw new InValidUserException("User is not valid!");
        }

        var result = await sender.Send(new GetUserExpenseFormByIdQuery(userId, expenseId));
        return Ok(new BaseResponseDto<ExpenseFormDto>
        {
            Data = result.ExpenseForm,
            HttpStatusCode = HttpStatusCode.OK,
            ResponseInformation = "User expense form sent successfully."
        });
    }

    [HttpPost]
    [ProducesResponseType(typeof(BaseResponseDto<ExpenseDto>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(BaseResponseDto), StatusCodes.Status500InternalServerError)]
    [ProducesResponseType(typeof(BaseResponseDto), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(BaseResponseDto), StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(typeof(BaseResponseDto), StatusCodes.Status403Forbidden)]
    public async Task<ActionResult<BaseResponseDto<ExpenseDto>>> CreateExpense([FromBody] ExpenseFormDto expenseForm)
    {
        var claimsIdentity = User.Identity as ClaimsIdentity;
        var userDataClaim = claimsIdentity?.FindFirst(ClaimTypes.UserData);
        var userId = (!string.IsNullOrEmpty(userDataClaim?.Value) && int.TryParse(userDataClaim.Value, out var parsedUserId)) ? parsedUserId : default;
        if (userId is default(int))
        {
            throw new InValidUserException("User is not valid!");
        }

        var currentDateTime = DateTime.Now;
        var addResult = await sender.Send(new CreateExpenseCommand(userId, expenseForm, currentDateTime));
        if (addResult is null)
        {
            throw new InternalServerException("Expense creation failed!");
        }

        var getResult = await sender.Send(new GetExpenseByIdQuery(addResult.ExpenseId));
        return Ok(new BaseResponseDto<ExpenseDto>
        {
            Data = getResult.Expense,
            HttpStatusCode = HttpStatusCode.OK,
            ResponseInformation = "Expense created successfully."
        });
    }

    [HttpPut]
    [ProducesResponseType(typeof(BaseResponseDto<ExpenseDto>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(BaseResponseDto), StatusCodes.Status500InternalServerError)]
    [ProducesResponseType(typeof(BaseResponseDto), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(BaseResponseDto), StatusCodes.Status404NotFound)]
    [ProducesResponseType(typeof(BaseResponseDto), StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(typeof(BaseResponseDto), StatusCodes.Status403Forbidden)]
    public async Task<ActionResult<BaseResponseDto<ExpenseDto>>> UpdateExpense([FromBody] ExpenseFormDto expenseForm)
    {
        var claimsIdentity = User.Identity as ClaimsIdentity;
        var userDataClaim = claimsIdentity?.FindFirst(ClaimTypes.UserData);
        var userId = (!string.IsNullOrEmpty(userDataClaim?.Value) && int.TryParse(userDataClaim.Value, out var parsedUserId)) ? parsedUserId : default;
        if (userId is default(int))
        {
            throw new InValidUserException("User is not valid!");
        }

        var currentDateTime = DateTime.Now;
        var updateResult = await sender.Send(new UpdateExpenseCommand(userId, expenseForm, currentDateTime));
        if (updateResult?.IsSuccess is not true)
        {
            throw new InternalServerException("Expense update failed!");
        }

        var getResult = await sender.Send(new GetExpenseByIdQuery(expenseForm.Id));
        return Ok(new BaseResponseDto<ExpenseDto>
        {
            Data = getResult.Expense,
            HttpStatusCode = HttpStatusCode.OK,
            ResponseInformation = "Expense updated successfully."
        });
    }
}