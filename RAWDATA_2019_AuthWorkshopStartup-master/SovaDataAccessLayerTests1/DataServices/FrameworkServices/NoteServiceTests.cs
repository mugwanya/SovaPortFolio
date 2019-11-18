using Microsoft.VisualStudio.TestTools.UnitTesting;
using SovaDataAccessLayer.DataServices;
using SovaDataAccessLayer.FrameworkTables;
using SovaDataAccessLayer.QATables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SovaDataAccessLayer.DataServices.Tests
{
    [TestClass()]
    public class NoteServiceTests
    {
        [TestMethod()]
        public void NoteExcistsTest()
        {
            var service = new NoteService();
            var shouldPassTrue = service.NoteExcists(1);
            var shouldPassFalse = service.NoteExcists(0);
            Assert.IsTrue(shouldPassTrue);
            Assert.IsFalse(shouldPassFalse);
        }

        [TestMethod()]
        public void ReadAllNotesTest()
        {
            var service = new NoteService();
            var notes = service.ReadAllNotes();
            Assert.AreEqual(9, notes.Count) ;
        }

        [TestMethod()]
        public void CreateTest()
        {
            var service = new NoteService();
            var testNote = new Notes() 
            { Id = 999, Markingid = 1, Note = "testnote", Userid = 4 };
            service.Create(testNote);
            // specifing an Id when creating a note is not possible. The function need to automaticly
            // deter which id the object should have upon creation.
            Assert.AreNotEqual(999, testNote.Id);
            Assert.AreEqual(testNote.Id, service.ReadAllNotes().Last().Id);
            // cleanup
            service.Delete(testNote.Id);
        }

        [TestMethod()]
        public void DeleteTest()
        {
            var service = new NoteService();
            var testNote = new Notes()
            { Id = 999, Markingid = 1, Note = "testnote", Userid = 4 };
            
            service.Create(testNote);
            Assert.IsTrue(service.NoteExcists(testNote.Id));

            service.Delete(testNote.Id);
            Assert.IsFalse(service.NoteExcists(testNote.Id));
        }

        [TestMethod()]
        public void ReadTest()
        {
            var service = new NoteService();
            var expected = service.ReadAllNotes()
                .Select(x => x.Id).Min();
            Assert.AreEqual(expected, service.Read(1).Id);
        }

        [TestMethod()]
        public void ReadAllTest()
        {
            var service = new NoteService();
            var paging = new PagingAttributes();
            var expected = service.ReadAllNotes()
                .Where(x => x.Userid == 1).Count();
            Assert.AreEqual(expected, service.ReadAll(1, paging).Count);
        }

        [TestMethod()]
        public void UpdateTest()
        {
            var service = new NoteService();
            var note = service.Read(1);
            Assert.AreNotEqual("updateTestingNote", note.Note);
            note.Note = "updateTestingNote";
            service.Update(note);
            Assert.AreEqual("updateTestingNote", note.Note);
            //cleanup
            note.Note = "test";
            service.Update(note);


        }
    }
}