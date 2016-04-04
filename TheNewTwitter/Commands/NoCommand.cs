using System.Collections.Generic;
using TheNewTwitter.Model;

namespace TheNewTwitter.Commands
{
    public class NoCommand : ICommand
    {
        public bool CanExecute(string action)
        {
            return true;
        }

        public IList<string> Execute(string action, IUsers users)
        {
            return new List<string>();
        }
    }
}