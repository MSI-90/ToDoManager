using AutoMapper;
using Contracts;
using Domain.Exceptions;
using Entities;
using Service.Contracts;
using Shared.DataTransferObjects;
using Shared.RequestFeeatures;

namespace Service;

public class TaskItemService : ITaskItemService
{
    private readonly IRepositoryManager _repository;
    private readonly IMapper _mapper;
    public TaskItemService(IRepositoryManager repository, IMapper mapper, ICategoryService categoryService)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<IEnumerable<TaskItemDto>> GetTaskItemsAsync(Guid userId, TaskItemParameters parameters, CancellationToken token)
    {
        var itemsFromRepository = await _repository.TaskItemRepository.GetTaskItemsAsync(userId, parameters, token);
        return _mapper.Map<IEnumerable<TaskItemDto>>(itemsFromRepository);
    }
    public async Task<TaskItemDto> GetTaskItemAsync(Guid userId, Guid taskId, CancellationToken token)
    {
        var taskItemFromRepository = await CheckTaskItemExist(userId, taskId, token);
        return _mapper.Map<TaskItemDto>(taskItemFromRepository);
    }
    public async Task<TaskItemDto> CreateTaskItemAsync(TaskItemForCreationDto taskItemFroCreation, Guid userId)
    {
        var taskItemEntity = _mapper.Map<TaskItem>(taskItemFroCreation);
        taskItemEntity.UserId = userId;
        await _repository.TaskItemRepository.CreateTaskItemAsync(taskItemEntity);
        await _repository.SaveAsync();

        return _mapper.Map<TaskItemDto>(taskItemEntity); ;
    }
    public async Task<TaskItemWithCategoryDto> CreateTaskItemWithCategoryAsync(TaskItemForCreationWithCategoryDto taskItemFroCreation, Guid userId)
    {
        var taskItemEntity = _mapper.Map<TaskItem>(taskItemFroCreation);
        taskItemEntity.UserId = userId;
        await _repository.TaskItemRepository.CreateTaskItemAsync(taskItemEntity);
        await _repository.SaveAsync();
        
        return _mapper.Map<TaskItemWithCategoryDto>(taskItemEntity);
    }
    public async Task DeleteTaskItemAsync(Guid userId, Guid taskItemId, CancellationToken token)
    {
        var taskItem = await CheckTaskItemExist(userId, taskItemId, token);
        var taskItemForDelete = _mapper.Map<TaskItem>(taskItem);
        _repository.TaskItemRepository.DeleteTaskItem(taskItemForDelete);
        await _repository.SaveAsync();
    }
    private async Task<TaskItem> CheckTaskItemExist(Guid userId, Guid taskId, CancellationToken token)
    {
        var taskItemFromRepository = await _repository.TaskItemRepository.GetTaskItemAsync(userId, taskId, token);
        if (taskItemFromRepository is null)
            throw new TaskItemNotFoundException();

        return taskItemFromRepository;
    }
}
