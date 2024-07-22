using Shared.DataTransferObjects;

namespace Service.Contracts;

public interface ICategoryService
{
    Task<CategoryDto> CrerateCategoryAsync(CategoryForCreationDto categoryForCreationDto, Guid userId);
}
