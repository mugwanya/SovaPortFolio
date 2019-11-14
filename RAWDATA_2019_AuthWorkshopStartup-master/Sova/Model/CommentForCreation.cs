using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SovaWebAppicaltion.Model
{
    public class CommentForCreation
    {
        public int Id { get; set; }

        public int PostId { get; set; }

        public int Score { get; set; }

        public string Text { get; set; }

        public DateTime CreateDate { get; set; }

        public int UserId { get; set; }

        public string Link { get; set; }
    }
}
