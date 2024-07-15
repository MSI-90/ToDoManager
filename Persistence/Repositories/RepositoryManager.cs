using Contracts;

namespace Persistence.Repositories;

public class RepositoryManager : IRepositoryManager
{
    private readonly RepositoryContext _context;
    private readonly Lazy<ITaskItemRepository> _taskRepository;
    private readonly Lazy<ICategoryRepository> _categoryRepository;
    private readonly Lazy<IUserCategoryRepository> _userCategoryRepository; 
    public RepositoryManager(RepositoryContext context)
    {
        _context = context;
        _taskRepository = new Lazy<ITaskItemRepository>(() => new TaskItemRepository(_context));
        _categoryRepository = new Lazy<ICategoryRepository>(() => new CategoryRepository(_context));
        _userCategoryRepository = new Lazy<IUserCategoryRepository>(() => new UserCategoryRepository(_context));
    }
    public ICategoryRepository CategoryRepository => _categoryRepository.Value;
    public ITaskItemRepository TaskItemRepository => _taskRepository.Value;
    public IUserCategoryRepository UserCategoryRepository => _userCategoryRepository.Value;
    public async Task SaveAsync() => await _context.SaveChangesAsync();
}
