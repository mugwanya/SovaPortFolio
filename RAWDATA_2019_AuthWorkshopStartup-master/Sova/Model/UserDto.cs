using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SovaWebAppicaltion.Model
{
    // UserDto
    public class UserDto
    {

        public string DisplayName { get; set; }

        public DateTime CreationDate { get; set; }

        public string Location { get; set; }

        public int? Age { get; set; }

        public string Link { get; set; }
    }
}
