using SovaDataAccessLayer.FrameworkTables;
using System;
using System.Collections.Generic;
using System.Text;

namespace SovaDataAccessLayer.Interfaces
{
    interface IMarkingsService
    {
        bool Create(Markings);
        List<Markings> ReadAll(int userid);
        List<Markings> Read(int userid, int)
    }
}
