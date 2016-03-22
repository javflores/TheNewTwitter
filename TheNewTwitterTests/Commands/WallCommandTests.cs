using Machine.Specifications;
using TheNewTwitter.Commands;

namespace TheNewTwitterTests.Commands
{
    [Subject("WallCommand")]
    public class When_user_action_contains_keyword_wall
    {
        Because of = () => _canExecute = _wallCommand.CanExecute(_action);

        It can_execute_wall_command = () => _canExecute.ShouldBeTrue();

        Establish context = () =>
        {
            _action = "Juan wall";
            _wallCommand = new WallCommand();
        };

        static ICommand _wallCommand;
        static string _action;
        static bool _canExecute;
    }

    [Subject("WallCommand")]
    public class When_user_action_does_not_contain_keyword_wall
    {
        Because of = () => _canExecute = _wallCommand.CanExecute(_action);

        It can_not_execute_wall_command = () => _canExecute.ShouldBeFalse();

        Establish context = () =>
        {
            _action = "Juan";
            _wallCommand = new WallCommand();
        };

        static ICommand _wallCommand;
        static string _action;
        static bool _canExecute;
    }
}