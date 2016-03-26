using System;
using System.Collections.Generic;
using System.Linq;

namespace TheNewTwitter.Commands
{
    public class PostingCommand : ICommand
    {
        const char CommandSeparator = ' ';
        const string PostingCommandKeyword = "->";

        public bool CanExecute(string action)
        {
            return action.Contains(PostingCommandKeyword);
        }

        public IList<string> Execute(string action, IUsers users)
        {
            AddNewPost(action, users);
            return new List<string>();
        }

        void AddNewPost(string action, IUsers users)
        {
            var parsedAction = ParseAction(action);
            var userName = parsedAction.Item1;
            var message = parsedAction.Item2;

            users.Add(userName);

            users.Get(parsedAction.Item1)
                .Timeline
                .Add(new Post(userName, message, new TimerWatch()));
        }

        Tuple<string, string> ParseAction(string action)
        {
            var parseAction = action.Split(CommandSeparator);
            var post = ExtractPost(parseAction);
            return new Tuple<string, string>(parseAction[0], post);
        }

        string ExtractPost(IList<string> parseAction)
        {
            return parseAction
                .Where(word => parseAction.IndexOf(word) != 0 && parseAction.IndexOf(word) != 1)
                .Aggregate((word, nextWord) => word + CommandSeparator + nextWord);
        }
    }
}