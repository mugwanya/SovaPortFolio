using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SovaDataAccessLayer
{
   public interface IQADatabaseService
    {
        List<Comment> GetComments();

        List<User> GetUsers();

        List<Post>GetPosts();

        List<LinkPost> GetLinkPostId();

        User GetUser(int userId);
        Comment GetComment(int commentId);
        void CreateComment(Comment comment);
        bool CommentExcist(int commentId);
        void UpdateComment(Comment comment);
        bool DeleteComment(int commentId);
    }
}
