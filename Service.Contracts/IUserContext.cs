namespace Service.Contracts;

public interface IUserContext
{
    bool IsAuthenticate { get; }
    Guid UserId { get; }
}
