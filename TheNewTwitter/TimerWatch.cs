using System;

namespace TheNewTwitter
{
    public class TimerWatch : ITimerWatch
    {
        public DateTime CurrentTime()
        {
            return DateTime.Now;
        }
    }
}