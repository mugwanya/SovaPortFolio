using SovaDataAccessLayer.FrameworkTables;
using SovaDataAccessLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace SovaDataAccessLayer.DataServices
{
    class HistoryService : IHistoryService
    {
        public bool Create(History search)
        {
            throw new NotImplementedException();
        }

        public bool Delete(int userId, DateTime timestamp)
        {
            throw new NotImplementedException();
        }

        public List<History> Read(int userId)
        {
            throw new NotImplementedException();
        }

        public List<History> Read(int userId, DateTime from, DateTime to)
        {
            throw new NotImplementedException();
        }
    }
}
