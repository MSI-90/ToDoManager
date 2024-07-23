using AutoMapper;
using Contracts;
using Entities;
using Service.Contracts;
using Shared.DataTransferObjects;

namespace Service;

public class CategoryService : ICategoryService
{
    private readonly IRepositoryManager _repository;
    private readonly IMapper _mapper;
    public CategoryService(IRepositoryManager repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<CategoryDto> CreateCategoryAsync(CategoryForCreationDto categoryForCreationDto, Guid userId)
    {   

        var newCategory = _mapper.Map<Category>(categoryForCreationDto);
        newCategory.Userid = userId;

        await _repository.CategoryRepository.CreateCategoryAsync(newCategory);
        await _repository.SaveAsync();

        return _mapper.Map<CategoryDto>(newCategory);
    }
    //public async Task<IEnumerable<CategoryDto>> GetCategoriesAsync(Guid userId, CancellationToken token)
    //{
    //    var userCategories = 
    //}
}
