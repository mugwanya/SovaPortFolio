using SovaDataAccessLayer.QATables;
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
        public IList<Comment> GetComments(PagingAttributes pagingAttributes)
        {
            SovaContext db = new SovaContext();
            return db.Comments.Skip(pagingAttributes.Page * pagingAttributes.PageSize)
                .Take(pagingAttributes.PageSize)
                .ToList();
            
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
            comment.CreateDate = DateTime.Now;
            db.Add(comment);
            db.SaveChanges();
        }

        public bool CommentExcist(int commentId)
        {
            return GetComment(commentId) != null;
        }

        public void UpdateComment (Comment comment)
        {
            SovaContext db = new SovaContext();
            db.Comments.Update(comment);
            db.SaveChanges();
        }

        public bool DeleteComment (int commentId)
        {
            SovaContext db = new SovaContext();
            var comment = db.Comments.Find(commentId);
            if (comment == null) return false;
            db.Remove(comment);
            db.SaveChanges();
            return true;
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

        public int NumberOfComments()
        {
            var db = new SovaContext();
            return db.Comments.Count();
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
