using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Primitives;
using Service.Contracts;
using Shared.DataTransferObjects;
using Shared.RequestFeeatures;
using System.Text.Json;
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
    /// Получить категорию по идентификатору
    /// </summary>
    /// <param name="categoryId"></param>
    /// <param name="token"></param>
    /// <returns> Возвращает задачу </returns>
    /// <response code="200">Оперция успешно выполнена (operation is successfull)</response>
    /// <response code="401">Пользователь не прошел процедуру аутентификации</response> 
    /// <response code="404">Нет категории по идентификатору</response> 
    [HttpGet("{categoryId:guid}", Name = "GetCategoryById")]
    [ProducesResponseType(200)]
    [ProducesResponseType(401)]
    [ProducesResponseType(404)]
    public async Task<IActionResult> GetCategory(Guid categoryId, CancellationToken token)
    {
        var category = await _categoryService.GetCategoryAsync(categoryId, _userContext.UserId, token);
        return Ok(category);
    }

    /// <summary>
    /// Получить все категории для пользователя
    /// </summary>
    /// <param name="token"></param>
    /// <param name="parameters"></param>
    /// <returns>Возвращает список категорий для пользователя</returns>
    /// <response code="200">Оперция успешно выполнена (operation is successfull)</response>
    /// <response code="401">Пользователь не прошел процедуру аутентификации</response> 
    [HttpGet("categories")]
    [ProducesResponseType(200)]
    [ProducesResponseType(401)]
    public async Task<IActionResult> GetCategories([FromQuery] CategoryParameters parameters, CancellationToken token)
    {
        var categoriesResult = await _categoryService.GetAllCategoriesAsync(_userContext.UserId, parameters, token);
        Response.Headers.Append("X-Pagination", JsonSerializer.Serialize(categoriesResult.metaData));
        return Ok(categoriesResult.categories);
    }

    /// <summary>
    /// Создать новую категорию для пользователя
    /// </summary>
    /// <param name="categoryForCreation"></param>
    /// <param name="token"></param>
    /// <returns>
    /// Возвращает созданную категорию с заголовком location (return new created category with location header)
    /// </returns>
    /// <response code="201">Оперция успешно выполнена, категория создана (operation is successfull)</response>
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
        return CreatedAtRoute("GetCategoryById", new { categoryId = category.Id, userId = _userContext.UserId }, category);
    }

    /// <summary>
    /// Обновить категорию по идентификатору
    /// </summary>
    /// <param name="categoryForUpdate"></param>
    /// <param name="categoryId"></param>
    /// <param name="token"></param>
    /// <response code="204">Оперция успешно выполнена, категория изменена (operation is successfull)</response>
    /// <response code="400">Не указаны обязательные данные для заполнения (information is undefined)</response>
    /// <response code="401">Пользователь не прошел процедуру аутентификации</response> 
    /// <response code="422">Неверно указаны поля для заполнения (Invalid requaired information)</response>
    [HttpPut]
    [ProducesResponseType(204)]
    [ProducesResponseType(400)]
    [ProducesResponseType(401)]
    [ProducesResponseType(422)]
    [ServiceFilter(typeof(ValidationFilter))]
    public async Task<IActionResult> UpdateCategory([FromBody] CategoryForUpdateDto categoryForUpdate, Guid categoryId, CancellationToken token)
    {
        await _categoryService.UpdateCategoryAsync(categoryForUpdate, categoryId, _userContext.UserId, token);
        return NoContent();
    }

    /// <summary>
    /// Удалить категорию
    /// </summary>
    /// <param name="categoryId"></param>
    /// <param name="token"></param>
    /// <returns>Удаляет категорию для пользователя</returns>
    /// <response code="204">Оперция успешно выполнена, категория удалена (operation is successfull, category was removed)</response>
    /// <response code="401">Пользователь не прошел процедуру аутентификации</response>
    /// <response code="404">Нет категории по данному критерию</response>
    [HttpDelete("{categoryId:guid}")]
    [ProducesResponseType(204)]
    [ProducesResponseType(401)]
    [ProducesResponseType(404)]
    public async Task<IActionResult> DeleteCategory(Guid categoryId, CancellationToken token)
    {
        await _categoryService.DeleteCategoryAsync(categoryId, _userContext.UserId, token);
        return NoContent();
    }
}
