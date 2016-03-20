using System.Collections.Generic;
using System.Linq;
using Machine.Specifications;
using TheNewTwitter.Commands;

namespace TheNewTwitterTests.Commands
{
    [Subject("CommandParametersBuilder")]
    public class When_building_parameters
    {
        public class for_posting_command
        {
            Because of = () => _parameters = _parametersBuilder.Build(CommandTypes.Posting, _action);

            It should_build_two_parameters = () => _parameters.Count.ShouldEqual(2);

            It should_get_user_name = () => _parameters[0].ShouldEqual("Juan");

            It should_get_posting_message = () => _parameters[1].ShouldEqual("That was good fun");

            Establish context = () =>
            {
                _action = new List<string>
                {
                    "Juan",
                    "->",
                    "That", "was", "good", "fun"
                };
            };
        }

        public class for_reading_command
        {
            Because of = () => _parameters = _parametersBuilder.Build(CommandTypes.Reading, _action);

            It should_build_one_parameter = () => _parameters.Count.ShouldEqual(1);

            It should_get_user_name = () => _parameters.Single().ShouldEqual("Juan");

            Establish context = () =>
            {
                _action = new List<string> { "Juan" };
            };
        }

        public class for_following_command
        {
            Because of = () => _parameters = _parametersBuilder.Build(CommandTypes.Following, _action);

            It should_build_two_parameters = () => _parameters.Count.ShouldEqual(2);

            It should_get_user_name = () => _parameters[0].ShouldEqual("Juan");

            It should_get_following_user = () => _parameters[1].ShouldEqual("Sandro");

            Establish context = () =>
            {
                _action = new List<string> { "Juan", "follows", "Sandro" };
            };
        }

        public class for_wall_command
        {
            Because of = () => _parameters = _parametersBuilder.Build(CommandTypes.Wall, _action);

            It should_build_one_parameter = () => _parameters.Count.ShouldEqual(1);

            It should_get_user_name = () => _parameters[0].ShouldEqual("Juan");

            Establish context = () =>
            {
                _action = new List<string> { "Juan", "wall" };
            };
        }

        Establish context = () =>
        {
            _parametersBuilder = new CommandParametersBuilder();
        };

        static ICommandParametersBuilder _parametersBuilder;
        static IList<string> _parameters;
        static IList<string> _action;
    }
}