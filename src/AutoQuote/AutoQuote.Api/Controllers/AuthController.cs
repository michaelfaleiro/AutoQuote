using AutoQuote.Application.UseCase.Authentication;
using AutoQuote.Communication.Request.Login;
using AutoQuote.Communication.Response;
using AutoQuote.Communication.Response.Token;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AutoQuote.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    [AllowAnonymous]
    [HttpPost("login")]
    [ProducesResponseType(typeof(TokenResponseJson), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ResponseErrorJson), StatusCodes.Status401Unauthorized)]
    public async Task<IActionResult> Login(
        [FromBody] LoginRequest request, [FromServices] LoginUseCase useCase)
    {
        var response = await useCase.ExecuteAsync(request);
        return Ok(response);
    }
    
    [AllowAnonymous]
    [HttpPost("refresh-token")]
    [ProducesResponseType(typeof(TokenResponseJson), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ResponseErrorJson), StatusCodes.Status401Unauthorized)]
    public async Task<IActionResult> RefreshToken([FromBody] RefreshTokenRequest request,
        [FromServices] RefreshTokenUseCase useCase)
    {
        var response = await useCase.ExecuteAsync(request);
        return Ok(response);
    }
}