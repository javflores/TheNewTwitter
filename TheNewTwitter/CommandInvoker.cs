namespace TheNewTwitter
{
    public class CommandInvoker : ICommandInvoker
    {
        readonly ICommandInterpreter _interpreter;

        public CommandInvoker(ICommandInterpreter interpreter)
        {
            _interpreter = interpreter;
        }

        public string Process(string action)
        {
            var command = _interpreter.GetCommand(action);
            return command.Execute();
        }
    }
}