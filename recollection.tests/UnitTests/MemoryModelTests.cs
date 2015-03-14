using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using recollection.Models;

namespace recollection.tests.UnitTests {
  [TestClass]
  public class MemoryModelTests {
    [TestMethod]
    public void MemoryConstructorTestSuccess() {
      Memory memory = new Memory("June and i met at this beach");
      Assert.AreEqual("June and i met at this beach", memory.Message);
    }
  }
}
