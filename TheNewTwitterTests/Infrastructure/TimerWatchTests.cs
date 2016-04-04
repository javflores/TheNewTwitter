using System;
using Machine.Specifications;
using TheNewTwitter.Infrasctructure;

namespace TheNewTwitterTests.Infrastructure
{
    [Subject("TimerWatch")]
    public class When_getting_current_time
    {
        Because of = () => _result = _timer.CurrentTime();

        It returns_some_date_time_value = () => _result.ShouldNotBeNull();

        Establish context = () => _timer = new TimerWatch();
        
        static DateTime _result;
        static ITimerWatch _timer;
    }

    [Subject("TimerWatch")]
    public class When_getting_time_ago_that_post_was_published
    {
        public class and_post_was_published_same_hour
        {
            Because of = () => _result = _timer.GetTimeAgo(_publishedTime);

            It returns_number_of_minutes = () =>
            {
                _result.Amount.ShouldEqual(2);
                _result.Unit.ShouldEqual(TimeAgo.Minutes);
            };

            Establish context = () => _publishedTime = DateTime.Now.AddMinutes(-2);
        }

        public class with_post_published_previous_hour
        {
            Because of = () => _result = _timer.GetTimeAgo(_publishedTime);

            It returns_number_of_minutes = () =>
            {
                _result.Amount.ShouldEqual(62);
                _result.Unit.ShouldEqual(TimeAgo.Minutes);
            };

            Establish context = () => _publishedTime = DateTime.Now.AddMinutes(-62);
        }

        public class with_post_published_less_than_a_minute_ago
        {
            Because of = () => _result = _timer.GetTimeAgo(_publishedTime);

            It returns_number_of_seconds = () =>
            {
                _result.Amount.ShouldEqual(4);
                _result.Unit.ShouldEqual(TimeAgo.Seconds);
            };

            Establish context = () => _publishedTime = DateTime.Now.AddSeconds(-4);
        }

        Establish context = () => _timer = new TimerWatch();

        static TimeAgo _result;
        static ITimerWatch _timer;
        static DateTime _publishedTime;
    }
}