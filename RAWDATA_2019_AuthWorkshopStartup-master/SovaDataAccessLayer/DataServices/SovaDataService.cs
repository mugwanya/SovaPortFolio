using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SovaDataAccessLayer
{
  public class SovaDataService : /*IDatabaseServiceWI , */IQADatabaseService
    {
        ///////////////////////
        // 
        // Comments 
        // create, read, update, delete 
        /////////////////////// 

        // Gets All Comments
        public List<Comment> GetComments()
        {
            SovaContext db = new SovaContext();
            return db.Comments.ToList();
        }

        public Comment GetComment(int commentId)
        {
            SovaContext db = new SovaContext();
            return db.Comments.Find(commentId);
        }

        public void CreateComment (Comment comment)
        {
            SovaContext db = new SovaContext();
            comment.Id = db.Comments.Max(x => x.Id) + 1;
            db.Add(comment);
        }

        ///////////////////////
        // 
        // Posts 
        // 
        /////////////////////// 

        // Gets All Posts
        public List<Post> GetPosts()
        {
            SovaContext db = new SovaContext();

            var s = db.Posts.ToList();

            return s;
        }

        //Get a post by Id
        public User GetUser(int userId)
        {
            SovaContext db = new SovaContext();
            return db.Users.Find(userId);
        }

        ///////////////////////
        // 
        // Users 
        // 
        /////////////////////// 

        // Gets All GetUsers
        public List<User> GetUsers()
        {
            SovaContext db = new SovaContext();

            var s = db.Users.ToList();

            return s;
        }

        ///////////////////////
        // 
        // Linkpost 
        // 
        /////////////////////// 

        // Gets All LinkPosts
        public List<LinkPost> GetLinkPostId()
        {
            SovaContext db = new SovaContext();

            var s = db.LinkPosts.ToList();

            return s;
        }










        /*// Gets All Words (TEST)
        public List<Wi> GetWords()
        {
            SovaContext db = new SovaContext();

            var s = db.Wis.ToList();

            return s;

        }*/
    }
}
