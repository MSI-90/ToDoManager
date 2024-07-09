using Entities;

namespace Contracts;

public interface ITaskItemRepository
{
    Task CreateTaskItemAsync(TaskItem taskItem);
    Task<IEnumerable<TaskItem>> GetTaskItemsAsync(Guid userId, CancellationToken token);
    Task<TaskItem?> GetTaskItemAsync(Guid userId, Guid taskItemId, CancellationToken token);
    void DeleteTaskItem(TaskItem taskItem);
}
