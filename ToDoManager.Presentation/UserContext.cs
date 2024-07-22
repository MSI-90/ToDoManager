using Microsoft.AspNetCore.Http;
using Service.Contracts;
using ToDoManager.Presentation.Extensions;

namespace ToDoManager.Presentation;

public sealed class UserContext : IUserContext
{
    private readonly IHttpContextAccessor _httpContextAccessor;
    public UserContext(IHttpContextAccessor httpContextAccessor) => 
        _httpContextAccessor = httpContextAccessor;
    public Guid UserId => 
        _httpContextAccessor.HttpContext?.User.GetUserId() ?? throw new ApplicationException("Данные недоступны");

    public bool IsAuthenticate => 
        _httpContextAccessor.HttpContext?.User.Identity?.IsAuthenticated ?? throw new ApplicationException("Данные недоступны");
}
