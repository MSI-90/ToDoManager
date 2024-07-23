using Shared.DataTransferObjects;

namespace Service.Contracts;

public interface ICategoryService
{
    Task<CategoryDto> CreateCategoryAsync(CategoryForCreationDto categoryForCreationDto, Guid userId);
    //Task<IEnumerable<CategoryDto>> GetCategoriesAsync(Guid userId, CancellationToken token);
}
