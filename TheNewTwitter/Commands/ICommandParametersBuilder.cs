using System.Collections.Generic;

namespace TheNewTwitter.Commands
{
    public interface ICommandParametersBuilder
    {
        IList<string> Build(CommandTypes type, IList<string> action);
    }
}