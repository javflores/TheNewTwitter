namespace TheNewTwitter
{
    public class FollowingCommand : ICommand
    {
        public string UserName { get; }
        public string Parameter { get; }

        public FollowingCommand(string userName, string parameter)
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