namespace TheNewTwitter
{
    public class ReadingCommand : ICommand
    {
        public string UserName { get; }
        public string Parameter { get; }

        public ReadingCommand(string userName)
        {
            UserName = userName;
        }

        public string Execute()
        {
            throw new System.NotImplementedException();
        }
    }
}