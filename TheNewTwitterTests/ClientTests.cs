using System.Collections.Generic;
using System.Linq;
using Machine.Specifications;
using Rhino.Mocks;
using TheNewTwitter;
using TheNewTwitter.Commands;

namespace TheNewTwitterTests
{
    [Subject("Client")]
    public class When_user_executes_action_on_new_twitter_client
    {
        Because of = () => _result = _client.Process(_action);

        It should_check_if_command_can_execute = () => _possibleToExecuteCommand.AssertWasCalled(x => x.CanExecute(_action));

        It should_execute_command = () => _possibleToExecuteCommand.AssertWasCalled(x => x.Execute(_action, Enumerable.Empty<User>()));

        It returns_command_result = () => _result.ShouldEqual(_commandResult);

        Establish context = () =>
        {
            _action = "Juan follows Sandro";
            _commandResult = new List<string> { "Sandro > What a nice weather!" };

            _possibleToExecuteCommand = MockRepository.GenerateMock<ICommand>();
            _possibleToExecuteCommand.Stub(x => x.CanExecute(_action)).Return(true);
            _possibleToExecuteCommand.Stub(x => x.Execute(_action, Enumerable.Empty<User>())).Return(_commandResult);

            var cannotExecuteCommand = MockRepository.GenerateMock<ICommand>();
            cannotExecuteCommand.Stub(x => x.CanExecute(_action)).Return(false);
            var commands = new List<ICommand> { cannotExecuteCommand, _possibleToExecuteCommand };

            _client = new Client(commands);
        };

        static Client _client;
        static string _action;
        static IList<string> _commandResult;
        static IList<string> _result;
        static ICommand _possibleToExecuteCommand;
    }
}
