using SovaDataAccessLayer.FrameworkTables;
using System;
using System.Collections.Generic;
using System.Text;

namespace SovaDataAccessLayer.Interfaces
{
    interface IUsersService
    {
        void CreateUser(FrameworkTables.User user);
        List<FrameworkTables.User> GetUsers();
        List<FrameworkTables.User> Read(string username);
        bool UserExcist(int userId);
        FrameworkTables.User GetUser(int userId);
        void UpdateUser(FrameworkTables.User user);
        bool DeleteUser(int userId);
    }
}
