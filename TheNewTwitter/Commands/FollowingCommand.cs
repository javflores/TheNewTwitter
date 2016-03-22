namespace TheNewTwitter.Commands
{
    public class FollowingCommand : ICommand
    {
        const string FollowingCommandKeyword = "follows";

        public bool CanExecute(string action)
        {
            return action.Contains(FollowingCommandKeyword);
        }

        public string Execute()
        {
            throw new System.NotImplementedException();
        }
    }
}