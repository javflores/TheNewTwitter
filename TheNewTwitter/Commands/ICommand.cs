using System.Collections.Generic;

namespace TheNewTwitter.Commands
{
    public interface ICommand
    {
        bool CanExecute(string action);
        IList<string> Execute(string action, IUsers users);
    }
}