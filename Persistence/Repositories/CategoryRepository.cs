using Contracts;
using Entities;
using Microsoft.EntityFrameworkCore;

namespace Persistence.Repositories;

public class CategoryRepository : ICategoryRepository
{
    private readonly RepositoryContext _repositoryContext;
    public CategoryRepository(RepositoryContext repositoryContext)
    {
        _repositoryContext = repositoryContext;
    }

    public async Task CreateCategoryAsync(Category category) =>
        await _repositoryContext.Categories.AddAsync(category);

    public void DeleteCategory(Category category) => _repositoryContext.Remove(category);

    public async Task<IEnumerable<Category>> GetCategoriesAsync(Guid userId, CancellationToken token) => 
        await _repositoryContext.Categories.ToListAsync(token);

    public async Task<Category?> GetCategoryAsync(Guid id, CancellationToken token) =>
        await _repositoryContext.Categories
        .Where(c => c.Id.Equals(id))
        .FirstOrDefaultAsync(token);

    public async Task<Category?> GetCategoryTitleAsync(Guid userId, string title, CancellationToken token) 
        => await _repositoryContext.Categories
        .Where(c => c.Title.Equals(title) && c.Userid.Equals(userId))
        .FirstOrDefaultAsync(token); 
}
