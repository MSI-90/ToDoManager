﻿namespace Shared.DataTransferObjects;

public record TaskItemDto(
    Guid Id, 
    string Title, 
    string Description, 
    string PriorityTask,
    bool IsCancelled,
    DateTime CreatedAt,
    DateTime ExpirationDate);
