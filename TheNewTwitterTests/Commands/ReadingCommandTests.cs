using System;
using System.Collections.Generic;
using System.Linq;
using Machine.Specifications;
using Rhino.Mocks;
using TheNewTwitter;
using TheNewTwitter.Commands;
using TheNewTwitter.Posts;
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

            Establish context = () => _action = "Juan";
        }

        public class with_user_action_containing_any_space
        {
            Because of = () => _canExecute = _readingCommand.CanExecute(_action);

            It can_not_execute_reading_command = () => _canExecute.ShouldBeFalse();

            Establish context = () => _action = "Juan Sandro";
        }

        Establish context = () => _readingCommand = new ReadingCommand();

        static ICommand _readingCommand;
        static string _action;
        static bool _canExecute;
    }

    [Subject("ReadingCommand")]
    public class When_user_wants_to_read_users_timeline
    {
        Because of = () => _result = _readingCommand.Execute(_userName, _users);

        It gets_all_posts_for_user = () => _result.ShouldContain(_messagesInTimeline);

        It shows_latest_published_post_first = () => _result.First().ShouldEqual("Heading to a new LSCC talk!");

        Establish context = () =>
        {
            var timer = MockRepository.GenerateMock<ITimerWatch>();
            _userName = "Juan";
            _messagesInTimeline = new List<string> { "This is awesome", "Heading to a new LSCC talk!"};
            var firstPost = CreateFakePost(_userName, _messagesInTimeline[0], 5, timer);
            var secondPost = CreateFakePost(_userName, _messagesInTimeline[1], 2, timer);
            var usersTimeline = new List<Post> { firstPost, secondPost };
            var user = new User(_userName) {Timeline = usersTimeline};

            _users = MockRepository.GenerateMock<IUsers>();
            _users.Stub(u => u.Get(_userName)).Return(user);
       
            _readingCommand = new ReadingCommand();
        };

        static Post CreateFakePost(string userName, string message, int minutesAgo, ITimerWatch timer)
        {
            var post = MockRepository.GenerateMock<Post>(userName, message, timer);
            post.Stub(p => p.PublishedTime).Return(DateTime.Now.AddMinutes(-minutesAgo));
            post.Stub(p => p.ToTimelineFormat()).Return(message);
            return post;
        }

        static IList<string> _result;
        static ICommand _readingCommand;
        static IUsers _users;
        static List<string> _messagesInTimeline;
        static string _userName;
    }
}