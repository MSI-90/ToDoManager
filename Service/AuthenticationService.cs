﻿using AutoMapper;
using Domain.Entities;
using Domain.Enums;
using Microsoft.AspNetCore.Identity;
using Service.Contracts;
using Shared.DataTransferObjects;
using System.Security.Authentication;

namespace Service;

public sealed class AuthenticationService : IAuthenticationService
{
    private readonly IMapper _mapper;
    private readonly UserManager<User> _userManager;
    private readonly RoleManager<IdentityRole> _userRoles;
    public AuthenticationService(IMapper mapper, UserManager<User> userManager, RoleManager<IdentityRole> userRoles)
    {
        _mapper = mapper;
        _userManager = userManager;
        _userRoles = userRoles;
    }

    public async Task<IdentityResult> UserRegistrationAsync(UserForRegistrationDto userForRegistration)
    {
        var user = _mapper.Map<User>(userForRegistration);
        var result = await _userManager.CreateAsync(user, userForRegistration.PasswordInput);
        if (!result.Succeeded)
        { 
            throw new AuthenticationException("Ошибка на этапе регистрации пользователя");
        }
        else 
            if (!await _userRoles.RoleExistsAsync(UserRoles.User.ToString()))
                await _userManager.AddToRoleAsync(user, UserRoles.User.ToString());

        return result;
    }

    public Task<bool> ValidUserAsync(UserForAutheticationDto userForAuthetication)
    {
        throw new NotImplementedException();
    }
}
