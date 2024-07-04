using Entities;

namespace Contracts;

public interface ITaskItemRepository
{
    Task<IQueryable<TaskItem>> GetTasksAsync();
}
