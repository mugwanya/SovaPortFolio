using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SovaWebAppicaltion.Model
{
    public class LinkPostDto
    {
        public int PostId { get; set; }
        public int LinkPostId { get; set; }

        public string Link { get; set; }
    }
}
