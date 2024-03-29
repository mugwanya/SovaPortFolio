﻿using SovaDataAccessLayer.QATables;
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
        public IList<Comment> GetComments(PagingAttributes pagingAttributes)
        {
            SovaContext db = new SovaContext();
            return db.Comments.Skip(pagingAttributes.Page * pagingAttributes.PageSize)
                .Take(pagingAttributes.PageSize)
                .ToList();
            
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
       public IList<Post> GetPosts(PagingAttributes pagingAttributes)
        {
            SovaContext db = new SovaContext();
            return db.Posts.Skip(pagingAttributes.Page * pagingAttributes.PageSize)
                .Take(pagingAttributes.PageSize)
                .ToList();
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
        public IList<User> QAGetUsers(PagingAttributes pagingAttributes)
        {
            SovaContext db = new SovaContext();
            return db.Users.Skip(pagingAttributes.Page * pagingAttributes.PageSize)
              .Take(pagingAttributes.PageSize)
              .ToList();
        }

        //Get a post by Id
        public User QAGetUser(int userId)
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

        // Gets Number Of Comments
        public int NumberOfComments()
        {
            var db = new SovaContext();
            return db.Comments.Count();
        }

        // Gets Number Of Posts
        public int NumberOfPosts()
        {
            var db = new SovaContext();
            return db.Posts.Count();
        }

        public int NumberOfUsers()
        {
            var db = new SovaContext();
            return db.Users.Count();
        }

        public int NumberGetLinkPost()
        {
            var db = new SovaContext();
            return db.LinkPosts.Count();
        }

        public IList<LinkPost> GetLinkPostIds(PagingAttributes pagingAttributes)
        {
            SovaContext db = new SovaContext();
            return db.LinkPosts.Skip(pagingAttributes.Page * pagingAttributes.PageSize)
                .Take(pagingAttributes.PageSize)
                .ToList();

        }

        public LinkPost GetLinkPostId(int linkId)
        {
            SovaContext db = new SovaContext();
            return db.LinkPosts.Find(linkId);
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
