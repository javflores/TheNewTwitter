namespace TheNewTwitter
{
    public class NoCommand : ICommand
    {
        public string Execute()
        {
            throw new System.NotImplementedException();
        }
    }
}