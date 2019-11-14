using System;
using System.Collections.Generic;
using System.Text;

namespace SovaDataAccessLayer.FrameworkTables
{
    public class Note
    {
        public int id { get; set; }
        public int markingid { get; set; }
        public int userid { get; set; }
        public string note { get; set; }
    }
}
