using NpgsqlTypes;
using System;
using System.Collections.Generic;
using System.Text;

namespace SovaDataAccessLayer.FrameworkTables
{
    class History
    {
        public int userid { get; set; }
        public NpgsqlDateTime timestamped { get; set; }
        public string searchquery { get; set; }
    }
}
