using SovaDataAccessLayer.FrameworkTables;
using System;
using System.Collections.Generic;
using System.Text;

namespace SovaDataAccessLayer.Interfaces
{
    public interface INotesService
    {
        List<Notes> ReadAllNotes();
        void Create(Notes note);
        List<Notes> ReadAll(int userid);

        // would the markingsId not be unique, making specifying the userId obsolete??
        List<Notes> Read(int userId, int markingId); 

        //List<Note> Read(int userid, string query);
        Notes Read(int noteId);
        void Update(Notes updateNote);
        bool Delete(int noteId);

        bool NoteExcists(int noteId);
    }
}
