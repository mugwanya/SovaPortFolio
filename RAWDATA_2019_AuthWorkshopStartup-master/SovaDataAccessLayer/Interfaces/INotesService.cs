using SovaDataAccessLayer.FrameworkTables;
using System;
using System.Collections.Generic;
using System.Text;

namespace SovaDataAccessLayer.Interfaces
{
    interface INotesService
    {
        Note Create(Note note);
        List<Note> ReadAll(int userid);
        List<Note> Read(int userid, int markingid);
        List<Note> Read(int userid, string query);
        List<Note> Read(int id);
        Note Update(int id);
        bool Delete(int id);
    }
}
