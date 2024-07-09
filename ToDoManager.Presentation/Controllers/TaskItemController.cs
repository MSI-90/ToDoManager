using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Service.Contracts;
using System.Security.Claims;
namespace ToDoManager.Presentation.Controllers;

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

    [HttpGet(Name = "GetTasItemsByUser")]
    public async Task<IActionResult> GetTaskItems(CancellationToken token)
    {
        var user = HttpContext.User;
        Guid.TryParse(user.FindFirst(ClaimTypes.NameIdentifier)?.Value.ToString(), out Guid userId);
        var result = await _taskItemService.GetTaskItemsAsync(userId, token);
        return Ok(result);
    }

    [HttpGet("{taskItemId:guid}", Name = "GetTaskItemByUser")]
    public async Task<IActionResult> GetTaskItem(Guid taskItemId, CancellationToken token)
    {
        var user = HttpContext.User;
        Guid.TryParse(user.FindFirst(ClaimTypes.NameIdentifier)?.Value.ToString(), out Guid userId);
        var result = await _taskItemService.GetTaskItemAsync(userId, taskItemId, token);
        return Ok(result);
    }
}
