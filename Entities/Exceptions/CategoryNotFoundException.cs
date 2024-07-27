namespace Domain.Exceptions;

public sealed class CategoryNotFoundException : NotFoundException
{
    public CategoryNotFoundException() : base(Messages.CategoryNotFound)
    {
    }
}
