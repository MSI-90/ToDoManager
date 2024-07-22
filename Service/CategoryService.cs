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

    public async Task CrerateCategoryAsync(CategoryForCreationDto categoryForCreationDto)
    {
        var newCategory = _mapper.Map<Category>(categoryForCreationDto);
        await _repository.CategoryRepository.CreateCategoryAsync(newCategory);
    }
}
