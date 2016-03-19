using System.Collections.Generic;

namespace TheNewTwitter
{
    public interface ICommand
    {
        IList<string> Parameters { get; }

        string Execute();
    }
}