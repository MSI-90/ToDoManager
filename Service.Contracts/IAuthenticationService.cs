using Microsoft.AspNetCore.Identity;
using Shared.DataTransferObjects;

namespace Service.Contracts;

public interface IAuthenticationService
{
    Task<IdentityResult> UserRegistrationAsync(UserForRegistrationDto userForRegistration);
    Task<bool> ValidUserAsync(UserForAutheticationDto userForAuthetication);
}
