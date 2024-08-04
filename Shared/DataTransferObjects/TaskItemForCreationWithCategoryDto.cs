namespace Shared.DataTransferObjects;

public record TaskItemForCreationWithCategoryDto : TaskItemForManipulationDto
{
    public CategoryForCreationDto? Category { get; init; }
}
