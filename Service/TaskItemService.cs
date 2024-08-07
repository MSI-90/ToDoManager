using AutoMapper;
using Contracts;
using Domain.Exceptions;
using Entities;
using Service.Contracts;
using Shared.DataTransferObjects;
using Shared.RequestFeeatures;
using System.Runtime.CompilerServices;

namespace Service;

public class TaskItemService : ITaskItemService
{
    private readonly IRepositoryManager _repository;
    private readonly IMapper _mapper;
    private readonly ICategoryService _categoryService;
    public TaskItemService(IRepositoryManager repository, IMapper mapper, ICategoryService categoryService)
    {
        _repository = repository;
        _mapper = mapper;
        _categoryService = categoryService;
    }

    public async Task<(IEnumerable<TaskItemDto> taskItems, MetaData metaData)> GetTaskItemsAsync(Guid userId, TaskItemParameters parameters, CancellationToken token)
    {
        var itemsFromRepository = await _repository.TaskItemRepository.GetTaskItemsAsync(userId, parameters, token);
        var itemsDto = _mapper.Map<IEnumerable<TaskItemDto>>(itemsFromRepository);
        return (taskItems: itemsDto, metaData: itemsFromRepository.MetaData);
    }
    public async Task<TaskItemDto> GetTaskItemAsync(Guid userId, Guid taskId, CancellationToken token)
    {
        var taskItemFromRepository = await CheckTaskItemExistAsync(userId, taskId, token);
        return _mapper.Map<TaskItemDto>(taskItemFromRepository);
    }
    public async Task<TaskItemDto> CreateTaskItemAsync(TaskItemForCreationDto taskItemFroCreation, Guid userId, CancellationToken token)
    {
        var taskItemEntity = _mapper.Map<TaskItem>(taskItemFroCreation);

        if (taskItemFroCreation.Category is null)
        {
            taskItemEntity.UserId = userId;
            await _repository.TaskItemRepository.CreateTaskItemAsync(taskItemEntity);
            await _repository.SaveAsync();
            return await CreateNewTaskItemAndSaveAsync(taskItemEntity);
        }
        
        await CheckCategoryExistAsync(userId, taskItemFroCreation.Category.Title, token);
        taskItemEntity.UserId = userId;
        taskItemEntity.Category!.Userid = userId;
        return await CreateNewTaskItemAndSaveAsync(taskItemEntity);
    }
    private async Task<TaskItemDto> CreateNewTaskItemAndSaveAsync(TaskItem taskItemEntity)
    {
        await _repository.TaskItemRepository.CreateTaskItemAsync(taskItemEntity);
        await _repository.SaveAsync();
        return _mapper.Map<TaskItemDto>(taskItemEntity);
    }
    public async Task DeleteTaskItemAsync(Guid userId, Guid taskItemId, CancellationToken token)
    {
        var taskItem = await CheckTaskItemExistAsync(userId, taskItemId, token);
        var taskItemForDelete = _mapper.Map<TaskItem>(taskItem);
        _repository.TaskItemRepository.DeleteTaskItem(taskItemForDelete);
        await _repository.SaveAsync();
    }
    private async Task<TaskItem> CheckTaskItemExistAsync(Guid userId, Guid taskId, CancellationToken token)
    {
        var taskItemFromRepository = await _repository.TaskItemRepository.GetTaskItemAsync(userId, taskId, token);
        if (taskItemFromRepository is null)
            throw new TaskItemNotFoundException();

        return taskItemFromRepository;
    }
    public async Task UpdatTaskItemAsync(TaskItemForUpdateDto taskItemForUpdate, Guid userId, Guid taskId, CancellationToken token)
    {
        var taskItem = await CheckTaskItemExistAsync(userId, taskId, token);
        await CheckCategoryExistAsync(userId, taskItemForUpdate.Category.Title, token);
        _mapper.Map(taskItemForUpdate, taskItem);
        await _repository.SaveAsync();
    }
    private async Task CheckCategoryExistAsync(Guid userId, string categoryTitle, CancellationToken token)
    {
        await _categoryService.CheckCategoryTitleAsync(userId, categoryTitle, token);
    }
}
