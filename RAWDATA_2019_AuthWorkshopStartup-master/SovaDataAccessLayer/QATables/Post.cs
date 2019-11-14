using NpgsqlTypes;
using System;
using System.Collections.Generic;
using System.Text;

namespace SovaDataAccessLayer
{
    // Post Class
    public class Post
    {
        public int Id { get; set; }
        public int? ParentId { get; set; }
        public int PostTypeId { get; set; }
        
        public int? AcceptedAnswersId { get; set; }

        public DateTime CreationDate { get; set; }

        public int? Score { get; set; }

        public string Body { get; set; }

        public DateTime? CloseDate { get; set; }

        public string Title { get; set; }

        public string Tags { get; set; }

        public int UserId { get; set; }
    }
}
