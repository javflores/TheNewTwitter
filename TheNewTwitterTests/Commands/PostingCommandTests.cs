using System.Collections.Generic;
using System.Linq;
using Machine.Specifications;
using Rhino.Mocks;
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

            Establish context = () => _action = "Juan -> That was good fun";
        }

        public class with_user_action_not_containing_arrow
        {
            Because of = () => _canExecute = _postingCommand.CanExecute(_action);

            It can_not_execute_posting_command = () => _canExecute.ShouldBeFalse();

            Establish context = () => _action = "Juan";
        }

        Establish context = () => _postingCommand = new PostingCommand();

        static ICommand _postingCommand;
        static string _action;
        static bool _canExecute;
    }

    [Subject("PostingCommand")]
    public class When_user_posts_message
    {
        Because of = () => _result = _postingCommand.Execute(_action, _users);

        It tells_to_add_user = () => _users.AssertWasCalled(users => users.Add(_userName));

        It includes_post_in_users_timeline = () => _user.Timeline.ShouldContain(post => post.Message == _message);

        It returns_empty_result = () => _result.ShouldBeEmpty();

        Establish context = () =>
        {
            _userName = "Juan";
            _message = "That was good fun";
            _action = $"{_userName} -> {_message}";
            
            _user = new User(_userName);
            _users = MockRepository.GenerateMock<IUsers>();
            _users.Stub(u => u.Add(_userName));
            _users.Stub(u => u.Get(_userName)).Return(_user);

            _postingCommand = new PostingCommand();
        };

        static ICommand _postingCommand;
        static string _action;
        static IList<string> _result;
        static User _user;
        static IUsers _users;
        static string _userName;
        static string _message;
    }
}