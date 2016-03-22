namespace TheNewTwitter.Commands
{
    public class PostingCommand : ICommand
    {
        const string PostingCommandKeyword = "->";

        public bool CanExecute(string action)
        {
            return action.Contains(PostingCommandKeyword);
        }

        public string Execute()
        {
            throw new System.NotImplementedException();
        }
    }
}