using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SovaDataAccessLayer
{
   public interface IQADatabaseService
    {

        public List<Comment> GetComments();
       
    }
}
