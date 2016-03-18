namespace TheNewTwitter
{
    public class PostingCommand : ICommand
    {
        public string UserName { get; }
        public string Parameter { get; }

        public PostingCommand(string userName, string parameter)
        {
            UserName = userName;
            Parameter = parameter;
        }

        public string Execute()
        {
            throw new System.NotImplementedException();
        }
    }
}