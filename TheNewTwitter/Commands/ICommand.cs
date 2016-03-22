namespace TheNewTwitter.Commands
{
    public interface ICommand
    {
        bool CanExecute(string action);
        string Execute();
    }
}