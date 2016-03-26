using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Machine.Specifications;
using TheNewTwitter;

namespace TheNewTwitterTests
{
    [Subject("Users")]
    public class When_creating_users
    {
        Because of = () => _users = new Users();

        It initializes_with_empty_user_list = () => _users.All().ShouldBeEmpty();

        static IUsers _users;
    }

    [Subject("Users")]
    public class When_adding_non_existing_user
    {
        Because of = () => _users.Add(_userName);

        It add_user_to_user_list = () => _users.All().ShouldContain(user => user.Name == _userName);

        Establish context = () =>
        {
            _userName = "Juan";
            _users = new Users();
        };

        static IUsers _users;
        static string _userName;
    }

    [Subject("Users")]
    public class When_adding_existing_user
    {
        Because of = () => _users.Add(_userName);

        It does_not_add_it_twice = () => _users.All().Count(user => user.Name == _userName).ShouldEqual(1);

        Establish context = () =>
        {
            _userName = "Juan";
            _users = new Users();
            _users.Add(_userName);
        };

        static IUsers _users;
        static string _userName;
    }

    [Subject("Users")]
    public class When_getting_single_user
    {
        Because of = () => _user = _users.Get(_userName);

        It returns_user_by_given_name = () => _user.Name.ShouldEqual(_userName);

        Establish context = () =>
        {
            _userName = "Juan";
            _users = new Users();
            _users.Add(_userName);
        };

        static User _user;
        static IUsers _users;
        static string _userName;
    }
}
