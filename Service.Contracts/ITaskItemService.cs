using Shared.DataTransferObjects;

namespace Service.Contracts;

public interface ITaskItemService
{
    Task<IEnumerable<TaskItemDto>> GetITaskItems();
}
