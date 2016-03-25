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
        public User Get(string userName)
        {
            throw new System.NotImplementedException();
        }

        public void Add(string userName)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<User> All()
        {
            throw new System.NotImplementedException();
        }
    }
}