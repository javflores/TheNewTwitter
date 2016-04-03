using System;

namespace TheNewTwitter.Posts
{
    public class Post
    {
        readonly ITimerWatch _timer;

        public string Message { get; }
        public string User { get; }
        public virtual DateTime PublishedTime { get; }

        public Post(string user, string message, ITimerWatch timer)
        {
            _timer = timer;

            User = user;
            Message = message;
            PublishedTime = _timer.CurrentTime();
        }

        public virtual string ToTimelineFormat()
        {
            var timeAgo = _timer.GetTimeAgo(PublishedTime);
            return $"{Message} ({timeAgo.Amount} {timeAgo.Unit} ago)";
        }

        public virtual string ToWallFormat()
        {
            var timeAgo = _timer.GetTimeAgo(PublishedTime);
            return $"{User} - {Message} ({timeAgo.Amount} {timeAgo.Unit} ago)";
        }
    }
}