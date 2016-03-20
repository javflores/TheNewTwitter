using System.Collections.Generic;

namespace TheNewTwitter.Commands
{
    public class WallCommand : ICommand
    {
        public IList<string> Parameters { get; }

        public WallCommand(IList<string> parameters)
        {
            Parameters = parameters;
        }

        public string Execute()
        {
            throw new System.NotImplementedException();
        }
    }
}