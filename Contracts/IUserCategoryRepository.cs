using Domain.Entities;

namespace Contracts;

public interface IUserCategoryRepository
{
    Task UserCategoryAddAsync(UserCategory userCategory);
}
