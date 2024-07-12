namespace Shared.DataTransferObjects;

public record TaskItemWithCategoryDto(
    Guid Id,
    string Title,
    string Description,
    string PriorityTask,
    Guid CategoryId,
    bool IsCancelled,
    DateTime CreatedAt,
    DateTime ExpirationDate);
