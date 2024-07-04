using Contracts;
using Service.Contracts;

namespace Service;

public class CategoryService : ICategoryService
{
    private readonly IRepositoryManager _repository;
    public CategoryService(IRepositoryManager repository) => _repository = repository;
}
