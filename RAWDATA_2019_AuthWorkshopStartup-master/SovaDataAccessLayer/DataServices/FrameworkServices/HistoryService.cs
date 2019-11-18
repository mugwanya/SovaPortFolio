using SovaDataAccessLayer.FrameworkTables;
using SovaDataAccessLayer.Interfaces;
using SovaDataAccessLayer.QATables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SovaDataAccessLayer.DataServices
{
    public class HistoryService : IHistoryService
    {
        public bool Delete(int userId, DateTime timestamp)
        {
            SovaContext db = new SovaContext();
            try
            {
                db.Histories.Remove(Read(userId,timestamp)[0]);
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

            return db.Histories.Where(x => x.timestamped > from && x.timestamped < to).Select(x => x).ToList();
        }

        public List<History> ReadAll(int userId, PagingAttributes pagingAttributes)
        {
            SovaContext db = new SovaContext();

            return db.Histories.Skip(pagingAttributes.Page * pagingAttributes.PageSize).Take(pagingAttributes.PageSize).Where(x => x.userid == userId).ToList();

            //return db.Histories.Where(x => x.userid == userId).Select(x => x).ToList();
        }

        public int NumberofHistory(int userId)
        {
            SovaContext db = new SovaContext();

            return db.Histories.Count();
        }

        public List<History> Read(int userId, DateTime timestamp)
        {
            SovaContext db = new SovaContext();

            return db.Histories.Where(x => x.userid == userId && x.timestamped == timestamp).Select(x => x).ToList();
        }
    }
}
