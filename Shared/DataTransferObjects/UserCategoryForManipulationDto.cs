namespace Shared.DataTransferObjects;

public record UserCategoryForManipulationDto
{
    public string UserId { get; init; } = string.Empty;
    public Guid? CategoryId {  get; init; }
}
