using System.Collections.Generic;

namespace DataAccessLayer
{
    public interface IDataService
    {
        User GetUser(string username);
        User CreateUser(string name, string username, string password, string salt);
        List<Post> GetPosts(int userId);
    }
}