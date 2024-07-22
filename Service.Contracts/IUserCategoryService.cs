using Shared.DataTransferObjects;

namespace Service.Contracts;

public interface IUserCategoryService
{
    Task UserCategoryAddAsync(UserCategoryForCreationDto userCategoryDto);
}
