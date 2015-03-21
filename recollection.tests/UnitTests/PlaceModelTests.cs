using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using recollection.Models;

namespace recollection.tests.UnitTests {
  [TestClass]
  public class PlaceModelTests {
    [TestMethod]
    public void PlaceConstructorTestSuccess() {
      Place cinema = new Place("c4fgs3", "Belcourt Cinema", "123 Fake Lane, Nashville", "www.someimge.com");
      Assert.AreEqual("c4fgs3", cinema.UserID);
      Assert.AreEqual("Belcourt Cinema", cinema.Name);
      Assert.AreEqual("123 Fake Lane, Nashville", cinema.Address);
    }
  }
}
