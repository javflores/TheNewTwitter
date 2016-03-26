using System;
using Machine.Specifications;
using Rhino.Mocks;
using TheNewTwitter;

namespace TheNewTwitterTests
{
    [Subject("Post")]
    public class When_creating_post
    {
        Because of = () => _post = new Post(_user, _message, _timer);

        It assigns_user_that_published_it = () => _post.User.ShouldEqual(_user);

        It assigns_message = () => _post.Message.ShouldEqual(_message);

        It assigns_current_time_as_published_time = () => _post.PublishedTime.ShouldEqual(_currentTime);

        Establish context = () =>
        {
            _user = "Juan";
            _message = "This is awesome";

            _currentTime = new DateTime(2020, 1, 1);
            _timer = MockRepository.GenerateMock<ITimerWatch>();
            _timer.Stub(timer => timer.CurrentTime()).Return(_currentTime);
        };

        static string _message;
        static Post _post;
        static string _user;
        static DateTime _currentTime;
        static ITimerWatch _timer;
    }

    [Subject("Post")]
    public class When_getting_post_in_timeline_format
    {
        Because of = () => _result = _post.ToTimelineFormat();

        It starts_with_message = () => _result.ShouldStartWith(_message);

        It ends_with_minutes_ago_since_it_was_published = () => _result.ShouldEndWith($"({_minutesAgo} minutes ago)");

        Establish context = () =>
        {
            var timer = MockRepository.GenerateMock<ITimerWatch>();
            var publishedTime = new DateTime(2020, 1, 1);
            _minutesAgo = 5;
            timer.Stub(t => t.CurrentTime()).Return(publishedTime);
            timer.Stub(t => t.MinutesAgo(publishedTime)).Return(_minutesAgo);

            _message = "This is the best post";
            _post = new Post("Juan", _message, timer);
        };

        static string _result;
        static Post _post;
        static string _message;
        static int _minutesAgo;
    }

    [Subject("Post")]
    public class When_getting_post_in_wall_format
    {
        Because of = () => _result = _post.ToWallFormat();

        It starts_with_name_of_user_who_published_it = () => _result.ShouldStartWith(_userName);

        It is_formatted_with_hyphern = () => _result.ShouldContain(" - ");

        It includes_message = () => _result.ShouldContain(_message);

        It ends_with_minutes_ago_it_was_published = () => _result.ShouldEndWith($"({_minutesAgo} minutes ago)");

        Establish context = () =>
        {
            var timer = MockRepository.GenerateMock<ITimerWatch>();
            var publishedTime = new DateTime(2020, 1, 1);
            _minutesAgo = 5;
            timer.Stub(t => t.CurrentTime()).Return(publishedTime);
            timer.Stub(t => t.MinutesAgo(publishedTime)).Return(_minutesAgo);
            _userName = "Juan";
            _message = "This is the best post";
            _post = new Post(_userName, _message, timer);
        };
        
        static string _result;
        static Post _post;
        static string _userName;
        static string _message;
        static int _minutesAgo;
    }
}