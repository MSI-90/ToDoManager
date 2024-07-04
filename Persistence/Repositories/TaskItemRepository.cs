using Contracts;
using Entities.Models;
using Microsoft.Extensions.Logging;

namespace Persistence.Repositories;

public class TaskItemRepository : ITaskItemRepository
{
    private readonly RepositoryContext _repositoryContext;
    private readonly ILogger _logger;
    public TaskItemRepository(RepositoryContext repositoryContext, ILogger logger)
    {
        _repositoryContext = repositoryContext;
        _logger = logger;
    }

    public Task<TaskItem> GetTasksAsync()
    {
        throw new NotImplementedException();
    }
}
