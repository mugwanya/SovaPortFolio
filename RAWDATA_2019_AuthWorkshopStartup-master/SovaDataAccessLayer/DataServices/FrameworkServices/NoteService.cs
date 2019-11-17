using SovaDataAccessLayer.FrameworkTables;
using SovaDataAccessLayer.Interfaces;
using SovaDataAccessLayer.QATables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SovaDataAccessLayer.DataServices
{
    public class NoteService : INotesService
    {
        public bool NoteExcists (int noteId)
        {
            return Read(noteId) != null;
        }
        public List<Notes> ReadAllNotes()
        {
            SovaContext db = new SovaContext();
            return db.Notes.ToList();
        }
        public void Create(Notes note)
        {
            SovaContext db = new SovaContext();
            var tmp = db.Notes.ToList();
            if (tmp.Count == 0)
            {
                note.Id = 1;
            } else
            {
                note.Id = db.Notes.Max(x => x.Id) + 1;
            }
            db.Add(note);
            db.SaveChanges();
        }

        public bool Delete(int noteId)
        {
            SovaContext db = new SovaContext();
            var note = db.Notes.Find(noteId);
            if (note == null) return false;
            db.Remove(note);
            db.SaveChanges();
            return true;
        }

        public List<Notes> Read(int userId, int markingId)
        {
            SovaContext db = new SovaContext();
            return db.Notes
                .Where(x => x.Userid == userId)
                .Where(x => x.Markingid == markingId)
                .Select(x => x).ToList();
        }

        public Notes Read(int noteId)
        {
            SovaContext db = new SovaContext();
            return db.Notes.Find(noteId);
        }

        public List<Notes> ReadAll(int userid, PagingAttributes pagingAttributes)
        {
            SovaContext db = new SovaContext();
            return db.Notes
                .Where(x => x.Userid == userid)
                .Skip(pagingAttributes.Page * pagingAttributes.PageSize)
                .Take(pagingAttributes.PageSize).ToList();
        }

        public void Update(Notes updateNote)
        {
            SovaContext db = new SovaContext();
            db.Update(updateNote);
            db.SaveChanges();
        }

        public List<Notes> ReadAllNotes(PagingAttributes pagingAttributes)
        {
            SovaContext db = new SovaContext();
            return db.Notes
                .Skip(pagingAttributes.Page * pagingAttributes.PageSize)
                .Take(pagingAttributes.PageSize).ToList();
        }

        public int numOfPages()
        {
            SovaContext db = new SovaContext();
            return db.Notes.Count();
        }
    }
}
