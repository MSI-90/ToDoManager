using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Service.Contracts;
using Shared.DataTransferObjects;

namespace ToDoManager.Presentation.Controllers;

/// <summary>
/// Category controller
/// </summary>
[Route("api/category")]
[ApiController]
[Authorize]
public class CategoryController : ControllerBase
{
    private readonly ICategoryService _categoryService;
    private readonly IUserContext _userContext;
    public CategoryController(ICategoryService categoryService, IUserContext userContext)
    {
        _categoryService = categoryService;
        _userContext = userContext;
    }

    [HttpPost]
    public async Task<IActionResult> CreateCategory([FromBody] CategoryForCreationDto categoryForCreation)
    {
        var userId = _userContext.UserId;
        var category = await _categoryService.CrerateCategoryAsync(categoryForCreation, userId);
        return Ok(category);
    }
}
