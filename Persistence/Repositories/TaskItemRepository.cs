using Contracts;
using Entities;
using Microsoft.EntityFrameworkCore;
using Shared.RequestFeeatures;

namespace Persistence.Repositories;

public class TaskItemRepository : ITaskItemRepository
{
    private readonly RepositoryContext _repositoryContext;
    public TaskItemRepository(RepositoryContext repositoryContext) =>  _repositoryContext = repositoryContext;

    public async Task CreateTaskItemAsync(TaskItem taskItem) => await _repositoryContext.AddAsync(taskItem);

    public async Task<PagedList<TaskItem>> GetTaskItemsAsync(Guid userId, TaskItemParameters parameters, CancellationToken token)
    {
        var taskItems = await _repositoryContext.TaskItems
            .Where(t => t.UserId.Equals(userId) && t.IsCancelled.Equals(parameters.IsCancelled))
            .OrderBy(t => t.Title)
            .ToListAsync(token);

        return PagedList<TaskItem>.ToPagedList(taskItems, parameters.PageNumber, parameters.PageSize);
    }
    public async Task<TaskItem?> GetTaskItemAsync(Guid userId, Guid taskItemId, CancellationToken token) => 
        await _repositoryContext.TaskItems
        .Where(t => t.Id == taskItemId && t.UserId == userId)
        .FirstOrDefaultAsync(token);

    public void DeleteTaskItem(TaskItem taskItem) => _repositoryContext.TaskItems.Remove(taskItem);
}
