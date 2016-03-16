using Machine.Specifications;
using Rhino.Mocks;
using TheNewTwitter;

namespace TheNewTwitterTests
{
    [Subject("Client")]
    public class When_user_executes_action_on_new_twitter_client
    {
        Because of = () => _client.Execute(_action);

        It should_pass_action_to_command_invoker = () => _invoker.AssertWasCalled(x => x.Process(_action));

        It should_display_command_result = () => _display.AssertWasCalled(y => y.Show(_result));

        Establish context = () =>
        {
            _action = "Juan follows Sandro";
            _result = "Sandro > What a nice weather!";
            _invoker = MockRepository.GenerateMock<ICommandInvoker>();
            _display = MockRepository.GenerateMock<IDisplay>();
            _invoker.Stub(x => x.Process(_action)).Return(_result);
            _client = new Client(_invoker, _display);
        };

        static Client _client;
        static ICommandInvoker _invoker;
        static string _action;
        static string _result;
        static IDisplay _display;
    }
}
