using System.Collections.Generic;
using Machine.Specifications;
using Rhino.Mocks;
using TheNewTwitter;
using TheNewTwitter.Commands;

namespace TheNewTwitterTests.Commands
{
    [Subject("WallCommand")]
    public class When_checking_if_wall_command_can_be_executed
    {
        public class with_user_action_containing_wall_keyword
        {
            Because of = () => _canExecute = _wallCommand.CanExecute(_action);

            It can_execute_wall_command = () => _canExecute.ShouldBeTrue();

            Establish context = () =>
            {
                _action = "Juan wall";
            };
        }


        public class with_user_action_not_containing_wall_keyword
        {
            Because of = () => _canExecute = _wallCommand.CanExecute(_action);

            It can_not_execute_wall_command = () => _canExecute.ShouldBeFalse();

            Establish context = () =>
            {
                _action = "Juan";
            };
        }

        Establish context = () =>
        {
            _wallCommand = new WallCommand();
        };

        static ICommand _wallCommand;
        static string _action;
        static bool _canExecute;
    }

    [Subject("WallCommand")]
    public class When_executing_wall_command_for_a_given_user
    {
        Because of = () => _wall = _wallCommand.Execute("Juan wall", _users);

        It returns_all_posts_for_that_user = () => _wall.ShouldContain("Juan - Today", "Juan - Yesterday");

        It returns_all_posts_for_following_user = () => _wall.ShouldContain("Sandro - Wicked", "Sandro - Awesome");

        Establish context = () =>
        {
            var timer = MockRepository.GenerateMock<ITimerWatch>();

            var followingUserTimeLine = new List<Post>
            {
                new Post("Sandro", "Wicked", timer),
                new Post("Sandro", "Awesome", timer)
            };
            var followingUser = new User("Sandro") { Timeline = followingUserTimeLine };
            var userPosts = new List<Post>
            {
                new Post("Juan", "Today", timer),
                new Post("Juan", "Yesterday", timer)
            };
            var user = new User("Juan") {Timeline = userPosts, Following = new[] {followingUser.Name}};
            _users = new List<User> { user, followingUser };

            _wallCommand = new WallCommand();
        };

        static IList<string> _wall;
        static IList<User> _users;
        static ICommand _wallCommand;
    }
}