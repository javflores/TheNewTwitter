using System.Collections.Generic;

namespace TheNewTwitter.Commands
{
    public interface ICommand
    {
        IList<string> Parameters { get; }

        string Execute();
    }
}