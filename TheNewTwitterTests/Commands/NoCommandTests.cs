using System.Collections.Generic;
using Machine.Specifications;
using TheNewTwitter;
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

    [Subject("NoCommand")]
    public class When_executing_no_command
    {
        Because of = () => _result = _noCommand.Execute("weird command", new List<User>());

        It returns_empty_result = () => _result.ShouldBeEmpty();

        Establish context = () =>
        {
            _noCommand = new NoCommand();
        };

        static IList<string> _result;
        static ICommand _noCommand;
    }
}