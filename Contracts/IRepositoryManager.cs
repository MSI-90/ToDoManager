namespace Contracts;

public interface IRepositoryManager
{
    ICategoryRepository CategoryRepository { get; }
    ITaskItemRepository TaskItemRepository { get; }
    Task SaveAsync();
}
