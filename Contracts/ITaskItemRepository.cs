using Entities.Models;

namespace Contracts;

public interface ITaskItemRepository
{
    Task<TaskItem> GetTasksAsync();
}
