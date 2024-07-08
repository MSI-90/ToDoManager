using Microsoft.AspNetCore.Mvc;
using Service.Contracts;
using Shared.DataTransferObjects;
using ToDoManager.Presentation.ActionFilters;

namespace ToDoManager.Presentation.Controllers;

[Route("api/token")]
[ApiController]
public class TokenController : ControllerBase
{
    private readonly IAuthenticationService _authenticationService;
    public TokenController(IAuthenticationService authenticationService)
    {
        _authenticationService = authenticationService;
    }

    [HttpPost("refresh")]
    [ServiceFilter(typeof(ValidationFilter))]
    public async Task<IActionResult> Refresh([FromBody] TokenDto tokenDto)
    {
        var tokenDtoToReturn = await _authenticationService.RefreshTokenAsync(tokenDto);
        return Ok(tokenDtoToReturn);
    }
}
