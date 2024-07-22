using AutoMapper;
using Contracts;
using Domain.Entities;
using Service.Contracts;
using Shared.DataTransferObjects;

namespace Service;

public class UserCategoryService : IUserCategoryService
{
    private readonly IRepositoryManager _repositoryManager;
    private readonly IMapper _mapper;
    public UserCategoryService(IRepositoryManager repositoryManager, IMapper mapper)
    {
        _repositoryManager = repositoryManager; 
        _mapper = mapper;
    }
    public async Task UserCategoryAddAsync(UserCategoryForCreationDto userCategoryDto) 
    {
        var userCategoryEntity = _mapper.Map<UserCategory>(userCategoryDto);
        await _repositoryManager.UserCategoryRepository.UserCategoryAddAsync(userCategoryEntity);
        await _repositoryManager.SaveAsync();
    } 
}
