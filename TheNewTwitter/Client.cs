using System.Collections.Generic;
using System.Linq;
using TheNewTwitter.Commands;
using TheNewTwitter.Users;

namespace TheNewTwitter
{
    public class Client
    {
        readonly IList<ICommand> _commands;
        readonly IDisplay _display;

        public Client(IList<ICommand> commands, IDisplay display)
        {
            _commands = commands;
            _display = display;
        }

        public void Process(string action)
        {
            var command = GetCommand(action);
            var result = command.Execute(action, new List<User>());
            _display.Show(result);
        }

        ICommand GetCommand(string action)
        {
            return _commands.FirstOrDefault(command => command.CanExecute(action));
        }
    }
}
