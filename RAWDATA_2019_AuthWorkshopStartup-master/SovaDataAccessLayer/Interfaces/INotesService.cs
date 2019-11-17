using SovaDataAccessLayer.FrameworkTables;
using SovaDataAccessLayer.QATables;
using System;
using System.Collections.Generic;
using System.Text;

namespace SovaDataAccessLayer.Interfaces
{
    public interface INotesService
    {
        //List<Notes> ReadAllNotes();
        List<Notes> ReadAllNotes(PagingAttributes pagingAttributes);
        int numOfPages();
        void Create(Notes note);
        List<Notes> ReadAll(int userid, PagingAttributes pagingAttributes);

        // would the markingsId not be unique, making specifying the userId obsolete??
        List<Notes> Read(int userId, int markingId); 

        //List<Note> Read(int userid, string query);
        Notes Read(int noteId);
        void Update(Notes updateNote);
        bool Delete(int noteId);

        bool NoteExcists(int noteId);
    }
}
