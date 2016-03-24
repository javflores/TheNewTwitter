using System.Collections.Generic;

namespace TheNewTwitter.Users
{
    public class User
    {
        public string Name { get; }
        public IList<Post> Timeline { get; set; } = new List<Post>();
        public IList<string> Following { get; set; } = new List<string>();

        public User(string name)
        {
            Name = name;
        }
    }
}