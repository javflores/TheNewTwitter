using System;

namespace TheNewTwitter
{
    public class TimerWatch : ITimerWatch
    {
        public DateTime CurrentTime()
        {
            return DateTime.Now;
        }

        public int MinutesAgo(DateTime publishedTime)
        {
            throw new NotImplementedException();
        }
    }
}