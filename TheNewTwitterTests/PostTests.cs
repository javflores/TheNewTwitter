using Machine.Specifications;
using TheNewTwitter;

namespace TheNewTwitterTests
{
    [Subject("Post")]
    public class When_creating_post
    {
        Because of = () => _post = new Post(_user, _message);

        It assigns_user = () => _post.User.ShouldEqual(_user);

        It assigns_message = () => _post.Message.ShouldEqual(_message);

        Establish context = () =>
        {
            _user = "Juan";
            _message = "This is awesome";
        };

        static string _message;
        static Post _post;
        static string _user;
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
            _post = new Post("Juan", "This is the best post");
        };
        
        static string _result;
        static Post _post;
    }
}