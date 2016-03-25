using System.Collections.Generic;

namespace TheNewTwitter
{
    public interface IUsers
    {
        User Get(string userName);
        void Add(string userName);
        IEnumerable<User> All();
    }

    public class Users : IUsers
    {
        List<User> _users;

        public Users()
        {
            _users = new List<User>();
        }

        public User Get(string userName)
        {
            return _users.Find(user => user.Name == userName);
        }

        public void Add(string userName)
        {
            if (Get(userName) == null)
            {
                _users.Add(new User(userName));
            }
        }

        public IEnumerable<User> All()
        {
            return _users;
        }
    }
}