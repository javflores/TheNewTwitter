using System;

namespace TheNewTwitter
{
    public class Post
    {
        readonly ITimerWatch _timer;

        public string Message { get; }
        public string User { get; }
        public virtual DateTime PublishedTime { get; private set; }

        public Post(string user, string message, ITimerWatch timer)
        {
            _timer = timer;

            User = user;
            Message = message;
            PublishedTime = _timer.CurrentTime();
        }

        public virtual string ToTimelineFormat()
        {
            return $"{Message} ({_timer.MinutesAgo(PublishedTime)} minutes ago)";
        }

        public virtual string ToWallFormat()
        {
            return $"{User} - {Message} ({_timer.MinutesAgo(PublishedTime)} minutes ago)";
        }
    }
}