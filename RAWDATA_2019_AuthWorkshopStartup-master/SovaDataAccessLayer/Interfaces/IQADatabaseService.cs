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

    }
}
