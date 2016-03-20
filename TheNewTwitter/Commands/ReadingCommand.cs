using System.Collections.Generic;

namespace TheNewTwitter.Commands
{
    public class ReadingCommand : ICommand
    {
        public IList<string> Parameters { get; }

        public ReadingCommand(IList<string> parameters)
        {
            Parameters = parameters;
        }

        public string Execute()
        {
            throw new System.NotImplementedException();
        }
    }
}