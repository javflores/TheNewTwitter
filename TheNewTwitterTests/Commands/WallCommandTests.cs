using System;
using System.Collections.Generic;
using System.Linq;
using Machine.Specifications;
using Rhino.Mocks;
using TheNewTwitter;
using TheNewTwitter.Commands;

namespace TheNewTwitterTests.Commands
{
    [Subject("WallCommand")]
    public class When_checking_if_wall_command_can_be_executed
    {
        public class with_user_action_containing_wall_keyword
        {
            Because of = () => _canExecute = _wallCommand.CanExecute(_action);

            It can_execute_wall_command = () => _canExecute.ShouldBeTrue();

            Establish context = () =>
            {
                _action = "Juan wall";
            };
        }


        public class with_user_action_not_containing_wall_keyword
        {
            Because of = () => _canExecute = _wallCommand.CanExecute(_action);

            It can_not_execute_wall_command = () => _canExecute.ShouldBeFalse();

            Establish context = () =>
            {
                _action = "Juan";
            };
        }

        Establish context = () =>
        {
            _wallCommand = new WallCommand();
        };

        static ICommand _wallCommand;
        static string _action;
        static bool _canExecute;
    }

    [Subject("WallCommand")]
    public class When_executing_wall_command_for_a_given_user
    {
        Because of = () => _wall = _wallCommand.Execute("Juan wall", _users);

        It returns_all_posts_for_that_user = () => _wall.ShouldContain("Juan - Today");

        It shows_latest_published_post_first = () => _wall.First().ShouldEqual("Juan - Tomorrow");

        It returns_all_posts_for_following_user = () => _wall.ShouldContain("Sandro - Wicked");

        Establish context = () =>
        {
            var timer = MockRepository.GenerateMock<ITimerWatch>();

            var followingUserPost = MockRepository.GenerateMock<Post>("Sandro", "Wicked", timer);
            followingUserPost.Stub(p => p.ToWallFormat()).Return("Sandro - Wicked");
            var followingUserTimeLine = new List<Post> { followingUserPost };
            var followingUser = new User("Sandro") { Timeline = followingUserTimeLine };

            var firstUserPost = MockRepository.GenerateMock<Post>("Juan", "Today", timer);
            firstUserPost.Stub(p => p.ToWallFormat()).Return("Juan - Today");
            firstUserPost.Stub(p => p.PublishedTime).Return(DateTime.Now.AddMinutes(-5));

            var secondUserPost = MockRepository.GenerateMock<Post>("Juan", "Today", timer);
            secondUserPost.Stub(p => p.ToWallFormat()).Return("Juan - Tomorrow");
            secondUserPost.Stub(p => p.PublishedTime).Return(DateTime.Now.AddMinutes(-2));

            var userPosts = new List<Post> { firstUserPost, secondUserPost };
            var user = new User("Juan") {Timeline = userPosts, Following = new[] {followingUser.Name}};

            _users = MockRepository.GenerateMock<IUsers>();
            _users.Stub(u => u.Get(followingUser.Name)).Return(followingUser);
            _users.Stub(u => u.Get(user.Name)).Return(user);
            _users.Stub(u => u.All()).Return(new List<User> { user, followingUser });

            _wallCommand = new WallCommand();
        };

        static IList<string> _wall;
        static IUsers _users;
        static ICommand _wallCommand;
    }
}