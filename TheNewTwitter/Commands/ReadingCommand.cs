using System.Collections.Generic;
using System.Linq;
using TheNewTwitter.Users;

namespace TheNewTwitter.Commands
{
    public class ReadingCommand : ICommand
    {
        public bool CanExecute(string action)
        {
            return action.All(letter => letter != ' ');
        }

        public string Execute(string action, IEnumerable<User> users)
        {
            throw new System.NotImplementedException();
        }
    }
}