using Entities;
using Shared.RequestFeeatures;

namespace Contracts;

public interface ICategoryRepository
{
    Task CreateCategoryAsync(Category category);
    Task<Category?> GetCategoryAsync(Guid id, Guid userId, CancellationToken token);
    Task<PagedList<Category>> GetCategoriesAsync(Guid userId, CategoryParameters parameters, CancellationToken token);
    Task<Category?> GetCategoryTitleAsync(Guid userId, string title, CancellationToken token);
    void DeleteCategory(Category category);
}
