using SovaDataAccessLayer.FrameworkTables;
using SovaDataAccessLayer.Interfaces;
using SovaDataAccessLayer.QATables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SovaDataAccessLayer
{
    public class UsersService : IUsersService
    {
        public int numOfPages()
        {
            SovaContext db = new SovaContext();
            return db.FrameworkUsers.Count();
        }
        public void CreateUser(FrameworkTables.User user)
        {
            SovaContext db = new SovaContext();
            var tmpList = db.Users.ToList();
            if (tmpList.Count() == 0)
            {
                user.Id = 1;
            } else
            {
                user.Id = db.FrameworkUsers.Max(x => x.Id) + 1;
            }
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

        public List<FrameworkTables.User> GetUsers(PagingAttributes pagingAttributes)
        {
            SovaContext db = new SovaContext();
            return db.FrameworkUsers
                .Skip(pagingAttributes.Page * pagingAttributes.PageSize)
                .Take(pagingAttributes.PageSize).ToList();
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
            return GetUser(userId) != null;
        }
    }
}
