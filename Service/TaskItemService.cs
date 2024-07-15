using AutoMapper;
using Contracts;
using Domain.Entities;
using Domain.Exceptions;
using Entities;
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
        var taskItemFromRepository = await CheckTaskItemExist(userId, taskId, token);
        var taskItem = _mapper.Map<TaskItemDto>(taskItemFromRepository);
        return taskItem;
    }
    public async Task<TaskItemDto> CreateTaskItemAsync(TaskItemForCreationDto taskItemFroCreation, Guid userId)
    {

        var taskItemEntity = _mapper.Map<TaskItem>(taskItemFroCreation);
        taskItemEntity.UserId = userId;
        await _repository.TaskItemRepository.CreateTaskItemAsync(taskItemEntity);
        await _repository.SaveAsync();

        var taskItemToReturn = _mapper.Map<TaskItemDto>(taskItemEntity);
        return taskItemToReturn;
    }
    public async Task<TaskItemWithCategoryDto> CreateTaskItemWithCategoryAsync(TaskItemForCreationWithCategoryDto taskItemFroCreation, Guid userId)
    {
        var taskItemEntity = _mapper.Map<TaskItem>(taskItemFroCreation);
        taskItemEntity.UserId = userId;
        await _repository.TaskItemRepository.CreateTaskItemAsync(taskItemEntity);

        var userCategoryEntity = new UserCategory { UserId = userId.ToString(), CategoryId = taskItemEntity.CategoryId };
        await _repository.UserCategoryRepository.CreateUserCategoryAsync(userCategoryEntity);

        await _repository.SaveAsync();

        var taskItemToReturn = _mapper.Map<TaskItemWithCategoryDto>(taskItemEntity);
        return taskItemToReturn;
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
