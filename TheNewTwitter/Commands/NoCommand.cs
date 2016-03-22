using System.Collections.Generic;

namespace TheNewTwitter.Commands
{
    public class NoCommand : ICommand
    {
        public bool CanExecute(string action)
        {
            return true;
        }

        public string Execute()
        {
            throw new System.NotImplementedException();
        }
    }
}