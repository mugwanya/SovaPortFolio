using SovaDataAccessLayer.FrameworkTables;
using SovaDataAccessLayer.Interfaces;
using SovaDataAccessLayer.QATables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SovaDataAccessLayer.DataServices
{
    public class markingsService : IMarkingsService
    {
        public int numOfPages()
        {
            SovaContext db = new SovaContext();
            return db.Markings.Count();
        }
        public void CreateMarking(Marking marking)
        {
            SovaContext db = new SovaContext();
            var tmpList = db.Markings.ToList();
            if (tmpList.Count == 0)
            {
                marking.Id = 1;
            } else
            {
                marking.Id = db.Markings.Max(x => x.Id) + 1;
            }
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

        public List<Marking> GetMarkings(int userid, PagingAttributes pagingAttributes)
        {
            SovaContext db = new SovaContext();
            return db.Markings
                .Where(x => x.UserId == userid)
                .Skip(pagingAttributes.Page * pagingAttributes.PageSize)
                .Take(pagingAttributes.PageSize).ToList();
        }

        public bool MarkingsExcist(int markingId)
        {
            return GetMarking(markingId) != null;
        }

        public List<Marking> Read(int userid, int postcommentsid)
        {
            throw new NotImplementedException();
        }

        public void UpdateMarking(Marking marking)
        {
            SovaContext db = new SovaContext();
            db.Update(marking);
            db.SaveChanges();
        }

        public List<Marking> GetAllMarkings(PagingAttributes pagingAttributes)
        {
            SovaContext db = new SovaContext();
            return db.Markings
                .Skip(pagingAttributes.Page * pagingAttributes.PageSize)
                .Take(pagingAttributes.PageSize).ToList();
        }
    }
}
