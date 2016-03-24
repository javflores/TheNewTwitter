using System.Collections.Generic;
using System.Linq;
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

        public IList<string> Execute(string action, IEnumerable<User> users)
        {
            var executingUser = users.Single(user => user.Name == ExtractUser(action));
            var followingUsersWall = GetFollowingUsersWall(executingUser, users);

            return executingUser
                .Timeline
                .Concat(followingUsersWall)
                .Select(post => post.ToUserFormat())
                .ToList();
        }

        string ExtractUser(string action)
        {
            return action.Split(CommandSeparator).First();
        }

        IList<Post> GetFollowingUsersWall(User executingUser, IEnumerable<User> users)
        {
            return users.Where(user => executingUser.Following.Contains(user.Name))
                .SelectMany(followingUser => followingUser.Timeline)
                .ToList();
        }
    }
}