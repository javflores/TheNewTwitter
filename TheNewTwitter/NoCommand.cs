namespace TheNewTwitter
{
    public class NoCommand : ICommand
    {
        public string UserName { get; }
        public string Parameter { get; }

        public string Execute()
        {
            throw new System.NotImplementedException();
        }
    }
}