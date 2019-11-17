using SovaDataAccessLayer.QATables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SovaDataAccessLayer
{
   public interface IQADatabaseService
    {
        ///////////////////////
        ///Comments
        ///
        IList<Comment> GetComments(PagingAttributes pagingAttributes);
        Comment GetComment(int commentId);
        void CreateComment(Comment comment);
        bool CommentExcist(int commentId);
        void UpdateComment(Comment comment);
        bool DeleteComment(int commentId);

        ///////////////////////

        // Posts 
        IList<Post> GetPosts(PagingAttributes pagingAttributes);
        Post GetPost(int postId);
        void CreatePost(Post post);
        bool PostExcist(int postId);
        void UpdatePost(Post post);
        bool DeletePost(int postId);

        // Users 
        //       
        IList<User> GetUsers(PagingAttributes pagingAttributes);

        User GetUser(int userId);

        ///////////////////////

        // LinkPosts 

        /////////////////////// 

        List<LinkPost> GetLinkPostId();

        // Gets Number Of Comments 

        /////////////////////// 

        int NumberOfComments();

        int NumberOfPosts();
    }
}
