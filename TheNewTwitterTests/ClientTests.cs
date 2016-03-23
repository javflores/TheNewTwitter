using System.Collections.Generic;
using System.Linq;
using Machine.Specifications;
using Rhino.Mocks;
using TheNewTwitter;
using TheNewTwitter.Commands;
using TheNewTwitter.Users;

namespace TheNewTwitterTests
{
    [Subject("Client")]
    public class When_user_executes_action_on_new_twitter_client
    {
        Because of = () => _client.Process(_action);

        It should_check_if_command_can_execute = () => _possibleToExecuteCommand.AssertWasCalled(x => x.CanExecute(_action));

        It should_execute_command = () => _possibleToExecuteCommand.AssertWasCalled(x => x.Execute(_action, Enumerable.Empty<User>()));

        It should_display_command_result = () => _display.AssertWasCalled(y => y.Show(_result));

        Establish context = () =>
        {
            _action = "Juan follows Sandro";
            _result = "Sandro > What a nice weather!";
            _display = MockRepository.GenerateMock<IDisplay>();

            _possibleToExecuteCommand = MockRepository.GenerateMock<ICommand>();
            _possibleToExecuteCommand.Stub(x => x.CanExecute(_action)).Return(true);
            _possibleToExecuteCommand.Stub(x => x.Execute(_action, Enumerable.Empty<User>())).Return(_result);

            var cannotExecuteCommand = MockRepository.GenerateMock<ICommand>();
            cannotExecuteCommand.Stub(x => x.CanExecute(_action)).Return(false);
            var commands = new List<ICommand> { cannotExecuteCommand, _possibleToExecuteCommand };

            _client = new Client(commands, _display);
        };

        static Client _client;
        static string _action;
        static string _result;
        static IDisplay _display;
        static ICommand _possibleToExecuteCommand;
    }
}
