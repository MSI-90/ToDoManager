using Entities;

namespace Contracts;

public interface ICategoryRepository
{
    Task CreateCategoryAsync(Category category);
    Task<Category?> GetCategoryAsync(Guid id, CancellationToken token);
    Task<IEnumerable<Category>> GetCategoriesAsync(Guid userId, CancellationToken token);
    void DeleteCategory(Category category);
}
