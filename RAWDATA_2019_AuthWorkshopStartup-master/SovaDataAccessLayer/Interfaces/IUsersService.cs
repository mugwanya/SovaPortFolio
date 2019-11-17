using SovaDataAccessLayer.FrameworkTables;
using SovaDataAccessLayer.QATables;
using System;
using System.Collections.Generic;
using System.Text;

namespace SovaDataAccessLayer.Interfaces
{
    public interface IUsersService
    {
        int numOfPages();
        void CreateUser(FrameworkTables.User user);
        List<FrameworkTables.User> GetUsers(PagingAttributes pagingAttributes);
        List<FrameworkTables.User> Read(string username);
        bool UserExcist(int userId);
        FrameworkTables.User GetUser(int userId);
        void UpdateUser(FrameworkTables.User user);
        bool DeleteUser(int userId);
    }
}
