using System;
using System.Collections.Generic;
using System.Text;

namespace SovaDataAccessLayer.FrameworkTables
{
    public class Notes
    {
        public int Id { get; set; }
        public int? Markingid { get; set; }
        public int Userid { get; set; }
        public string Note { get; set; }
    }
}
