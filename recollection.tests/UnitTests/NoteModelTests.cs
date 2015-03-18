using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using recollection.Models;

namespace recollection.tests.UnitTests {
  [TestClass]
  public class NoteModelTests {
    [TestMethod]
    public void NoteConstructorPersonTestSuccess() {
      Note note = new Note("This is a quick note about nothing",true,1);
      Assert.AreEqual("This is a quick note about nothing",note.Message);
      Assert.AreEqual(1,note.PersId);
      Assert.AreEqual(0,note.LocationID);
    }

    [TestMethod]
    public void NoteConstructorPlaceTestSuccess() {
      Note note = new Note("This is a quick note about nothing",false,1);
      Assert.AreEqual("This is a quick note about nothing",note.Message);
      Assert.AreEqual(0,note.PersId);
      Assert.AreEqual(1,note.LocationID);
    }
  }
}
