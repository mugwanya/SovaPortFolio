using SovaDataAccessLayer.FrameworkTables;
using SovaDataAccessLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SovaDataAccessLayer.DataServices
{
    class HistoryService : IHistoryService
    {
        public bool Delete(History entry)
        {
            SovaContext db = new SovaContext();
            try
            {
                db.Histories.Remove(entry);
                db.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                return false;
            }
        }

        public List<History> Read(int userId, DateTime from, DateTime to)
        {
            SovaContext db = new SovaContext();
            return db.Histories.ToList();
        }

        public List<History> Read(int id)
        {
            throw new NotImplementedException();
        }

        public List<History> ReadAll(int userId)
        {
            throw new NotImplementedException();
        }
    }
}
