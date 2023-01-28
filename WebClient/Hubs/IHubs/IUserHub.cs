
public interface IUserHub{
    Task UserConnected(string? userId);
    Task UserDisConnected(string? userId);
    Task<bool?> IamConnected();
}