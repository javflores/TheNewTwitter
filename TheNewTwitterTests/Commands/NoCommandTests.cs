using Machine.Specifications;
using TheNewTwitter.Commands;

namespace TheNewTwitterTests.Commands
{
    [Subject("NoCommand")]
    public class When_checking_if_no_command_can_be_executed
    {
        Because of = () => _canExecute = _noCommand.CanExecute("anything");

        It can_always_be_executed = () => _canExecute.ShouldBeTrue();

        Establish context = () =>
        {
            _noCommand = new NoCommand();
        };

        static ICommand _noCommand;
        static bool _canExecute;
    }
}