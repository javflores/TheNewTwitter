using System;

namespace TheNewTwitter
{
    public interface ITimerWatch
    {
        DateTime CurrentTime();
        int MinutesAgo(DateTime publishedTime);
    }
}