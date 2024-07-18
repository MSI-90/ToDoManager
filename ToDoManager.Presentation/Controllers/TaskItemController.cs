using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Service.Contracts;
using Shared.DataTransferObjects;
using Shared.RequestFeeatures;
using System.Security.Claims;
using ToDoManager.Presentation.ActionFilters;
namespace ToDoManager.Presentation.Controllers;

/// <summary>
/// TaskItem controller
/// </summary>
[Route("api/taskitem")]
[ApiController]
[Authorize]
public class TaskItemController : ControllerBase
{
    private readonly ITaskItemService _taskItemService;
    public TaskItemController(ITaskItemService taskItemService)
    {
        _taskItemService = taskItemService;
    }

    /// <summary>
    /// Получить все задачи для польззователя
    /// </summary>
    /// <param name="parameters"></param>
    /// <param name="token"></param>
    /// <returns>Возвращает список задачь для пользователя, прошедшего процедуру аутентификации</returns>
    /// <response code="200">Оперция успешно выполнена</response>
    /// <response code="401">Пользователь не прошел процедуру аутентификации</response>
    [HttpGet(Name = "GetTasItems")]
    [ProducesResponseType(200)]
    [ProducesResponseType(401)]
    public async Task<IActionResult> GetTaskItems([FromQuery] TaskItemParameters parameters, CancellationToken token)
    {
        var user = HttpContext.User;
        Guid.TryParse(user.FindFirst(ClaimTypes.NameIdentifier)?.Value.ToString(), out Guid userId);
        var result = await _taskItemService.GetTaskItemsAsync(userId, parameters, token);
        return Ok(result);
    }

    /// <summary>
    /// Получить задачу по идентификатору
    /// </summary>
    /// <param name="taskItemId"></param>
    /// <param name="token"></param>
    /// <returns>Возвращает задачу</returns>
    /// <response code="200">Оперция успешно выполнена</response>
    /// <response code="401">Пользователь не прошел процедуру аутентификации</response> 
    /// <response code="404">Задача не найдена</response>
    [HttpGet("{taskItemId:guid}", Name = "GetTaskItemById")]
    [ProducesResponseType(200)]
    [ProducesResponseType(401)]
    [ProducesResponseType(404)]
    public async Task<IActionResult> GetTaskItem(Guid taskItemId, CancellationToken token)
    {
        var user = HttpContext.User;
        Guid.TryParse(user.FindFirst(ClaimTypes.NameIdentifier)?.Value.ToString(), out Guid userId);
        var result = await _taskItemService.GetTaskItemAsync(userId, taskItemId, token);
        return Ok(result);
    }

    /// <summary>
    /// Создать новую задачу для пользователя
    /// </summary>
    /// <param name="taskItemForCreation"></param>
    /// <returns>Возвращает только-что созданную задачу</returns>
    /// <response code="201">Оперция успешно выполнена</response>
    /// <response code="400">Не указаны обязательные данные для заполнения (information is undefined)</response>
    /// <response code="401">Пользователь не прошел процедуру аутентификации</response> 
    /// <response code="422">Неверно указаны поля для заполнения (Invalid requaired information)</response>
    [HttpPost(Name = "CreateNewTask")]
    [ProducesResponseType(201)]
    [ProducesResponseType(400)]
    [ProducesResponseType(401)]
    [ProducesResponseType(422)]
    [ServiceFilter(typeof(ValidationFilter))]
    public async Task<IActionResult> CreateTakItem([FromBody] TaskItemForCreationDto taskItemForCreation)
    {
        var user = HttpContext.User;
        Guid.TryParse(user.FindFirst(ClaimTypes.NameIdentifier)?.Value.ToString(), out Guid userId);
        var result = await _taskItemService.CreateTaskItemAsync(taskItemForCreation, userId);
        return CreatedAtRoute("GetTaskItemById", new { taskItemId = result.Id }, result);
    }

    /// <summary>
    /// Создать новую задачу с категорией
    /// </summary>
    /// <param name="taskItemWithCategoryForCreation"></param>
    /// <returns>Возвращает только-что созданную задачу</returns>
    /// <response code="201">Оперция успешно выполнена</response>
    /// <response code="400">Не указаны обязательные данные для заполнения (information is undefined)</response>
    /// <response code="401">Пользователь не прошел процедуру аутентификации</response> 
    /// <response code="422">Неверно указаны поля для заполнения (Invalid requaired information)</response>
    [HttpPost("createtaskwithcategory", Name = "CreateNewTaskWithCategory")]
    [ProducesResponseType(201)]
    [ProducesResponseType(400)]
    [ProducesResponseType(401)]
    [ProducesResponseType(422)]
    [ServiceFilter(typeof(ValidationFilter))]
    public async Task<IActionResult> CreateTakItemWithCategory([FromBody] TaskItemForCreationWithCategoryDto taskItemWithCategoryForCreation)
    {
        var user = HttpContext.User;
        Guid.TryParse(user.FindFirst(ClaimTypes.NameIdentifier)?.Value.ToString(), out Guid userId);
        var result = await _taskItemService.CreateTaskItemWithCategoryAsync(taskItemWithCategoryForCreation, userId);
        return CreatedAtRoute("GetTaskItemById", new { taskItemId = result.Id }, result);
    }

    /// <summary>
    /// Удалить задачу по идентификатору
    /// </summary>
    /// <param name="taskItemId"></param>
    /// <param name="token"></param>
    /// <returns>Удаление выбранной задачи</returns>
    /// <response code="204">Оперция успешно выполнена</response>
    /// <response code="401">Пользователь не прошел процедуру аутентификации</response>
    /// <response code="404">Задача не найдена</response>
    [HttpDelete("{taskItemId:guid}", Name = "DeleteTaskById")]
    [ProducesResponseType(204)]
    [ProducesResponseType(401)]
    [ProducesResponseType(404)]
    public async Task<IActionResult> DeleteTaskItem(Guid taskItemId, CancellationToken token)
    {
        var user = HttpContext.User;
        Guid.TryParse(user.FindFirst(ClaimTypes.NameIdentifier)?.Value.ToString(), out Guid userId);
        await _taskItemService.DeleteTaskItemAsync(userId, taskItemId, token);
        return NoContent();
    }
}
