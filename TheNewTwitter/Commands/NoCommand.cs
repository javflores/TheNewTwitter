using System.Collections.Generic;
using TheNewTwitter.Users;

namespace TheNewTwitter.Commands
{
    public class NoCommand : ICommand
    {
        public bool CanExecute(string action)
        {
            return true;
        }

        public string Execute(string action, IEnumerable<User> users)
        {
            throw new System.NotImplementedException();
        }
    }
}