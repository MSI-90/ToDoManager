using Contracts;
using Microsoft.Extensions.Logging;

namespace Persistence.Repositories;

public class RepositoryManager : IRepositoryManager
{
    private readonly ILogger _logger;
    private readonly RepositoryContext _context;
    private readonly Lazy<ITaskItemRepository> _taskRepository;
    private readonly Lazy<ICategoryRepository> _categoryRepository;
    public RepositoryManager(RepositoryContext context, ILogger logger)
    {
        _logger = logger;
        _context = context;
        _taskRepository = new Lazy<ITaskItemRepository>(() => new TaskItemRepository(_context, logger));
        _categoryRepository = new Lazy<ICategoryRepository>(() => new CategoryRepository(_context, logger));
    }
    public ICategoryRepository CategoryRepository => _categoryRepository.Value;
    public ITaskItemRepository TaskItemRepository => _taskRepository.Value;
    public async Task SaveAsync() => await _context.SaveChangesAsync();
}
