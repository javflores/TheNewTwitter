using System.Collections.Generic;

namespace TheNewTwitter.Commands
{
    public class PostingCommand : ICommand
    {
        public IList<string> Parameters { get; }

        public PostingCommand(IList<string> parameters)
        {
            Parameters = parameters;
        }

        public string Execute()
        {
            throw new System.NotImplementedException();
        }
    }
}