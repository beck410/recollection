using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using recollection.repos;
using recollection.Models;
using System.Collections.Generic;

namespace recollection.tests.RepoTests {
  [TestClass]
  public class PlaceRepoTests {

    private static PlaceRepo place_repo = new PlaceRepo("Name=recollectionTest");
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
      place_repo.Clear();
    }

    [ClassCleanup]
    public static void CleanUp() {
      helperTests.ClearAllDB();
    }

    [TestMethod]
    public void PlaceTestAllMethod() {
      var allPlaces = place_repo.All();
      Assert.AreEqual(2,allPlaces.Count);
    }

    [TestMethod]
    public void PlaceTestClearMethod() {
      List<Place> places = place_repo.All();
      int beforeCount = place_repo.GetCount();
      Assert.AreEqual(2,beforeCount);

      place_repo.Clear();
      var afterCount = place_repo.GetCount();
      Assert.AreEqual(0, afterCount);
    }

    [TestMethod]
    public void PlaceTestGetByIdMethod() {
      List<Place> places = place_repo.All();
      int firstPlaceId = places[0].ID;

      Place firstPlace = place_repo.GetById(firstPlaceId);
      Assert.AreEqual(places[0],firstPlace);
    }

    [TestMethod]
    public void PlaceTestGetAllByUserId() {
      string userId = user.Id;
      int placesCount = place_repo.GetAllByUserId(userId).Count;
      Assert.AreEqual(2,placesCount);
    }

    [TestMethod]
    public void PlaceTestAddMethod() {
      int placesCount = place_repo.All().Count;
      Assert.AreEqual(2, placesCount);
      Place bank = new Place(user.Id, "Wells Fargo Bank", "2nd Street, Nashville");

      place_repo.Add(bank);
      List<Place> updatedPlace = place_repo.All();
      Assert.AreEqual(3,updatedPlace.Count);
      Assert.AreEqual(bank, updatedPlace[2]); 
    }

    [TestMethod]
    public void PlaceTestGetCountMethod() {
      int placesCount = place_repo.GetCount();
      Assert.AreEqual(2, placesCount);
    }

    [TestMethod]
    public void PlaceTestEditMethod() {
      Place beach = place_repo.All()[0];
      beach.Name = "Bondi";
      place_repo.Edit(beach);
      Place newBeach = place_repo.All()[0];
      Assert.AreEqual("Bondi", newBeach.Name);
    }
  }
}
