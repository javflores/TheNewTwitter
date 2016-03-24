using System.Collections.Generic;
using TheNewTwitter.Users;

namespace TheNewTwitter.Commands
{
    public class FollowingCommand : ICommand
    {
        const string FollowingCommandKeyword = "follows";

        public bool CanExecute(string action)
        {
            return action.Contains(FollowingCommandKeyword);
        }

        public IList<string> Execute(string action, IEnumerable<User> users)
        {
            throw new System.NotImplementedException();
        }
    }
}