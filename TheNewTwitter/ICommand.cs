namespace TheNewTwitter
{
    public interface ICommand
    {
        string UserName { get; }
        string Parameter { get; }
        string Execute();
    }
}