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
        bool Delete(History entry);
        int NumberofHistory(int userId);
    }
}
