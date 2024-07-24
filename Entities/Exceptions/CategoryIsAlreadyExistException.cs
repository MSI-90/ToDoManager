namespace Domain.Exceptions;

public sealed class CategoryIsAlreadyExistException : BadRequestException
{
    public CategoryIsAlreadyExistException(string message) : base(message)
    {
    }
}
