using SovaDataAccessLayer.FrameworkTables;
using SovaDataAccessLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SovaDataAccessLayer.DataServices
{
    class NoteService : INotesService
    {
        public void Create(Note note)
        {
            SovaContext db = new SovaContext();
            note.id = db.Notes.Max(x => x.id) + 1;
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

        public List<Note> Read(int userId, int markingId)
        {
            SovaContext db = new SovaContext();
            return db.Notes
                .Where(x => x.userid == userId)
                .Where(x => x.markingid == markingId)
                .Select(x => x).ToList();
        }

        public Note Read(int noteId)
        {
            SovaContext db = new SovaContext();
            return db.Notes.Find(noteId);
        }

        public List<Note> ReadAll(int userid)
        {
            SovaContext db = new SovaContext();
            return db.Notes
                .Where(x => x.userid == userid).ToList();
        }

        public void Update(Note updateNote)
        {
            SovaContext db = new SovaContext();
            db.Update(updateNote);
            db.SaveChanges();
        }
    }
}
