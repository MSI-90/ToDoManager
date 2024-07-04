using Contracts;
using Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Persistence.Repositories;

public class TaskItemRepository : ITaskItemRepository
{
    private readonly RepositoryContext _repositoryContext;
    public TaskItemRepository(RepositoryContext repositoryContext, ILogger logger) =>  _repositoryContext = repositoryContext;

    public async Task<IEnumerable<TaskItem>> GetTasksAsync() => 
        await _repositoryContext.TaskItems.ToListAsync();
}
