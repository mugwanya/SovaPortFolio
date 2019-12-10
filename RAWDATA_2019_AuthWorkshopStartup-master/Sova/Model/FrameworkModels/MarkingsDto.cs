using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SovaWebAppicaltion.Model
{
    public class MarkingsDto
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int PostCommentsId { get; set; }
        public string PostUrl { get; set; }
        public string Link { get; set; }

    }
}
