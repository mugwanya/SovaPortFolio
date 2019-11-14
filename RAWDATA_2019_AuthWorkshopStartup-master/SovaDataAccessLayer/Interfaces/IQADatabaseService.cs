using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SovaDataAccessLayer
{
   public interface IQADatabaseService
    {
        ///////////////////////
        // 
        // Comments 
        // 
        /////////////////////// 
        List<Comment> GetComments();
        Comment GetComment(int commentId);
        void CreateComment(Comment comment);
        bool CommentExcist(int commentId);
        void UpdateComment(Comment comment);
        bool DeleteComment(int commentId);

        ///////////////////////
        // 
        // Posts 
        // 
        /////////////////////// 
        List<Post>GetPosts();
        Post GetPost(int postId);
        void CreatePost(Post post);
        bool PostExcist(int postId);
        void UpdatePost(Post post);
        bool DeletePost(int postId);


        ///////////////////////
        // 
        // Users 
        // 
        /////////////////////// 
        List<User> GetUsers();
        User GetUser(int userId);

        ///////////////////////
        // 
        // LinkPosts 
        // 
        /////////////////////// 
        List<LinkPost> GetLinkPostId();
    }
}
