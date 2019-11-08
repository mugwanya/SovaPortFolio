using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SovaDataAccessLayer
{
  public class SovaDataService : IDatabaseServiceUsers
    {
        // Gets All GetUsers

        public List<User> GetUsers()
        {
             var db = new SovaContext();

            var s = db.Users.ToList();

            return s;

        }
    }
}
