using System;

namespace TheNewTwitter
{
    public interface ITimerWatch
    {
        DateTime CurrentTime();
        int MinutesAgo(DateTime publishedTime);
    }

    public class TimerWatch : ITimerWatch
    {
        public DateTime CurrentTime()
        {
            return DateTime.Now;
        }

        public int MinutesAgo(DateTime publishedTime)
        {
            var now = DateTime.Now;
            return (now.Hour - publishedTime.Hour) * 60 + now.Minute - publishedTime.Minute;
        }
    }
}