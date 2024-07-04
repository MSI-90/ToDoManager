using AutoMapper;
using Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using Service.Contracts;

namespace Service;

public class ServiceManager : IServiceManager
{
    private readonly Lazy<IAuthenticationService> _authenticationService;
    private readonly Lazy<ITaskItemService> _taskItemService;
    private readonly Lazy<ICategoryService> _categoryService;
    public ServiceManager(IAuthenticationService authenticationService, ITaskItemService taskItemService, ICategoryService categoryService, 
        IMapper mapper, ILogger logger, UserManager<User> userManager, RoleManager<User> roleManager)
    {
        _authenticationService = new Lazy<IAuthenticationService>(() => new AuthenticationService(logger, mapper, userManager, roleManager));
        //_taskItemService = taskItemService;
        //_categoryService = categoryService;
    }

    public IAuthenticationService AuthenticationService => _authenticationService.Value;

    public ITaskItemService TaskItemService => throw new NotImplementedException();

    public ICategoryService CategoryService => throw new NotImplementedException();
}
