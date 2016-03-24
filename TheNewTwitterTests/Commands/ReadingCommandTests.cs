using System.Collections.Generic;
using Machine.Specifications;
using TheNewTwitter.Commands;
using TheNewTwitter.Users;

namespace TheNewTwitterTests.Commands
{
    [Subject("ReadingCommand")]
    public class When_checking_if_reading_command_can_be_executed
    {
        public class with_user_action_containing_only_one_word
        {
            Because of = () => _canExecute = _readingCommand.CanExecute(_action);

            It can_execute_reading_command = () => _canExecute.ShouldBeTrue();

            Establish context = () =>
            {
                _action = "Juan";
            };
        }

        public class with_user_action_containing_any_space
        {
            Because of = () => _canExecute = _readingCommand.CanExecute(_action);

            It can_not_execute_reading_command = () => _canExecute.ShouldBeFalse();

            Establish context = () =>
            {
                _action = "Juan Sandro";
            };
        }

        Establish context = () =>
        {
            _readingCommand = new ReadingCommand();
        };

        static ICommand _readingCommand;
        static string _action;
        static bool _canExecute;
    }

    [Subject("ReadingCommand")]
    public class When_user_wants_to_read_given_wall
    {
        Because of = () => _result = _readingCommand.Execute("Juan", _users);

        It gets_all_posts_for_user = () => _result.ShouldContainOnly(_messagesInWall);

        It does_not_get_other_users_messages = () => _result.ShouldNotContain("Sandro wall message");

        Establish context = () =>
        {
            _messagesInWall = new List<string> { "This is awesome", "Heading to a new LSCC talk!"};
            var wall = new List<Post>()
            {
                new Post("Juan", _messagesInWall[0]),
                new Post("Juan", _messagesInWall[1])
            };

            var user = new User("Juan") {Wall = wall};
            var other = new User("Sandro") {Wall = new List<Post> {new Post("Sandro", "Sandro wall message")} };
            _users = new List<User> { user, other };

            _readingCommand = new ReadingCommand();
        };

        static IList<string> _result;
        static ICommand _readingCommand;
        static IEnumerable<User> _users;
        static List<string> _messagesInWall;
    }
}