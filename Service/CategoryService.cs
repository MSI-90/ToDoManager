using AutoMapper;
using Contracts;
using Entities;
using Service.Contracts;
using Shared.DataTransferObjects;

namespace Service;

public class CategoryService : ICategoryService
{
    private readonly IRepositoryManager _repository;
    private readonly IUserCategoryService _userCategoryService;
    private readonly IMapper _mapper;
    public CategoryService(IRepositoryManager repository, IUserCategoryService userCategoryService , IMapper mapper)
    {
        _repository = repository;
        _userCategoryService = userCategoryService;
        _mapper = mapper;
    }

    public async Task<CategoryDto> CrerateCategoryAsync(CategoryForCreationDto categoryForCreationDto, Guid userId)
    {
        var newCategory = _mapper.Map<Category>(categoryForCreationDto);
        await _repository.CategoryRepository.CreateCategoryAsync(newCategory);

        await _userCategoryService.UserCategoryAddAsync(new UserCategoryForCreationDto
        {
            UserId = userId.ToString(),
            CategoryId = newCategory.Id
        });

        await _repository.SaveAsync();

        return _mapper.Map<CategoryDto>(newCategory);
    }
}
