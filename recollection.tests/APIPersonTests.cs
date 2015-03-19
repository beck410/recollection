using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using recollection.Controllers;
using System.Web;

namespace recollection.tests.APITests {
  [TestClass]
  public class APIPersonTests {

    [TestMethod]
    public void APITestGetPersons() {
      var controller = new RecollectionController("Name=recollectionTest");

      var result = controller.GetPersons("04f7c20a-e584-4b7f-8d28-a88e8f1b4ac6");
      Assert.AreEqual(2, result.Count);
    }
  }
}
