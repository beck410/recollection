using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using recollection.repos;
using recollection.Models;
using System.Collections.Generic;

namespace recollection.tests.RepoTests {
  [TestClass]

  public class NoteRepoTests : helperTests {

    private static NoteRepo note_repo = new NoteRepo("Name=recollectionTest");
    private static ApplicationUser user;

    [ClassInitialize]
    public static void SetUp(TestContext _context) {
      helperTests.ClearAllDB();
      user = helperTests.firstUser();
    }

    [TestInitialize]
    public void TestSetUp() { 
      helperTests.ClearAllDB();
      helperTests.seedData();
    }

    [TestCleanup]
    public void TestCleanUp() {
      note_repo.Clear();
    }

    [ClassCleanup]
    public static void CleanUp() {
      helperTests.ClearAllDB();
    }
    
    [TestMethod]
    public void NoteTestGetByIdMethod() {
      List<Note> notes = note_repo.All();
      int firstNoteId = notes[0].ID;

      Note firstNote = note_repo.GetById(firstNoteId);
      Assert.AreEqual(notes[0],firstNote);
    }
    
    [TestMethod]
    public void NoteTestDeleteMethod() {
      List<Note> notes = note_repo.All();
      Assert.AreEqual(3,notes.Count);
      var firstNoteId = notes[0].ID;
      note_repo.Delete(firstNoteId);
      List<Note> newNoteList = note_repo.All();
      Assert.AreEqual(2,newNoteList.Count);
      Assert.AreEqual("Peter has 2 children - Ruth and Bobby", newNoteList[0].Message);
    }

    [TestMethod]
    public void NoteTestAddMethod() {
      int persId = note_repo.All()[0].LocationID;

      int noteCount = note_repo.All().Count;
      Assert.AreEqual(3,noteCount);
      Note newNote = new Note("Take Mary there for her birthday", true, persId);

      note_repo.Add(newNote);
      List<Note> updatesNotes = note_repo.All();
      Assert.AreEqual(4,updatesNotes.Count);
      Assert.AreEqual(newNote,updatesNotes[3]);
    }

    [TestMethod]
    public void NoteTestEditMethod() {
      Note note = note_repo.All()[0];
      note.Message = "stay away from kiosk";
      note_repo.Edit(note);
      Note updatedNote = note_repo.All()[0];
      Assert.AreEqual("stay away from kiosk",updatedNote.Message);
    }

    [TestMethod]
    public void NoteTestGetAllPersenNotesMethod() {
      int placeId = note_repo.All()[0].PersId;
      int noteCount = note_repo.GetAllPersonNotes(placeId).Count;
      Assert.AreEqual(1,noteCount);
    }

    [TestMethod]
    public void NoteTestGetAllPlaceNotesMethod() {
      int locId = note_repo.All()[1].LocationID;
      int noteCount = note_repo.GetAllPlaceNotes(locId).Count;
      Assert.AreEqual(2,noteCount);
    }

    [TestMethod]
    public void NoteTestGetCountMethod() {
      int noteCount = note_repo.GetCount();
      Assert.AreEqual(3, noteCount);
    }

    [TestMethod]
    public void NoteTestClearMethod() {
      List<Note> notes = note_repo.All();
      int beforeCount = note_repo.GetCount();
      Assert.AreEqual(3,beforeCount);

      note_repo.Clear();
      var afterCount = note_repo.GetCount();
      Assert.AreEqual(0, afterCount);
    }

    [TestMethod]
    public void NoteTestAllMethod() {
      var allNotes = note_repo.All();
      Assert.AreEqual(3,allNotes.Count);
    }

  }
}
