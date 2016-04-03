using Machine.Specifications;
using TheNewTwitter.Users;

namespace TheNewTwitterTests.Users
{
    [Subject("User")]
    public class When_creating_user
    {
        Because of = () => _user = new User(_name);

        It assigns_name = () => _user.Name.ShouldEqual(_name);

        It initializes_empty_timeline = () => _user.Timeline.ShouldBeEmpty();

        It initializes_empty_following_list = () => _user.Following.ShouldBeEmpty();

        Establish context = () => _name = "Juan";

        static string _name;
        static User _user;
    }
}