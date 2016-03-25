using System.Collections.Generic;
using System.Linq;
using TheNewTwitter.Commands;

namespace TheNewTwitter
{
    public class Client
    {
        readonly IList<ICommand> _commands;

        public Client(IList<ICommand> commands)
        {
            _commands = commands;
        }

        public IList<string> Process(string action)
        {
            var command = GetCommand(action);
            return command.Execute(action, new List<User>());
        }

        ICommand GetCommand(string action)
        {
            return _commands.FirstOrDefault(command => command.CanExecute(action));
        }
    }
}
