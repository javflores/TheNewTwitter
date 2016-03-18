using System.Collections.Generic;
using System.Linq;

namespace TheNewTwitter
{
    public class CommandInterpreter : ICommandInterpreter
    {
        const string PostingCommandKeyword = "->";
        const string FollowingCommandKeyword = "follows";
        const string WallCommandKeyword = "wall";
        const string UserActionSeparator = " ";

        public ICommand GetCommand(string action)
        {
            return ToCommand(ParseAction(action));
        }

        ICommand ToCommand(IList<string> parsedAction)
        {
            var userName = GetUser(parsedAction);
            if (IsPosting(parsedAction))
            {
                return new PostingCommand(userName, GetMessage(parsedAction));
            }

            if (IsReading(parsedAction))
            {
                return new ReadingCommand(userName);
            }

            if (IsFollowing(parsedAction))
            {
                return new FollowingCommand(userName, GetFollowingUser(parsedAction));
            }

            if (IsWall(parsedAction))
            {
                return new WallCommand(userName);
            }

            return new NoCommand();
        }

        IList<string> ParseAction(string action)
        {
            return action.Split(UserActionSeparator.ToCharArray());
        }

        bool IsPosting(IList<string> parsedAction)
        {
            return parsedAction.Contains(PostingCommandKeyword);
        }

        bool IsReading(IList<string> parsedAction)
        {
            return parsedAction.Count == 1;
        }

        bool IsFollowing(IList<string> parsedAction)
        {
            return parsedAction.Contains(FollowingCommandKeyword);
        }

        bool IsWall(IList<string> parsedAction)
        {
            return parsedAction.Contains(WallCommandKeyword);
        }

        string GetUser(IList<string> parsedAction)
        {
            return parsedAction.First();
        }

        string GetMessage(IList<string> parsedAction)
        {
            return parsedAction
                .Where(word => parsedAction.IndexOf(word) != 0 && parsedAction.IndexOf(word) != 1)
                .Aggregate((word, nextWord) => word + UserActionSeparator + nextWord);
        }

        string GetFollowingUser(IList<string> parsedAction)
        {
            return parsedAction[2];
        }

    }
}