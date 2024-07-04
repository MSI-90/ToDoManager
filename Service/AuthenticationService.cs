using AutoMapper;
using Domain.Entities;
using Domain.Enums;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using Service.Contracts;
using Shared.DataTransferObjects;

namespace Service;

public class AuthenticationService : IAuthenticationService
{
    private readonly ILogger _loger;
    private readonly IMapper _mapper;
    private readonly UserManager<User> _userManager;
    private readonly RoleManager<User> _userRoles;
    public AuthenticationService(ILogger logger, IMapper mapper, UserManager<User> userManager, RoleManager<User> userRoles)
    {
        _loger = logger;
        _mapper = mapper;
        _userManager = userManager;
        _userRoles = userRoles;
    }

    public async Task<IdentityResult> UserRegistrationAsync(UserForRegistrationDto userForRegistration)
    {
        var user = _mapper.Map<User>(userForRegistration);
        var result = await _userManager.CreateAsync(user, userForRegistration.PasswordInput);
        if (result.Succeeded)
        {
            if (!await _userRoles.RoleExistsAsync(UserRoles.User.ToString()))
                await _userManager.AddToRoleAsync(user, UserRoles.User.ToString());
        }

        return result;
    }

    public Task<bool> ValidUserAsync(UserForAutheticationDto userForAuthetication)
    {
        throw new NotImplementedException();
    }
}
