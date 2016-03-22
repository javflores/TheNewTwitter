using Machine.Specifications;
using TheNewTwitter.Commands;

namespace TheNewTwitterTests.Commands
{
    [Subject("ReadingCommand")]
    public class When_user_action_contains_only_one_word
    {
        Because of = () => _canExecute = _readingCommand.CanExecute(_action);

        It can_execute_reading_command = () => _canExecute.ShouldBeTrue();

        Establish context = () =>
        {
            _action = "Juan";
            _readingCommand = new ReadingCommand();
        };

        static ICommand _readingCommand;
        static string _action;
        static bool _canExecute;
    }

    [Subject("ReadingCommand")]
    public class When_user_action_contains_any_space
    {
        Because of = () => _canExecute = _readingCommand.CanExecute(_action);

        It can_not_execute_reading_command = () => _canExecute.ShouldBeFalse();

        Establish context = () =>
        {
            _action = "Juan Sandro";
            _readingCommand = new ReadingCommand();
        };

        static ICommand _readingCommand;
        static string _action;
        static bool _canExecute;
    }
}