using AutoMapper;
using Contracts;
using Domain.Exceptions;
using Service.Contracts;
using Shared.DataTransferObjects;

namespace Service;

public class TaskItemService : ITaskItemService
{

    private readonly IRepositoryManager _repository;
    private readonly IMapper _mapper;
    public TaskItemService(IRepositoryManager repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<IEnumerable<TaskItemDto>> GetTaskItemsAsync(Guid userId, CancellationToken token)
    {
        var itemsFromRepository = await _repository.TaskItemRepository.GetTaskItemsAsync(userId, token);
        var taskItems = _mapper.Map<IEnumerable<TaskItemDto>>(itemsFromRepository);
        return taskItems;
    }
    public async Task<TaskItemDto> GetTaskItemAsync(Guid userId, Guid taskId, CancellationToken token)
    {
        var taskItemFromRepository = await _repository.TaskItemRepository.GetTaskItemAsync(userId, taskId, token);
        if (taskItemFromRepository is null)
            throw new TaskItemNotFoundException();

        var taskItem = _mapper.Map<TaskItemDto>(taskItemFromRepository);
        return taskItem;
    }
}
