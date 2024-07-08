using AutoMapper;
using Domain;
using Domain.ConfigurationModels;
using Domain.Entities;
using Domain.Enums;
using Domain.Exceptions;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Service.Contracts;
using Shared.DataTransferObjects;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace Service;

public sealed class AuthenticationService : IAuthenticationService
{
    private readonly IConfiguration _configuration;
    private readonly ILogger<AuthenticationService> _logger;
    private readonly IMapper _mapper;
    private readonly UserManager<User> _userManager;
    private readonly RoleManager<IdentityRole> _userRoles;
    private User _user;
    public AuthenticationService(IConfiguration configuration, ILogger<AuthenticationService> logger, IMapper mapper, 
        UserManager<User> userManager, RoleManager<IdentityRole> userRoles)
    {
        _configuration = configuration;
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
            throw new RegistrationProblemException(Messages.RegError);
            
        if (await _userRoles.RoleExistsAsync(UserRoles.User.ToString()))
            await _userManager.AddToRoleAsync(user, UserRoles.User.ToString());

        return result;
    }
    public async Task<bool> ValidUserAsync(UserForAutheticationDto userForAuthetication)
    {
        _user = await _userManager.FindByEmailAsync(userForAuthetication.Email);
        if (_user is null)
            throw new UserNotFoundException(userForAuthetication.Email);

        var result = (_user is not null && await _userManager.CheckPasswordAsync(_user, userForAuthetication.Password));
        if (!result)
            _logger.LogWarning($"{nameof(_user)}: {Messages.InvalidAuthData}");

        return result;
    }
    public async Task<TokenDto> CreateTokenAsync(bool populateExp)
    {
        var signingCredentials = GetSigningCredentials();
        var claims = await GetClaimsAsync();
        var tokenoptions = GenerateTokenOptions(signingCredentials, claims);

        var accessToken = new JwtSecurityTokenHandler().WriteToken(tokenoptions);

        var refreshToken = GenerateRefreshToken();
        _user.RefreshToken = refreshToken;

        if (populateExp)
            _user.RefreshTokenExpiryTime = DateTime.UtcNow.AddDays(Convert.ToDouble(_configuration["RefreshSettings:Expires"]));

        await _userManager.UpdateAsync(_user);

        return new TokenDto(accessToken, refreshToken);
    }
    private SigningCredentials GetSigningCredentials()
    {
        var key = Encoding.UTF8.GetBytes(_configuration["Secret:Key"]!);
        var secret = new SymmetricSecurityKey(key);

        return new SigningCredentials(secret, SecurityAlgorithms.HmacSha256);
    }
    private async Task<List<Claim>> GetClaimsAsync()
    {
        var claims = new List<Claim>()
        {
            new Claim(ClaimTypes.Name, _user.Email!),
            new Claim(ClaimTypes.NameIdentifier, _user.Id!)
        };

        var roles = await _userManager.GetRolesAsync(_user);
        foreach (var role in roles)
            claims.Add(new Claim(ClaimTypes.Role, role));

        return claims;
    }
    private JwtSecurityToken GenerateTokenOptions(SigningCredentials signingCredentials, List<Claim> claims)
    {
        var tokenOptions = new JwtSecurityToken
        (
            issuer: _configuration["JwtSettings:ValidIssuer"],
            audience: _configuration["JwtSettings:ValidAudience"],
            claims: claims,
            expires: DateTime.UtcNow.AddMinutes(Convert.ToDouble(_configuration["JwtSettings:Expires"])),
            signingCredentials: signingCredentials
        );

        return tokenOptions;
    }
    private string GenerateRefreshToken()
    {
        var arrayForToken = new byte[32];
        using(var kryptoRand = RandomNumberGenerator.Create())
        {
            kryptoRand.GetBytes(arrayForToken);
            return Convert.ToBase64String(arrayForToken);
        }
    }
    private ClaimsPrincipal GetPrincipalFromExpiredToken(string token)
    {
        var tokenValidationParameters = new TokenValidationParameters
        {
            ValidateAudience = true,
            ValidateIssuer = true,
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Secret:Key"]!)),
            ValidateLifetime = true,
            ValidIssuer = _configuration["JwtSettings:ValidIssuer"],
            ValidAudience = _configuration["JwtSettings:ValidAudience"]
        };
        var tokenHandler = new JwtSecurityTokenHandler();
        SecurityToken securityToken;
        var principal = tokenHandler.ValidateToken(token, tokenValidationParameters, out securityToken);
        var jwtSecurityToken = securityToken as JwtSecurityToken;
        if (jwtSecurityToken is null || !jwtSecurityToken.Header.Alg.Equals(SecurityAlgorithms.HmacSha256, StringComparison.InvariantCultureIgnoreCase))
        {
            _logger.LogWarning(Messages.WrongAccessToken);
            throw new SecurityTokenException(Messages.WrongAccessToken);
        }
        
        return principal;
    }
    public async Task<TokenDto> RefreshTokenAsync(TokenDto tokenDto)
    {
        var principal = GetPrincipalFromExpiredToken(tokenDto.AccessToken);
        var user = await _userManager.FindByEmailAsync(principal.Identity?.Name);
        if (user is null || user.RefreshToken != tokenDto.RefreshToken || user.RefreshTokenExpiryTime <= DateTime.UtcNow)
            throw new RefreshTokenBadRequestException();

        _user = user;

        return await CreateTokenAsync(populateExp: false);
    }
}
