using System.Linq;

namespace TheNewTwitter.Commands
{
    public class ReadingCommand : ICommand
    {
        public bool CanExecute(string action)
        {
            return action.All(letter => letter != ' ');
        }

        public string Execute()
        {
            throw new System.NotImplementedException();
        }
    }
}