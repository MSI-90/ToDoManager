using Shared.Enums;

namespace Shared.DataTransferObjects;

public record TaskItemDto(
    Guid Id, 
    string Title, 
    string Description, 
    Priority PriorityTask,
    DateTime CreatedAt,
    DateTime ExpirationDate, 
    string Category);
