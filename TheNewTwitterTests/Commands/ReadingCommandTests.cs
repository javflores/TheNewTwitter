using System.Collections.Generic;
using Machine.Specifications;
using Rhino.Mocks;
using TheNewTwitter;
using TheNewTwitter.Commands;

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
    public class When_user_wants_to_read_given_timeline
    {
        Because of = () => _result = _readingCommand.Execute("Juan", _users);

        It gets_all_posts_for_user = () => _result.ShouldContainOnly(_messagesInTimeline);

        It does_not_get_other_users_messages = () => _result.ShouldNotContain("This is my timeline!");

        Establish context = () =>
        {
            var timer = MockRepository.GenerateMock<ITimerWatch>();
            _messagesInTimeline = new List<string> { "This is awesome", "Heading to a new LSCC talk!"};

            var firstPost = MockRepository.GenerateMock<Post>("Juan", _messagesInTimeline[0], timer);
            firstPost.Stub(p => p.ToTimelineFormat()).Return(_messagesInTimeline[0]);

            var secondPost = MockRepository.GenerateMock<Post>("Juan", _messagesInTimeline[1], timer);
            secondPost.Stub(p => p.ToTimelineFormat()).Return(_messagesInTimeline[1]);
            var usersTimeline = new List<Post> { firstPost, secondPost };

            var user = new User("Juan") {Timeline = usersTimeline};
            var other = new User("Sandro") {Timeline = new List<Post> {MockRepository.GenerateMock<Post>("Sandro", "This is my timeline!", timer)} };
            _users = new List<User> { user, other };

            _readingCommand = new ReadingCommand();
        };

        static IList<string> _result;
        static ICommand _readingCommand;
        static IEnumerable<User> _users;
        static List<string> _messagesInTimeline;
    }
}