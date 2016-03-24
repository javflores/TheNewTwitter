using System.Collections.Generic;
using TheNewTwitter.Users;

namespace TheNewTwitter.Commands
{
    public class WallCommand : ICommand
    {
        const string WallCommandKeyword = "wall";

        public bool CanExecute(string action)
        {
            return action.Contains(WallCommandKeyword);
        }

        public IList<string> Execute(string action, IEnumerable<User> users)
        {
            throw new System.NotImplementedException();
        }
    }
}