using System.Collections.Generic;

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
            var parsedAction = ParseAction(action);

            if (IsReading(parsedAction))
            {
                return new ReadingCommand();
            }

            if (IsPosting(parsedAction))
            {
                return new PostingCommand();
            }

            if (IsFollowing(parsedAction))
            {
                return new FollowingCommand();
            }

            if (IsWall(parsedAction))
            {
                return new WallCommand();
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
    }
}