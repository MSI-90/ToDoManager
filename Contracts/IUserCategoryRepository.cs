using Domain.Entities;

namespace Contracts;

public interface IUserCategoryRepository
{
    Task CreateUserCategoryAsync(UserCategory userCategory);
}
