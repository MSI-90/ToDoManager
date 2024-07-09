using Shared.DataTransferObjects;

namespace Service.Contracts;

public interface ITaskItemService
{
    Task<IEnumerable<TaskItemDto>> GetTaskItemsAsync(Guid userId, CancellationToken token);
    Task<TaskItemDto> GetTaskItemAsync(Guid userId, Guid taskId, CancellationToken token);
}
