using System.Collections.Generic;
using System.Linq;

namespace TheNewTwitter.Commands
{
    public class ReadingCommand : ICommand
    {
        const char CommandSeparator = ' ';

        public bool CanExecute(string action)
        {
            return action.All(letter => letter != CommandSeparator);
        }

        public IList<string> Execute(string action, IUsers users)
        {
            return users.Get(action)
                .Timeline
                .Select(post => post.ToTimelineFormat())
                .ToList();
        }
    }
}