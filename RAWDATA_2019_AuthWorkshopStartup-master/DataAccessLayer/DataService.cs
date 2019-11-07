using System;
using System.Collections.Generic;
using System.Linq;

namespace DataAccessLayer
{
    public class DataService : IDataService
    {
        readonly List<User> _users = new List<User>();
        readonly List<Post> _posts = new List<Post>()
        {
            new Post(){ Id = 19, Title = "What is the fastest way to get the value of ¤Ç?"},
            new Post(){ Id = 709, Title = ".NET Testing Framework Advice"},
            new Post(){ Id = 1053, Title = "A little diversion into floating point (im)precision, part 1"},
            new Post(){ Id = 1237, Title = "Regex: To pull out a sub-string between two tags in a string"},
            new Post(){ Id = 1669, Title = "Learning to write a compiler"}
        };

        public DataService()
        {
            _users.Add(new User()
            {
                Id = 1234,
                Username = "henrik.bulskov1"
            });
        }

        public User GetUser(string username)
        {
            return _users.FirstOrDefault(x => x.Username == username);
        }

        public User CreateUser(string name, string username, string password, string salt)
        {
            var user = new User()
            {
                Id = _users.Max(x => x.Id) + 1,
                Name = name,
                Username = username,
                Password = password,
                Salt = salt
            };
            _users.Add(user);
            return user;
        }

        public List<Post> GetPosts(int userId)
        {
            if (_users.FirstOrDefault(x => x.Id == userId) == null)
                throw new ArgumentException("User not found");
            return _posts;
        }

    }
}
