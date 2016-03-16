using Machine.Specifications;
using Rhino.Mocks;
using TheNewTwitter;

namespace TheNewTwitterTests
{
    [Subject("CommandInvoker")]
    public class When_receiving_an_action
    {
        Because of = () => _result = _invoker.Process(_action);

        It should_get_a_command_from_command_interpreter = () => _interpreter.AssertWasCalled(x => x.GetCommand(_action));

        It returns_result_after_executing_command = () => _result.ShouldEqual(_expectedResult);

        Establish context = () =>
        {
            _action = "Juan follows Sandro";
            _expectedResult = "Sandro > What a wonderful day!";
            _interpreter = MockRepository.GenerateMock<ICommandInterpreter>();
            var command = MockRepository.GenerateMock<ICommand>();
            command.Stub(x => x.Execute()).Return(_expectedResult);
            _interpreter.Stub(x => x.GetCommand(_action)).Return(command);
            _invoker = new CommandInvoker(_interpreter);
        };

        static string _action;
        static ICommandInterpreter _interpreter;
        static CommandInvoker _invoker;
        static string _result;
        static string _expectedResult;
    }
}
