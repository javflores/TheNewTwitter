namespace TheNewTwitter
{
    public class Client
    {
        readonly ICommandInvoker _commandInvoker;
        readonly IDisplay _display;

        public Client(ICommandInvoker commandInvoker, IDisplay display)
        {
            _commandInvoker = commandInvoker;
            _display = display;
        }

        public void Execute(string action)
        {
            var result = _commandInvoker.Process(action);
            _display.Show(result);
        }
    }
}
