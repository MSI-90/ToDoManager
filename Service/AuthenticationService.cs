using AutoMapper;
using Domain;
using Domain.Entities;
using Domain.Enums;
using Domain.Exceptions;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using Service.Contracts;
using Shared.DataTransferObjects;

namespace Service;

public sealed class AuthenticationService : IAuthenticationService
{
    private readonly ILogger<AuthenticationService> _logger;
    private readonly IMapper _mapper;
    private readonly UserManager<User> _userManager;
    private readonly RoleManager<IdentityRole> _userRoles;
    public AuthenticationService(ILogger<AuthenticationService> logger, IMapper mapper, UserManager<User> userManager, RoleManager<IdentityRole> userRoles)
    {
        _logger = logger;
        _mapper = mapper;
        _userManager = userManager;
        _userRoles = userRoles;
    }

    public async Task<IdentityResult> UserRegistrationAsync(UserForRegistrationDto userForRegistration)
    {
        var user = _mapper.Map<User>(userForRegistration);
        var result = await _userManager.CreateAsync(user, userForRegistration.PasswordInput);
        if (!result.Succeeded)
            throw new RegistrationProblemException(Messages.regError);

        if (await _userRoles.RoleExistsAsync(UserRoles.User.ToString()))
            await _userManager.AddToRoleAsync(user, UserRoles.User.ToString());

        return result;
    }

    public async Task<bool> ValidUserAsync(UserForAutheticationDto userForAuthetication)
    {
        var validUser = await _userManager.FindByEmailAsync(userForAuthetication.Email);
        if (validUser is null)
            throw new UserNotFoundException(userForAuthetication.Email);
        
        var result = await _userManager.CheckPasswordAsync(validUser, userForAuthetication.Password);
        if (!result)
            _logger.LogWarning($"{nameof(validUser)}: {Messages.invalidAuthData}");

        return result;
    }
}
