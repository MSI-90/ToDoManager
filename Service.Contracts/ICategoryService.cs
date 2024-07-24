using Shared.DataTransferObjects;

namespace Service.Contracts;

public interface ICategoryService
{
    Task<CategoryDto> CreateCategoryAsync(CategoryForCreationDto categoryForCreationDto, Guid userId, CancellationToken token);
    //Task<CategoryDto?> GetCategoryAsync(Guid userId, string titleCategory, CancellationToken token);
}
