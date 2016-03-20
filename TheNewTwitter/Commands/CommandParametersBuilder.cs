using System.Collections.Generic;
using System.Linq;

namespace TheNewTwitter.Commands
{
    public class CommandParametersBuilder : ICommandParametersBuilder
    {
        const string UserActionSeparator = " ";

        public IList<string> Build(CommandTypes type, IList<string> action)
        {
            return AddUser(action)
                .Concat(AddParameter(type, action))
                .ToList();
        }

        IList<string> AddUser(IList<string> parsedAction)
        {
            return new List<string> { parsedAction[0] };
        }

        IEnumerable<string> AddParameter(CommandTypes type, IList<string> parseAction)
        {
            if (type == CommandTypes.Posting)
            {
                return GetMessage(parseAction);
            }

            if (type == CommandTypes.Following)
            {
                return GetFollowingUser(parseAction);
            }

            return new List<string>();
        }

        IEnumerable<string> GetMessage(IList<string> parsedAction)
        {
            return new List<string>
            {
                parsedAction
                    .Where(word => parsedAction.IndexOf(word) != 0 && parsedAction.IndexOf(word) != 1)
                    .Aggregate((word, nextWord) => word + UserActionSeparator + nextWord)
            };
        }

        IEnumerable<string> GetFollowingUser(IList<string> parsedAction)
        {
            return new List<string>
            {
                parsedAction[2]
            };
        }
    }
}