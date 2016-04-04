using System.Collections.Generic;
using TheNewTwitter.Model;

namespace TheNewTwitter.Commands
{
    public interface ICommand
    {
        bool CanExecute(string action);
        IList<string> Execute(string action, IUsers users);
    }
}