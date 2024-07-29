using Shared.DataTransferObjects;
using Shared.RequestFeeatures;

namespace Service.Contracts;

public interface ITaskItemService
{
    Task<(IEnumerable<TaskItemDto> taskItems, MetaData metaData)> GetTaskItemsAsync(Guid userId, TaskItemParameters parameters, CancellationToken token);
    Task<TaskItemDto> GetTaskItemAsync(Guid userId, Guid taskId, CancellationToken token);
    Task<TaskItemDto> CreateTaskItemAsync(TaskItemForCreationDto taskItemFroCreation, Guid userId);
    Task<TaskItemWithCategoryDto> CreateTaskItemWithCategoryAsync(TaskItemForCreationWithCategoryDto taskItemFroCreation, Guid userId);
    Task DeleteTaskItemAsync(Guid userId, Guid taskItemId, CancellationToken token);
}
