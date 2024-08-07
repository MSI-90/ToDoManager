using Shared.DataTransferObjects;
using Shared.RequestFeeatures;

namespace Service.Contracts;

public interface ICategoryService
{
    Task<CategoryDto> CreateCategoryAsync(CategoryForCreationDto categoryForCreationDto, Guid userId, CancellationToken token);
    Task<CategoryDto> GetCategoryAsync(Guid categoryId, Guid userId, CancellationToken token);
    Task<(IEnumerable<CategoryDto> categories, MetaData metaData)> GetAllCategoriesAsync(Guid userId, CategoryParameters para, CancellationToken token);
    Task UpdateCategoryAsync(CategoryForUpdateDto categoryForUpdate, Guid categoryId, Guid userId, CancellationToken token);
    Task DeleteCategoryAsync(Guid categoryId, Guid userId, CancellationToken token);
    Task CheckCategoryTitleAsync(Guid userId, string titleCategory, CancellationToken token);
}
