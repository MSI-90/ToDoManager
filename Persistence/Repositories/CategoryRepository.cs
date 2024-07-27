using Contracts;
using Entities;
using Microsoft.EntityFrameworkCore;
using Shared.RequestFeeatures;

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

    public async Task<IEnumerable<Category>> GetCategoriesAsync(Guid userId, CategoryParameters parameters, CancellationToken token) => 
        await _repositoryContext.Categories
        .Where(c => c.Userid.Equals(userId))
        .Skip((parameters.PageNumber - 1) * parameters.PageSize)
        .Take(parameters.PageSize)
        .ToListAsync(token);

    public async Task<Category?> GetCategoryAsync(Guid id, Guid userId, CancellationToken token) =>
        await _repositoryContext.Categories
        .Where(c => c.Id.Equals(id) && c.Userid.Equals(userId))
        .FirstOrDefaultAsync(token);

    public async Task<Category?> GetCategoryTitleAsync(Guid userId, string title, CancellationToken token) => 
        await _repositoryContext.Categories
        .Where(c => c.Title.Equals(title) && c.Userid.Equals(userId))
        .FirstOrDefaultAsync(token); 
}
