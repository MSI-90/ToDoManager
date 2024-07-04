using Contracts;
using Service.Contracts;
using Shared.DataTransferObjects;

namespace Service;

public class TaskItemService : ITaskItemService
{
    private readonly IRepositoryManager _repository;
    public TaskItemService(IRepositoryManager repository) => _repository = repository;

    public Task<IEnumerable<TaskItemDto>> GetITaskItems()
    {
        throw new NotImplementedException();
    }
}
