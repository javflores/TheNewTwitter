namespace TheNewTwitter.Commands
{
    public interface ICommandInterpreter
    {
        ICommand GetCommand(string action);
    }
}