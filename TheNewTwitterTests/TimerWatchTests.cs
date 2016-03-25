using System;
using Machine.Specifications;
using TheNewTwitter;

namespace TheNewTwitterTests
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
    public class When_getting_minutes_ago_that_post_was_published
    {
        public class and_post_was_published_same_hour
        {
            Because of = () => _result = _timer.MinutesAgo(_publishedTime);

            It returns_number_of_minutes = () => _result.ShouldEqual(2);

            Establish context = () => _publishedTime = DateTime.Now.AddMinutes(-2);
        }

        public class with_post_published_previous_hour
        {
            Because of = () => _result = _timer.MinutesAgo(_publishedTime);

            It returns_number_of_minutes = () => _result.ShouldEqual(62);

            Establish context = () => _publishedTime = DateTime.Now.AddMinutes(-62);
        }

        Establish context = () => _timer = new TimerWatch();

        static int _result;
        static ITimerWatch _timer;
        static DateTime _publishedTime;
    }
}