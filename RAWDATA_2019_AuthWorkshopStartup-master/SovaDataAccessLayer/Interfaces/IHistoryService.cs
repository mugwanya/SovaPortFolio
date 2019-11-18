using SovaDataAccessLayer.FrameworkTables;
using SovaDataAccessLayer.QATables;
using System;
using System.Collections.Generic;
using System.Text;

namespace SovaDataAccessLayer.Interfaces
{
    public interface IHistoryService
    {
        List<History> ReadAll(int userId, PagingAttributes pagingAttributes);
        List<History> Read(int userId, DateTime from, DateTime to);
        List<History> Read(int userId, DateTime timestamp);
        bool Delete(int userId, DateTime timestamp);
        int NumberofHistory(int userId);
    }
}
