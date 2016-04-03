using System.Collections.Generic;
using System.Linq;
using TheNewTwitter.Posts;
using TheNewTwitter.Users;

namespace TheNewTwitter.Commands
{
    public class WallCommand : ICommand
    {
        const string WallCommandKeyword = "wall";
        const char CommandSeparator = ' ';

        public bool CanExecute(string action)
        {
            return action.Contains(WallCommandKeyword);
        }

        public IList<string> Execute(string action, IUsers users)
        {
            var executingUser = users.Get(UserName(action));
            var followingUsersTimelines = GetFollowingUsersTimelines(executingUser, users);

            return executingUser
                .Timeline
                .Concat(followingUsersTimelines)
                .OrderByDescending(post => post.PublishedTime)
                .Select(post => post.ToWallFormat())
                .ToList();
        }

        string UserName(string action)
        {
            return action.Split(CommandSeparator).First();
        }

        IList<Post> GetFollowingUsersTimelines(User executingUser, IUsers users)
        {
            var followingUsers = users
                .All()
                .Where(user => executingUser.Following.Contains(user.Name));

            return followingUsers
                .SelectMany(followingUser => followingUser.Timeline)
                .ToList();
        }
    }
}