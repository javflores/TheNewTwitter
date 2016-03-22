using Machine.Specifications;
using TheNewTwitter.Commands;

namespace TheNewTwitterTests.Commands
{
    [Subject("FollowingCommand")]
    public class When_user_action_contains_keyword_follows
    {
        Because of = () => _canExecute = _followingCommand.CanExecute(_action);

        It can_execute_following_command = () => _canExecute.ShouldBeTrue();

        Establish context = () =>
        {
            _action = "Juan follows Sandro";
            _followingCommand = new FollowingCommand();
        };

        static ICommand _followingCommand;
        static string _action;
        static bool _canExecute;
    }

    [Subject("FollowingCommand")]
    public class When_user_action_does_not_contain_keyword_follows
    {
        Because of = () => _canExecute = _followingCommand.CanExecute(_action);

        It can_not_execute_following_command = () => _canExecute.ShouldBeFalse();

        Establish context = () =>
        {
            _action = "Juan";
            _followingCommand = new FollowingCommand();
        };

        static ICommand _followingCommand;
        static string _action;
        static bool _canExecute;
    }
}