using SovaDataAccessLayer.FrameworkTables;
using System;
using System.Collections.Generic;
using System.Text;

namespace SovaDataAccessLayer.Interfaces
{
    interface INotesService
    {
        void Create(Note note);
        List<Note> ReadAll(int userid);
        List<Note> Read(int userId, int markingId);
        //List<Note> Read(int userid, string query);
        Note Read(int noteId);
        void Update(Note updateNote);
        bool Delete(int noteId);
    }
}
