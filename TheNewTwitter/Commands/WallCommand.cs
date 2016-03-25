using System.Collections.Generic;
using System.Linq;

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
            var executingUser = users.Get(ExtractUser(action));
            var followingUsersWall = GetFollowingUsersWall(executingUser, users);

            return executingUser
                .Timeline
                .Concat(followingUsersWall)
                .OrderByDescending(post => post.PublishedTime)
                .Select(post => post.ToWallFormat())
                .ToList();
        }

        string ExtractUser(string action)
        {
            return action.Split(CommandSeparator).First();
        }

        IList<Post> GetFollowingUsersWall(User executingUser, IUsers users)
        {
            return users.All()
                .Where(user => executingUser.Following.Contains(user.Name))
                .SelectMany(followingUser => followingUser.Timeline)
                .ToList();
        }
    }
}