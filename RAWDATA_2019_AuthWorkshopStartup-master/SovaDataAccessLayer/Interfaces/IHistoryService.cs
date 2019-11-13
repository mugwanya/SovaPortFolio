using SovaDataAccessLayer.FrameworkTables;
using System;
using System.Collections.Generic;
using System.Text;

namespace SovaDataAccessLayer.Interfaces
{
    interface IHistoryService
    {
        //bool Create(History search);
        List<History> ReadAll(int userId);
        List<History> Read(int userId, DateTime from, DateTime to);
        bool Delete(int userId, DateTime timestamp);
    }
}
