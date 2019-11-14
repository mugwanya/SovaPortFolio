using SovaDataAccessLayer.FrameworkTables;
using System;
using System.Collections.Generic;
using System.Text;

namespace SovaDataAccessLayer.Interfaces
{
    interface IUsersService
    {
        User Create(User user);
        List<FrameworkTables.User> ReadAll();
        List<FrameworkTables.User> Read(string username);
        List<FrameworkTables.User> Read(int id);
        User Update(int id);
        bool Delete(int id);
    }
}
