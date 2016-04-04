using System;

namespace TheNewTwitter.Infrasctructure
{
    public interface ITimerWatch
    {
        DateTime CurrentTime();
        TimeAgo GetTimeAgo(DateTime publishedTime);
    }

    public class TimerWatch : ITimerWatch
    {
        public DateTime CurrentTime()
        {
            return DateTime.Now;
        }

        public TimeAgo GetTimeAgo(DateTime publishedTime)
        {
            var now = DateTime.Now;
            if (MoreThanAMinuteAgo(publishedTime, now))
            {
                return MinutesBasedTimeAgo(publishedTime, now);
            }

            return SecondsBasedTimeAgo(publishedTime, now);
        }

        bool MoreThanAMinuteAgo(DateTime publishedTime, DateTime now)
        {
            return now.Subtract(publishedTime).Minutes > 0;
        }

        TimeAgo MinutesBasedTimeAgo(DateTime publishedTime, DateTime now)
        {
            var numberOfMinutes = GetNumberOfMinutes(publishedTime, now);
            return new TimeAgo(numberOfMinutes, TimeAgo.Minutes);
        }

        int GetNumberOfMinutes(DateTime publishedTime, DateTime now)
        {
            return (now.Hour - publishedTime.Hour) * 60 + now.Minute - publishedTime.Minute;
        }

        TimeAgo SecondsBasedTimeAgo(DateTime publishedTime, DateTime now)
        {
            var numberOfSeconds = GetNumberOfSeconds(publishedTime, now);
            return new TimeAgo(numberOfSeconds, TimeAgo.Seconds);
        }

        int GetNumberOfSeconds(DateTime publishedTime, DateTime now)
        {
            return (now.Minute - publishedTime.Minute) * 60 + now.Second - publishedTime.Second;
        }
    }
}