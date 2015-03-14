using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using recollection.Models;

namespace recollection.tests.UnitTests {
  [TestClass]
  public class ImageModelTests {
    [TestMethod]
    public void ImageContructirTestSuccess() {
      Image image = new Image("https://www.asw/recollection/beach.jpg", "Diamond Beach, Australia", new DateTime(2013,04,01));
      Assert.AreEqual("https://www.asw/recollection/beach.jpg",image.ImageLink);
      Assert.AreEqual("Diamond Beach, Australia",image.Caption);
      Assert.AreEqual(new DateTime(2013,04,01),image.DateOfImage);
    }
  }
}
