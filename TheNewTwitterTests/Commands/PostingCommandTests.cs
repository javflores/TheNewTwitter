using Machine.Specifications;
using TheNewTwitter.Commands;

namespace TheNewTwitterTests.Commands
{
    [Subject("PostingCommand")]
    public class When_user_action_contains_arrow
    {
        Because of = () => _canExecute = _postingCommand.CanExecute(_action);

        It can_execute_posting_command = () => _canExecute.ShouldBeTrue();

        Establish context = () =>
        {
            _action = "Juan -> That was good fun";
            _postingCommand = new PostingCommand();
        };

        static ICommand _postingCommand;
        static string _action;
        private static bool _canExecute;
    }

    [Subject("PostingCommand")]
    public class When_user_action_does_not_contain_arrow
    {
        Because of = () => _canExecute = _postingCommand.CanExecute(_action);

        It can_not_execute_posting_command = () => _canExecute.ShouldBeFalse();

        Establish context = () =>
        {
            _action = "Juan";
            _postingCommand = new PostingCommand();
        };

        static ICommand _postingCommand;
        static string _action;
        private static bool _canExecute;
    }
}