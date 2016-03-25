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

        It assigns_user = () => _post.User.ShouldEqual(_user);

        It assigns_message = () => _post.Message.ShouldEqual(_message);

        It assigns_current_time = () => _post.Time.ShouldEqual(_currentTime);

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
    public class When_getting_post_in_user_format
    {
        Because of = () => _result = _post.ToUserFormat();

        It starts_with_name_of_user_who_wrote_post = () => _result.ShouldStartWith("Juan");

        It is_formatted_with_hyphern = () => _result.ShouldContain(" - ");

        It ends_with_message = () => _result.ShouldEndWith("This is the best post");

        Establish context = () =>
        {
            var timer = MockRepository.GenerateMock<ITimerWatch>();
            _post = new Post("Juan", "This is the best post", timer);
        };
        
        static string _result;
        static Post _post;
    }
}