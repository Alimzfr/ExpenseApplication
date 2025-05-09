namespace ExpenseApplication.Server.WebApi.Controllers;

[ApiController]
[Route("api/[controller]/[action]")]
[EnableCors(policyName: "CorsPolicy")]
[AllowAnonymous]
public class AccountController(ISender sender) : ControllerBase
{

    [HttpPost]
    [ProducesResponseType(typeof(BaseResponseDto<TokenDto>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(BaseResponseDto), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(BaseResponseDto), StatusCodes.Status401Unauthorized)]
    public async Task<ActionResult<BaseResponseDto<TokenDto>>> Login([FromBody] LoginFormDto loginForm)
    {
        var result = await sender.Send(new LoginCommand(loginForm));
        return Ok(new BaseResponseDto<TokenDto>
        {
            Data = result.Token,
            HttpStatusCode = HttpStatusCode.OK,
            ResponseInformation = "User logged in successfully."
        });
    }

    [HttpPost]
    [ProducesResponseType(typeof(BaseResponseDto<TokenDto>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(BaseResponseDto), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(BaseResponseDto), StatusCodes.Status401Unauthorized)]
    public async Task<ActionResult<BaseResponseDto<TokenDto>>> RefreshToken([FromBody] RefreshTokenFormDto refreshTokenForm)
    {
        var result = await sender.Send(new RefreshTokenCommand(refreshTokenForm));
        return Ok(new BaseResponseDto<TokenDto>
        {
            Data = result.Token,
            HttpStatusCode = HttpStatusCode.OK,
            ResponseInformation = "Token refreshed successfully."
        });
    }

    [HttpPost]
    [ProducesResponseType(typeof(BaseResponseDto<bool>), StatusCodes.Status200OK)]
    public async Task<ActionResult<BaseResponseDto<bool>>> Logout([FromBody] RefreshTokenFormDto refreshTokenForm)
    {
        var claimsIdentity = User.Identity as ClaimsIdentity;
        var userDataClaim = claimsIdentity?.FindFirst(ClaimTypes.UserData);
        var userId = (!string.IsNullOrEmpty(userDataClaim?.Value) && int.TryParse(userDataClaim.Value, out var parsedUserId)) ? parsedUserId : default;

        var result = await sender.Send(new LogoutCommand(userId, refreshTokenForm));
        return Ok(new BaseResponseDto<bool>
        {
            Data = result.IsSuccess,
            HttpStatusCode = HttpStatusCode.OK,
            ResponseInformation = "User logged out successfully."
        });
    }
}