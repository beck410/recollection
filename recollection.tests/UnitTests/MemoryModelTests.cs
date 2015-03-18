using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using recollection.Models;

namespace recollection.tests.UnitTests {
  [TestClass]
  public class MemoryModelTests {
    [TestMethod]
    public void MemoryConstructorTestForLocationSuccess() {
      Memory memory = new Memory("June and i met at this beach",false,1);
      Assert.AreEqual("June and i met at this beach", memory.Message);
      Assert.AreEqual(0, memory.PersId);
      Assert.AreEqual(1, memory.LocationID);
    }

    [TestMethod]
    public void MemoryConstructorTestForPersonSuccess() {
      Memory memory = new Memory("June and i have been married for 20 years",true,1);
      Assert.AreEqual("June and i have been married for 20 years", memory.Message);
      Assert.AreEqual(1, memory.PersId);
      Assert.AreEqual(0, memory.LocationID);
    }
  }
}
