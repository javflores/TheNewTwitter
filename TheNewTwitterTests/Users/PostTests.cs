using Machine.Specifications;
using TheNewTwitter.Users;

namespace TheNewTwitterTests.Users
{
    [Subject("Post")]
    public class When_creating_post
    {
        Because of = () => _post = new Post(_message);

        It assigns_message = () => _post.Message.ShouldEqual(_message);

        Establish context = () =>
        {
            _message = "This is awesome";
        };

        static string _message;
        static Post _post;
    }
}