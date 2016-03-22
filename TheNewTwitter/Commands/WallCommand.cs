namespace TheNewTwitter.Commands
{
    public class WallCommand : ICommand
    {
        const string WallCommandKeyword = "wall";

        public bool CanExecute(string action)
        {
            return action.Contains(WallCommandKeyword);
        }

        public string Execute()
        {
            throw new System.NotImplementedException();
        }
    }
}