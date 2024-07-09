using Contracts;
using Entities;
using Microsoft.EntityFrameworkCore;

namespace Persistence.Repositories;

public class TaskItemRepository : ITaskItemRepository
{
    private readonly RepositoryContext _repositoryContext;
    public TaskItemRepository(RepositoryContext repositoryContext) =>  _repositoryContext = repositoryContext;

    public async Task CreateTaskItemAsync(TaskItem taskItem) => await _repositoryContext.AddAsync(taskItem);

    public async Task<IEnumerable<TaskItem>> GetTaskItemsAsync(Guid userId, CancellationToken token) => 
        await _repositoryContext.TaskItems.Where(t => t.UserId == userId).ToListAsync(token);

    public async Task<TaskItem?> GetTaskItemAsync(Guid userId, Guid taskItemId, CancellationToken token) => 
        await _repositoryContext.TaskItems.Where(t => t.Id == taskItemId && t.UserId == userId).FirstOrDefaultAsync(token);

    public void DeleteTaskItem(Guid taskItemId) => _repositoryContext.Remove(taskItemId);
}
