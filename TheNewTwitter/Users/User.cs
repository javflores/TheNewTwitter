using System.Collections.Generic;

namespace TheNewTwitter.Users
{
    public class User
    {
        public string Name { get; }
        public IList<Post> Wall { get; set; }
        public IList<string> Following { get; set; }

        public User(string name)
        {
            Name = name;
            Wall = new List<Post>();
            Following = new List<string>();
        }
    }
}