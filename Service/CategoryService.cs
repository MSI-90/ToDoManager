using AutoMapper;
using Contracts;
using Domain.Exceptions;
using Entities;
using Service.Contracts;
using Shared.DataTransferObjects;
using Shared.RequestFeeatures;

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
    public async Task<CategoryDto> GetCategoryAsync(Guid categoryId, Guid userId, CancellationToken token)
    {
        var category = await GetCategoryAndCheckExists(categoryId, userId, token);
        return _mapper.Map<CategoryDto>(category);
    }
    public async Task<(IEnumerable<CategoryDto> categories, MetaData metaData)> GetAllCategoriesAsync(Guid userId, CategoryParameters parameters, CancellationToken token)
    {
        var categories = await _repository.CategoryRepository.GetCategoriesAsync(userId, parameters, token);
        var categoriesDto = _mapper.Map<IEnumerable<CategoryDto>>(categories);
        return (categories: categoriesDto, metaData: categories.MetaData);
    }
    public async Task UpdateCategoryAsync(CategoryForUpdateDto categoryForUpdate, Guid categoryId, Guid userId, CancellationToken token)
    {
        var categoryOnUpdate = await GetCategoryAndCheckExists(categoryId, userId, token);
        await CheckCategoryTitleAsync(userId, categoryForUpdate.Title, token);
        _mapper.Map(categoryForUpdate, categoryOnUpdate);
        await _repository.SaveAsync();
    }
    public async Task DeleteCategoryAsync(Guid categoryId, Guid userId, CancellationToken token)
    {
        var category = await GetCategoryAndCheckExists(categoryId, userId, token);
        _repository.CategoryRepository.DeleteCategory(category);
        await _repository.SaveAsync();
    }
    public async Task CheckCategoryTitleAsync(Guid userId, string titleCategory, CancellationToken token)
    {
        var categoryExist = await _repository.CategoryRepository.GetCategoryTitleAsync(userId, titleCategory, token);
        if (categoryExist is not null)
            throw new CategoryIsAlreadyExistException($"Уже имеется категория, именуемая как {titleCategory}");
    }

    private async Task<Category> GetCategoryAndCheckExists(Guid categoryId, Guid userId, CancellationToken token)
    {
        var category = await _repository.CategoryRepository.GetCategoryAsync(categoryId, userId, token);
        if (category is null)
            throw new CategoryNotFoundException();

        return category;
    }
}
