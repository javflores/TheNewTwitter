using System.Collections.Generic;

namespace TheNewTwitter
{
    public class NoCommand : ICommand
    {
        public IList<string> Parameters { get; } = new List<string>();

        public string Execute()
        {
            throw new System.NotImplementedException();
        }
    }
}