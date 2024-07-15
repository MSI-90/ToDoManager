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

    //public async Task CreateCategoryAsync(Category category) =>
    //    await _repositoryContext.Categories.Where(c => c.).AddAsync(category);

    public void DeleteCategory(Category category) => _repositoryContext.Remove(category);

    public async Task<IEnumerable<Category>> GetCategoriesAsync(CancellationToken token) => await _repositoryContext.Categories.ToListAsync(token);

    public async Task<Category?> GetCategoryAsync(Guid id, CancellationToken token) =>
        await _repositoryContext.Categories.Where(c => c.Id == id).FirstOrDefaultAsync(token);
}
