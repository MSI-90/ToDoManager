using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Service.Contracts;
using Shared.DataTransferObjects;
using ToDoManager.Presentation.ActionFilters;

namespace ToDoManager.Presentation.Controllers;
/// <summary>
/// Authentication controller
/// </summary>
[Route("api/authentication")]
[ApiController]
public class AuthenticationController : ControllerBase
{
    private readonly IAuthenticationService _authenticationService;
    private readonly ILogger<AuthenticationController> _logger;
    public AuthenticationController(IAuthenticationService authenticationService, ILogger<AuthenticationController> logger)
    {
        _authenticationService = authenticationService;
        _logger = logger;
    }

    /// <summary>
    /// Registration new user
    /// </summary>
    /// <param name="userForRegistrationDto"></param>
    /// <returns>Create new user</returns>
    [HttpPost]
    [ProducesResponseType(201)]
    [ProducesResponseType(404)]
    [ServiceFilter(typeof(ValidationFilter))]
    public async Task<IActionResult> Registration([FromBody] UserForRegistrationDto userForRegistrationDto)
    {
        var result = await _authenticationService.UserRegistrationAsync(userForRegistrationDto);
        if (!result.Succeeded)
        {
            foreach (var error in result.Errors)
            {
                ModelState.TryAddModelError(error.Code, error.Description);
            }
            return BadRequest(ModelState);
        }

        return StatusCode(201);
    }

    /// <summary>
    /// Authentication user
    /// </summary>
    /// <param name="userForAuthetication"></param>
    /// <returns>Bearer token</returns>
    [HttpPost]
    [ProducesResponseType(200)]
    [ProducesResponseType(403)]
    [ServiceFilter(typeof(ValidationFilter))]
    public async Task<IActionResult> Authentication([FromBody] UserForAutheticationDto userForAuthetication)
    {
        if(!await _authenticationService.ValidUserAsync(userForAuthetication))
            return Unauthorized();


    }
}
