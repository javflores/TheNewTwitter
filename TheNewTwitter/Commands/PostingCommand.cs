using System;
using System.Collections.Generic;
using System.Linq;
using TheNewTwitter.Users;

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

        public string Execute(string action, IEnumerable<User> users)
        {
            AddNewPost(action, users);
            return "";
        }

        void AddNewPost(string action, IEnumerable<User> users)
        {
            var parsedAction = ParseAction(action);
            var userName = parsedAction.Item1;
            var post = new Post(parsedAction.Item2);

            users.Where(user => user.Name == userName)
                .Select(user => user.Wall)
                .First()
                .Add(post);
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