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
    /// Регистрация нового пользователя
    /// </summary>
    /// <param name="userForRegistrationDto"></param>
    /// <returns>Create new user</returns>
    /// <response code="201">Пользователь создан (user has been created)</response>
    /// <response code="400">Не указаны обязательные данные для заполнения (information is undefined)</response>
    /// <response code="422">Неверно указаны поля для заполнения (Invalid requaired information)</response>
    [HttpPost]
    [ProducesResponseType(201)]
    [ProducesResponseType(400)]
    [ProducesResponseType(422)]
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
    /// Аутентификация пользователя
    /// </summary>
    /// <param name="userForAuthetication"></param>
    /// <returns>Получает JWT Bearer токен авторизации (Access token) и токен обновления (Refresh token)</returns>
    /// <response code="200">Возвращает оба токена (Access and Refresh tokens)</response>
    /// <response code="400">Не указаны обязательные данные для заполнения (information is undefined)</response>
    /// <response code="401">Пользователь не прошел процедуру аутентификации (user is don't valid)</response>
    /// <response code="404">Пользователь не найден по указаным для аутентификации данным</response>
    /// <response code="422">Неверно указаны поля для заполнения (Invalid requaired information)</response>
    [HttpPost("login")]
    [ProducesResponseType(200)]
    [ProducesResponseType(400)]
    [ProducesResponseType(401)]
    [ProducesResponseType(404)]
    [ProducesResponseType(422)]
    [ServiceFilter(typeof(ValidationFilter))]
    public async Task<IActionResult> Authentication([FromBody] UserForAutheticationDto userForAuthetication)
    {
        await _authenticationService.ValidUserAsync(userForAuthetication);

        var tokenDto = await _authenticationService.CreateTokenAsync(populateExp: true);

        return Ok(tokenDto);
    }
}
