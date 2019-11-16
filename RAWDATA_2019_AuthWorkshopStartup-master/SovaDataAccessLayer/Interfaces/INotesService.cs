using SovaDataAccessLayer.FrameworkTables;
using System;
using System.Collections.Generic;
using System.Text;

namespace SovaDataAccessLayer.Interfaces
{
    public interface INotesService
    {
        void Create(Notes note);
        List<Notes> ReadAll(int userid);
        List<Notes> Read(int userId, int markingId);
        //List<Note> Read(int userid, string query);
        Notes Read(int noteId);
        void Update(Notes updateNote);
        bool Delete(int noteId);
    }
}
