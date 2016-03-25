using System.Collections.Generic;
using System.Linq;
using Machine.Specifications;
using TheNewTwitter;
using TheNewTwitter.Commands;

namespace TheNewTwitterTests.Commands
{
    [Subject("PostingCommand")]
    public class When_checking_if_command_is_posting
    {
        public class with_user_action_containing_arrow
        {
            Because of = () => _canExecute = _postingCommand.CanExecute(_action);

            It can_execute_posting_command = () => _canExecute.ShouldBeTrue();

            Establish context = () =>
            {
                _action = "Juan -> That was good fun";
            };
        }

        public class with_user_action_not_containing_arrow
        {
            Because of = () => _canExecute = _postingCommand.CanExecute(_action);

            It can_not_execute_posting_command = () => _canExecute.ShouldBeFalse();

            Establish context = () =>
            {
                _action = "Juan";
            };
        }

        Establish context = () =>
        {
            _postingCommand = new PostingCommand();
        };

        static ICommand _postingCommand;
        static string _action;
        static bool _canExecute;
    }

    [Subject("PostingCommand")]
    public class When_user_posts_message
    {
        Because of = () => _result = _postingCommand.Execute(_action, _users);

        It returns_empty_result = () => _result.ShouldBeEmpty();

        It includes_post_in_users_timeline = () => _user.Timeline.Any(post => post.Message == "That was good fun").ShouldBeTrue();

        Establish context = () =>
        {
            _action = "Juan -> That was good fun";
            _user = new User("Juan");
            _users = new List<User> {_user};
            _postingCommand = new PostingCommand();
        };

        static ICommand _postingCommand;
        static string _action;
        static IList<string> _result;
        static User _user;
        static IEnumerable<User> _users;
    }
}