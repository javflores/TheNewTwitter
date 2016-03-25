using System;
using System.Collections.Generic;
using System.Linq;

namespace TheNewTwitter.Commands
{
    public class FollowingCommand : ICommand
    {
        const string FollowingCommandKeyword = "follows";
        const char CommandSeparator = ' ';

        public bool CanExecute(string action)
        {
            return action.Contains(FollowingCommandKeyword);
        }

        public IList<string> Execute(string action, IEnumerable<User> users)
        {
            var parsedAction = ParseAction(action);
            AddFollowingUser(parsedAction, users);

            return new List<string>();
        }

        Tuple<string, string> ParseAction(string action)
        {
            var parseAction = action.Split(CommandSeparator);
            return new Tuple<string, string>(parseAction[0], parseAction[2]);
        }

        void AddFollowingUser(Tuple<string, string> parsedAction, IEnumerable<User> users)
        {
            users.Single(user => user.Name == parsedAction.Item1)
                .Following
                .Add(parsedAction.Item2);
        }
    }
}