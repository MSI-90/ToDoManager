using Entities;

namespace Contracts;

public interface ICategoryRepository
{
    Task CreateCategoryAsync(Category category);
    Task<Category?> GetCategoryAsync(Guid id, Guid userId, CancellationToken token);
    Task<IEnumerable<Category>> GetCategoriesAsync(Guid userId, CancellationToken token);
    Task<Category?> GetCategoryTitleAsync(Guid userId, string title, CancellationToken token);
    void DeleteCategory(Category category);
}
