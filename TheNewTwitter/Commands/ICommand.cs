using System.Collections.Generic;
using TheNewTwitter.Users;

namespace TheNewTwitter.Commands
{
    public interface ICommand
    {
        bool CanExecute(string action);
        string Execute(string action, IEnumerable<User> users);
    }
}