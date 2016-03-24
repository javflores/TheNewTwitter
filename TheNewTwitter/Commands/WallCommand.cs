using System.Collections.Generic;
using System.Linq;
using TheNewTwitter.Users;

namespace TheNewTwitter.Commands
{
    public class WallCommand : ICommand
    {
        const string WallCommandKeyword = "wall";
        const char CommandSeparator = ' ';

        public bool CanExecute(string action)
        {
            return action.Contains(WallCommandKeyword);
        }

        public IList<string> Execute(string action, IEnumerable<User> users)
        {
            return users.Single(user => user.Name == ExtractUser(action))
                .Wall
                .Select(post => post.ToUserFormat())
                .ToList();
        }

        string ExtractUser(string action)
        {
            return action.Split(CommandSeparator).First();
        }
    }
}