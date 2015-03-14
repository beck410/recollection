using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using recollection.Models;

namespace recollection.tests.UnitTests {
  [TestClass]
  public class NoteModelTests {
    [TestMethod]
    public void NoteConstructorTestSuccess() {
      Note note = new Note("This is a quick note about nothing");
      Assert.AreEqual("This is a quick note about nothing",note.Message);
    }
  }
}
