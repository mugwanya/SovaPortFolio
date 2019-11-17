using System;
using System.Collections.Generic;
using System.Text;

namespace SovaDataAccessLayer.QATables
{
   public class CommentDto
    {     
            public int PostId { get; set; }

            public int Score { get; set; }

            public string Text { get; set; }

            public DateTime CreateDate { get; set; }

            public int UserId { get; set; }

            public string Link { get; set; }
        }
    }

