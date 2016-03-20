using System.Collections.Generic;

namespace TheNewTwitter.Commands
{
    public class CommandInterpreter : ICommandInterpreter
    {
        readonly ICommandParametersBuilder _parametersBuilder;

        public CommandInterpreter(ICommandParametersBuilder parametersBuilder)
        {
            _parametersBuilder = parametersBuilder;
        }

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
            if (IsPosting(parsedAction))
            {
                return new PostingCommand(_parametersBuilder.Build(CommandTypes.Posting, parsedAction));
            }

            if (IsReading(parsedAction))
            {
                return new ReadingCommand(_parametersBuilder.Build(CommandTypes.Reading, parsedAction));
            }

            if (IsFollowing(parsedAction))
            {
                return new FollowingCommand(_parametersBuilder.Build(CommandTypes.Following, parsedAction));
            }

            if (IsWall(parsedAction))
            {
                return new WallCommand(_parametersBuilder.Build(CommandTypes.Wall, parsedAction));
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