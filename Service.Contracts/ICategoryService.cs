using Shared.DataTransferObjects;

namespace Service.Contracts;

public interface ICategoryService
{
    Task<CategoryDto> CreateCategoryAsync(CategoryForCreationDto categoryForCreationDto, Guid userId, CancellationToken token);
    Task<CategoryDto> GetCategoryAsync(Guid categoryId, Guid userId, CancellationToken token);
    Task<IEnumerable<CategoryDto>> GetAllCategoriesAsync(Guid userId, CancellationToken token);
    Task DeleteCategoryAsync(Guid categoryId, Guid userId, CancellationToken token);
}
