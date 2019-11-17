using SovaDataAccessLayer.FrameworkTables;
using SovaDataAccessLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SovaDataAccessLayer.DataServices
{
    public class markingsService : IMarkingsService
    {
        public void CreateMarking(Marking marking)
        {
            SovaContext db = new SovaContext();
            marking.Id = db.Markings.Max(x => x.Id) + 1;
            db.Add(marking);
            db.SaveChanges();
        }

        public bool DeleteMarking(int markingId)
        {
            SovaContext db = new SovaContext();
            var marking = db.Markings.Find(markingId);
            if (marking == null) return false;
            db.Remove(marking);
            db.SaveChanges();
            return true;
        }

        public Marking GetMarking(int markingId)
        {
            SovaContext db = new SovaContext();
            return db.Markings.Find(markingId);
        }

        public List<Marking> GetMarkins(int userid)
        {
            SovaContext db = new SovaContext();
            return db.Markings.ToList();
        }

        public bool MarkingsExcist(int markingId)
        {
            return GetMarking(markingId) != null;
        }

        public List<Marking> Read(int userid, int postcommentsid)
        {
            throw new NotImplementedException();
        }

        public void UpdateMarking(int markingId)
        {
            SovaContext db = new SovaContext();
            db.Update(markingId);
            db.SaveChanges();
        }
    }
}
