using System.Security.Cryptography.X509Certificates;

namespace Shared.DataTransferObjects;

public record CategoryDto(Guid Id, string Title, string? Description);
