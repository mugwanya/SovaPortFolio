using System;
using System.Collections.Generic;
using System.Text;

namespace SovaDataAccessLayer
{
  public class Comment
    {
        public int Id { get; set; }

        public int PostId { get; set; }

        public int Score { get; set; }

        public string Text { get; set; }

        public DateTime CreateDate { get; set; }

        public int UserId { get; set; }
    }
}
