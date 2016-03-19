using System.Collections.Generic;

namespace TheNewTwitter
{
    public interface ICommandParametersBuilder
    {
        IList<string> Build(CommandTypes type, IList<string> action);
    }
}