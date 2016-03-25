using System.Collections.Generic;
using System.Linq;
using TheNewTwitter.Commands;

namespace TheNewTwitter
{
    public class Client
    {
        readonly IList<ICommand> _commands;
        IUsers _users;

        public Client(IList<ICommand> commands, IUsers users)
        {
            _commands = commands;
            _users = users;
        }

        public IList<string> Process(string action)
        {
            var command = GetCommand(action);
            return command.Execute(action, _users);
        }

        ICommand GetCommand(string action)
        {
            return _commands.FirstOrDefault(command => command.CanExecute(action));
        }
    }
}
