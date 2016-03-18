namespace TheNewTwitter
{
    public class WallCommand : ICommand
    {
        public string UserName { get; }
        public string Parameter { get; }

        public WallCommand(string userName)
        {
            UserName = userName;
        }

        public string Execute()
        {
            throw new System.NotImplementedException();
        }
    }
}