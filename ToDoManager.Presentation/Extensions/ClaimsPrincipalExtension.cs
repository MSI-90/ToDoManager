using Domain.Exceptions;
using System.Security.Claims;

namespace ToDoManager.Presentation.Extensions;

internal static class ClaimsPrincipalExtension
{
    public static Guid GetUserId(this ClaimsPrincipal? principal)
    {
        string? userId = principal?.FindFirstValue(ClaimTypes.NameIdentifier);

        return Guid.TryParse(userId, out Guid parseUserId) ? parseUserId : throw new UserIdNotFoundException();
    }
}
