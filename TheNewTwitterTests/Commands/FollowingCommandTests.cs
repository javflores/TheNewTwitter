using System.Collections.Generic;
using Machine.Specifications;
using Rhino.Mocks;
using TheNewTwitter;
using TheNewTwitter.Commands;

namespace TheNewTwitterTests.Commands
{
    [Subject("FollowingCommand")]
    public class When_checking_if_following_command_can_be_executed
    {
        public class with_user_action_containing_follows_keyword
        {
            Because of = () => _canExecute = _followingCommand.CanExecute(_action);

            It can_execute_following_command = () => _canExecute.ShouldBeTrue();

            Establish context = () =>
            {
                _action = "Juan follows Sandro";
            };
        }

        public class with_user_action_not_containing_follows_keyword
        {
            Because of = () => _canExecute = _followingCommand.CanExecute(_action);

            It can_not_execute_following_command = () => _canExecute.ShouldBeFalse();

            Establish context = () =>
            {
                _action = "Juan";
            };
        }

        Establish context = () =>
        {
            _followingCommand = new FollowingCommand();
        };

        static ICommand _followingCommand;
        static string _action;
        static bool _canExecute;
    }

    [Subject("FollowingCommand")]
    public class When_user_wants_to_follow_other_user
    {
        Because of = () => _result = _followingCommand.Execute("Juan follows Sandro", _allUsers);

        It returns_empty_result = () => _result.ShouldBeEmpty();

        It includes_other_user_in_users_following_list = () => _user.Following.ShouldContain("Sandro");

        Establish context = () =>
        {
            _user = new User("Juan");
            var otherUser = new User("Sandro");
            _allUsers = MockRepository.GenerateMock<IUsers>();
            _allUsers.Stub(users => users.Get("Sandro")).Return(otherUser);
            _allUsers.Stub(users => users.Get("Juan")).Return(_user);

            _followingCommand = new FollowingCommand();
        };

        static User _user;
        static ICommand _followingCommand;
        static IUsers _allUsers;
        static IList<string> _result;
    }
}