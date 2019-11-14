using SovaDataAccessLayer.FrameworkTables;
using System;
using System.Collections.Generic;
using System.Text;

namespace SovaDataAccessLayer.Interfaces
{
    interface IHistoryService
    {
        List<History> ReadAll(int userId);
        List<History> Read(int userId, DateTime from, DateTime to);
        List<History> Read(int id);
        bool Delete(History entry);
    }
}
