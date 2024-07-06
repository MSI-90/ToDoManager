using Contracts;
using Microsoft.Extensions.Logging;

namespace Persistence.Repositories;

public class CategoryRepository : ICategoryRepository
{
    private readonly RepositoryContext _repositoryContext;
    public CategoryRepository(RepositoryContext repositoryContext)
    {
        _repositoryContext = repositoryContext;
    }
}
