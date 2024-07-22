using Contracts;
using Domain.Entities;

namespace Persistence.Repositories;

public class UserCategoryRepository : IUserCategoryRepository
{
    private readonly RepositoryContext _repositoryContext;
    public UserCategoryRepository(RepositoryContext repositoryContext) => _repositoryContext = repositoryContext;
    public async Task UserCategoryAddAsync(UserCategory userCategory) => await _repositoryContext.AddAsync(userCategory);
}
