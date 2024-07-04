namespace Service.Contracts;

public interface IServiceManager
{
    IAuthenticationService AuthenticationService { get; }
    ITaskItemService TaskItemService { get; }
    ICategoryService CategoryService { get; }
}
