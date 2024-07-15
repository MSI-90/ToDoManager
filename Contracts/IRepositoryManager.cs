namespace Contracts;

public interface IRepositoryManager
{
    ICategoryRepository CategoryRepository { get; }
    ITaskItemRepository TaskItemRepository { get; }
    IUserCategoryRepository UserCategoryRepository { get; }
    Task SaveAsync();
}
