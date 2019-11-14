using NpgsqlTypes;
using System;
using System.Collections.Generic;
using System.Text;

namespace SovaDataAccessLayer.FrameworkTables
{
    public class History
    {
        public int userid { get; set; }
        public DateTime timestamped { get; set; }
        public string searchquery { get; set; }
    }
}
