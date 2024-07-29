using Entities;
using Shared.RequestFeeatures;

namespace Contracts;

public interface ITaskItemRepository
{
    Task CreateTaskItemAsync(TaskItem taskItem);
    Task<PagedList<TaskItem>> GetTaskItemsAsync(Guid userId, TaskItemParameters parameters, CancellationToken token);
    Task<TaskItem?> GetTaskItemAsync(Guid userId, Guid taskItemId, CancellationToken token);
    void DeleteTaskItem(TaskItem taskItem);
}
