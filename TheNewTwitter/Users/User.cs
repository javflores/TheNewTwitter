using System.Collections.Generic;

namespace TheNewTwitter.Users
{
    public class User
    {
        public string Name { get; }
        public IList<Post> Wall { get; set; }

        public User(string name)
        {
            Name = name;
            Wall = new List<Post>();
        }
    }

    public class Post
    {
        public Post(string message)
        {
            Message = message;
        }

        public string Message { get; }
    }
}