using Shared.DataTransferObjects;

namespace Service.Contracts;

public interface ICategoryService
{
    Task CrerateCategoryAsync(CategoryForCreationDto categoryForCreationDto);
}
