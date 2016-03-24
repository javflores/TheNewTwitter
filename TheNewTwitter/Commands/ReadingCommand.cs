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

        public IList<string> Execute(string action, IEnumerable<User> users)
        {
            return users.Single(user => user.Name == action)
                .Wall
                .Select(post => post.Message)
                .ToList();
        }
    }
}