using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using recollection.repos;
using recollection.Models;
using System.Collections.Generic;

namespace recollection.tests.RepoTests {
  [TestClass]
  public class ImageRepoTests {
   
    private static ImageRepo image_repo = new ImageRepo("Name=recollectionTest");
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
      image_repo.Clear();
    }

    [ClassCleanup]
    public static void CleanUp() {
      helperTests.ClearAllDB();
    }

    [TestMethod]
    public void ImageTestGetByIdMethod() {
    }

    [TestMethod]
    public void ImageTestAddMethod() {
      
    }

    [TestMethod]
    public void ImageTestEditMethod() {
    }

    [TestMethod]
    public void ImageTestGetPlaceImageMethod() {
    }


    [TestMethod]
    public void ImageTestGetImageImageMethod() {
    }

    [TestMethod]
    public void ImageTestClearMethod() {
      List<Image> people = image_repo.All();
      int beforeCount = image_repo.GetCount();
      Assert.AreEqual(2,beforeCount);

      image_repo.Clear();
      var afterCount = image_repo.GetCount();
      Assert.AreEqual(0, afterCount);
    }

    [TestMethod]
    public void ImageTestGetCountMethod() {
    }

    [TestMethod]
    public void ImageTestAllMethod() {
      var allImages = image_repo.All();
      Assert.AreEqual(2,allImages.Count);
    }

    [TestMethod]
    public void ImageTestDeleteMethod() {
       List<Image> people = image_repo.All();
      Assert.AreEqual(2, people.Count);
      var firstImageId = people[0].ID;
      image_repo.Delete(firstImageId);
      List<Image> newImageList = image_repo.All();
      Assert.AreEqual(1,newImageList.Count);
      Assert.AreEqual("Nice day out with family at the beach", newImageList[0].Caption);
    }
  }
}
