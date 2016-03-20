using System.Linq;
using Machine.Specifications;
using TheNewTwitter.Commands;

namespace TheNewTwitterTests.Commands
{
    [Subject("CommandInterpreter")]
    public class When_interpreting_user_action
    {
        public class containing_not_supported_command
        {
            Because of = () => _command = _interpreter.GetCommand("not supported yet");

            It should_create_no_command = () => _command.ShouldBeAssignableTo<NoCommand>();

            It should_not_have_any_parameter = () => _command.Parameters.Any().ShouldBeFalse();
        }

        public class in_the_form_user_name_arrow_and_message
        {
            Because of = () => _command = _interpreter.GetCommand("Juan -> That was good fun");

            It should_create_posting_command = () => _command.ShouldBeAssignableTo<PostingCommand>();

            It should_provide_user_name = () => _command.Parameters[0].ShouldEqual("Juan");

            It should_provide_posting_message_to_command = () => _command.Parameters[1].ShouldEqual("That was good fun");
        }

        public class containing_only_user_name
        {
            Because of = () => _command = _interpreter.GetCommand("Juan");

            It should_create_reading_command = () => _command.ShouldBeAssignableTo<ReadingCommand>();

            It should_provide_user_name = () => _command.Parameters[0].ShouldEqual("Juan");
        }

        public class in_the_form_user_name_follows_and_other_user_name
        {
            Because of = () => _command = _interpreter.GetCommand("Juan follows Sandro");

            It should_create_following_command = () => _command.ShouldBeAssignableTo<FollowingCommand>();

            It should_provide_user_name = () => _command.Parameters[0].ShouldEqual("Juan");

            It should_provide_following_user = () => _command.Parameters[1].ShouldEqual("Sandro");
        }

        public class in_the_form_user_name_wall
        {
            Because of = () => _command = _interpreter.GetCommand("Juan wall");

            It should_create_wall_command = () => _command.ShouldBeAssignableTo<WallCommand>();

            It should_provide_user_name = () => _command.Parameters[0].ShouldEqual("Juan");
        }

        Establish context = () =>
        {
            var commandParametersBuilder = new CommandParametersBuilder();
            _interpreter = new CommandInterpreter(commandParametersBuilder);
        };

        static ICommand _command;
        static ICommandInterpreter _interpreter;
    }
    
}
