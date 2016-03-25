using System.Collections.Generic;
using System.Linq;
using TheNewTwitter.Commands;

namespace TheNewTwitter
{
    public class Client
    {
        readonly IList<ICommand> _commands;
        IList<User> _users;

        public Client(IList<ICommand> commands)
        {
            _commands = commands;
            _users = new List<User>{};
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
