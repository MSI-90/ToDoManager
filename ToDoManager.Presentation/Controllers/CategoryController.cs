using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Service.Contracts;
using Shared.DataTransferObjects;
using ToDoManager.Presentation.ActionFilters;

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

    /// <summary>
    /// Создать новую категорию для пользователя
    /// </summary>
    /// <param name="categoryForCreation"></param>
    /// <param name="token"></param>
    /// <returns>
    /// Возвращает созданную категорию с заголовком location (return new created category with location header)
    /// </returns>
    /// <response code="201">Оперция успешно выполнена (operation is successfull)</response>
    /// <response code="400">Не указаны обязательные данные для заполнения (information is undefined)</response>
    /// <response code="401">Пользователь не прошел процедуру аутентификации</response> 
    /// <response code="422">Неверно указаны поля для заполнения (Invalid requaired information)</response>
    [HttpPost]
    [ProducesResponseType(201)]
    [ProducesResponseType(400)]
    [ProducesResponseType(401)]
    [ProducesResponseType(422)]
    [ServiceFilter(typeof(ValidationFilter))]
    public async Task<IActionResult> CreateCategory([FromBody] CategoryForCreationDto categoryForCreation, CancellationToken token)
    {
        var category = await _categoryService.CreateCategoryAsync(categoryForCreation, _userContext.UserId, token);
        return Ok(category);
        //201 will be created later here
    }
}
