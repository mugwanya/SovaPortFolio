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
        // 
        /////////////////////// 

        // Gets All Comments
        public List<Comment> GetComments()
        {
            SovaContext db = new SovaContext();
            return db.Comments.ToList();
        }

        // get comment by id
        public Comment GetComment(int commentId)
        {
            SovaContext db = new SovaContext();
            return db.Comments.Find(commentId);
        }

        //create new comment
        public void CreateComment (Comment comment)
        {
            SovaContext db = new SovaContext();
            comment.Id = db.Comments.Max(x => x.Id) + 1;
            comment.CreateDate = DateTime.Now;
            db.Add(comment);
            db.SaveChanges();
        }

        // check if comment excists
        public bool CommentExcist(int commentId)
        {
            return GetComment(commentId) != null;
        }

        //update comment
        public void UpdateComment (Comment comment)
        {
            SovaContext db = new SovaContext();
            db.Comments.Update(comment);
            db.SaveChanges();
        }

        //delete comment
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
            return db.Posts.ToList();
        }

        //Get a post by Id
        public Post GetPost(int postId)
        {
            SovaContext db = new SovaContext();
            return db.Posts.Find(postId);
        }

        //create new post
        public void CreatePost(Post post)
        {
            SovaContext db = new SovaContext();
            post.Id = db.Posts.Max(x => x.Id) + 1;
            post.CreationDate = DateTime.Now;
            db.Add(post);
            db.SaveChanges();
        }

        // check if post excists
        public bool PostExcist(int postId)
        {
            return GetPost(postId) != null;
        }

        //update post
        public void UpdatePost(Post post)
        {
            SovaContext db = new SovaContext();
            db.Posts.Update(post);
            db.SaveChanges();
        }

        //delete post
        public bool DeletePost(int postId)
        {
            SovaContext db = new SovaContext();
            var post = db.Posts.Find(postId);
            if (post == null) return false;
            db.Remove(post);
            db.SaveChanges();
            return true;
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

        //Get a post by Id
        public User GetUser(int userId)
        {
            SovaContext db = new SovaContext();
            return db.Users.Find(userId);
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
