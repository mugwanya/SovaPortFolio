using SovaDataAccessLayer.FrameworkTables;
using SovaDataAccessLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SovaDataAccessLayer
{
    public class UserService : IUsersService
    {
        
        public void CreateUser(FrameworkTables.User user)
        {
            SovaContext db = new SovaContext();
            user.id = db.FrameworkUsers.Max(x => x.id) + 1;
            db.Add(user);
            db.SaveChanges();
        }

        public bool DeleteUser(int userId)
        {
            SovaContext db = new SovaContext();
            var user = db.FrameworkUsers.Find(userId);
            if (user == null) return false;
            db.Remove(user);
            db.SaveChanges();
            return true;
        }

        public FrameworkTables.User GetUser(int userId)
        {
            SovaContext db = new SovaContext();
            return db.FrameworkUsers.Find(userId);
        }

        public List<FrameworkTables.User> GetUsers()
        {
            SovaContext db = new SovaContext();
            return db.FrameworkUsers.ToList();
        }

        public List<FrameworkTables.User> Read(string username)
        {
            throw new NotImplementedException();
        }

        public void UpdateUser(FrameworkTables.User user)
        {
            SovaContext db = new SovaContext();
            db.Update(user);
            db.SaveChanges();
        }

        public bool UserExcist(int userId)
        {
            throw new NotImplementedException();
        }
    }
}
