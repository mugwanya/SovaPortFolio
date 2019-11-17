using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SovaWebAppicaltion.Profiles
{
    public class NoteDto
    {
        public int MarkingsId { get; set; }
        public int UserId { get; set; }
        public string Note { get; set; }
        public string Link { get; set; }
    }
}
