using AutoMapper;
using Contracts;
using Domain.Exceptions;
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

    public async Task<CategoryDto> CreateCategoryAsync(CategoryForCreationDto categoryForCreationDto, Guid userId, CancellationToken token)
    {
        await CheckCategoryTitleAsync(userId, categoryForCreationDto.Title, token);
        var newCategory = _mapper.Map<Category>(categoryForCreationDto);
        newCategory.Userid = userId;

        await _repository.CategoryRepository.CreateCategoryAsync(newCategory);
        await _repository.SaveAsync();

        return _mapper.Map<CategoryDto>(newCategory);
    }

    public async Task CheckCategoryTitleAsync(Guid userId, string titleCategory, CancellationToken token)
    {
        var categoryExist = await _repository.CategoryRepository.GetCategoryTitleAsync(userId, titleCategory, token);
        if (categoryExist is not null)
            throw new CategoryIsAlreadyExistException($"Уже имеется категория, именуемая как {titleCategory}");
    }

    //public async Task<IEnumerable<CategoryDto>> GetCategoriesAsync(Guid userId, CancellationToken token)
    //{
    //    var userCategories = 
    //}
}
