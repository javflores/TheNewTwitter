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
}