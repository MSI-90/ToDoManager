using Contracts;
using Microsoft.Extensions.Logging;

namespace Persistence.Repositories;

public class CategoryRepository : ICategoryRepository
{
    private readonly ILogger _logger;
    private readonly RepositoryContext _repositoryContext;
    public CategoryRepository(RepositoryContext repositoryContext, ILogger logger)
    {
        _logger = logger;
        _repositoryContext = repositoryContext;
    }
}
