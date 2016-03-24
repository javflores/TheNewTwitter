using System.Collections.Generic;

namespace TheNewTwitter
{
    public interface IDisplay
    {
        void Show(IList<string> result);
    }
}