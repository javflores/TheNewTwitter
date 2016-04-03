using System;
using System.Collections.Generic;
using System.Linq;
using TheNewTwitter.Users;

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

        public IList<string> Execute(string action, IUsers users)
        {
            var parsedAction = ParseAction(action);
            AddFollowingUser(parsedAction, users);

            return new List<string>();
        }

        Tuple<string, string> ParseAction(string action)
        {
            var parsedAction = action.Split(CommandSeparator);
            return new Tuple<string, string>(parsedAction[0], parsedAction[2]);
        }

        void AddFollowingUser(Tuple<string, string> parsedAction, IUsers users)
        {
            users.Get(parsedAction.Item1)
                .Following
                .Add(parsedAction.Item2);
        }
    }
}