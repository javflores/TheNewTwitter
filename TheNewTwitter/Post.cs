﻿using System;

namespace TheNewTwitter
{
    public class Post
    {
        readonly ITimerWatch _timer;

        public string Message { get; }
        public string User { get; }
        public DateTime Time { get; private set; }

        public Post(string user, string message, ITimerWatch timer)
        {
            _timer = timer;

            User = user;
            Message = message;
            Time = _timer.CurrentTime();
        }

        public string ToTimelineFormat()
        {
            return $"{Message}";
        }

        public string ToWallFormat()
        {
            return $"{User} - {Message}";
        }
    }
}