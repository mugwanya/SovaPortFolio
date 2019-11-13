using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SovaDataAccessLayer
{
  public class SovaDataService : /*IDatabaseServiceWI , */IQADatabaseService
    {
        // Gets All Comments
        public List<Comment> GetComments()
        {
            SovaContext db = new SovaContext();

            var s = db.Comments.ToList();

            return s;
        }

        // Gets All Posts
        public List<Post> GetPosts()
        {
            SovaContext db = new SovaContext();

            var s = db.Posts.ToList();

            return s;
        }

        // Gets All GetUsers

        public List<User> GetUsers()
        {
            SovaContext db = new SovaContext();

            var s = db.Users.ToList();

            return s;
        }

        /*// Gets All Words (TEST)
        public List<Wi> GetWords()
        {
            SovaContext db = new SovaContext();

            var s = db.Wis.ToList();

            return s;

        }*/

        // Gets All LinkPosts
        public List<LinkPost> GetLinkPostId()
        {
            SovaContext db = new SovaContext();

            var s = db.LinkPosts.ToList();

            return s;
        }
    }
}
