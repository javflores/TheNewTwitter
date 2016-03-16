namespace TheNewTwitter
{
    public interface ICommandInterpreter
    {
        ICommand GetCommand(string action);
    }
}