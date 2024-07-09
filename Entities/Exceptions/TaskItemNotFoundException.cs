namespace Domain.Exceptions;

public class TaskItemNotFoundException : NotFoundException
{
    public TaskItemNotFoundException() : base(Messages.TaskItemNotFound)
    {
    }
}
