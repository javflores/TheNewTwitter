using System.Collections.Generic;
using Machine.Specifications;
using Rhino.Mocks;
using TheNewTwitter;
using TheNewTwitter.Commands;
using TheNewTwitter.Model;

namespace TheNewTwitterTests
{
    [Subject("Client")]
    public class When_user_executes_action_on_new_twitter_client
    {
        Because of = () => _result = _client.Process(_action);

        It should_check_if_command_can_be_executed = () =>
        {
            _possibleToExecuteCommand.AssertWasCalled(x => x.CanExecute(_action));
            _cannotExecuteCommand.AssertWasCalled(x => x.CanExecute(_action));
        };

        It should_only_execute_relevant_command = () =>
        {
            _possibleToExecuteCommand.AssertWasCalled(command => command.Execute(_action, _users));
            _cannotExecuteCommand.AssertWasNotCalled(command => command.Execute(_action, _users));
        };

        It returns_command_result = () => _result.ShouldEqual(_commandResult);

        Establish context = () =>
        {
            _users = MockRepository.GenerateMock<IUsers>();

            _action = "Juan follows Sandro";
            _commandResult = new List<string> { "Sandro > What a nice weather!" };

            _possibleToExecuteCommand = CreateFakeCommand(true);
            _cannotExecuteCommand = CreateFakeCommand(false);
            var commands = new List<ICommand> { _cannotExecuteCommand, _possibleToExecuteCommand };

            _client = new Client(commands, _users);
        };

        static ICommand CreateFakeCommand(bool canExecute)
        {
            var fakeCommand = MockRepository.GenerateMock<ICommand>();
            fakeCommand.Stub(x => x.CanExecute(_action)).Return(canExecute);
            fakeCommand.Stub(x => x.Execute(_action, _users)).Return(_commandResult);

            return fakeCommand;
        }

        static Client _client;
        static string _action;
        static IList<string> _commandResult;
        static IList<string> _result;
        static ICommand _cannotExecuteCommand;
        static ICommand _possibleToExecuteCommand;
        static IUsers _users;
    }
}
