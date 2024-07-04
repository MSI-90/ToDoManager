using Entities;

namespace Contracts;

public interface ITaskItemRepository
{
    Task<IEnumerable<TaskItem>> GetTasksAsync();
}
