using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SovaDataAccessLayer
{
  public class SovaDataService : IDatabaseServiceWI , IQADatabaseService
    {
        public List<Comment> GetComments()
        {
            SovaContext db = new SovaContext();

            var s = db.Comments.ToList();

            return s;
        }

        // Gets All GetUsers

        public List<Wi> GetWords()
        {
            SovaContext db = new SovaContext();

            var s = db.Wis.ToList();

            return s;

        }




     
    }
}
