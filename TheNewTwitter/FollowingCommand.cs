using System.Collections.Generic;

namespace TheNewTwitter
{
    public class FollowingCommand : ICommand
    {
        public IList<string> Parameters { get; }

        public FollowingCommand(IList<string> parameters)
        {
            Parameters = parameters;
        }

        public string Execute()
        {
            throw new System.NotImplementedException();
        }
    }
}