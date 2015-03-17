using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using recollection.repos;
using recollection.Models;
using System.Collections.Generic;

namespace recollection.tests.RepoTests {
  [TestClass]
  public class PersonRepoTests {

    private static PersonRepo person_repo = new PersonRepo("Name=recollectionTest");
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
      person_repo.Clear();
    }

    [ClassCleanup]
    public static void CleanUp() {
      helperTests.ClearAllDB();
    }

    [TestMethod]
    public void PersonTestAllMethod() {
      var allPeople = person_repo.All();
      Assert.AreEqual(2,allPeople.Count);
    }

    [TestMethod]
    public void PersonTestClearMethod() {
      List<Person> people = person_repo.All();
      int beforeCount = person_repo.GetCount();
      Assert.AreEqual(2,beforeCount);

      person_repo.Clear();
      var afterCount = person_repo.GetCount();
      Assert.AreEqual(0, afterCount);
    }

    [TestMethod]
    public void PersonTestDeleteMethod() {
      List<Person> people = person_repo.All();
      Assert.AreEqual(2, people.Count);
      var firstPersonId = people[0].ID;
      person_repo.Delete(firstPersonId);
      List<Person> newPeopleList = person_repo.All();
      Assert.AreEqual(1,newPeopleList.Count);
      Assert.AreEqual("wife", newPeopleList[0].Relationship);
    }


    [TestMethod]
    public void PersonTestGetByIdMethod() {
      List<Person> people = person_repo.All();
      int firstPersonId = people[0].ID;

      Person firstPerson = person_repo.GetById(firstPersonId);
      Assert.AreEqual(people[0],firstPerson);
    }

    [TestMethod]
    public void PersonTestGetAllByUserId() {
      string userId = user.Id;
      int peopleCount = person_repo.GetAllByUserId(userId).Count;
      Assert.AreEqual(2,peopleCount);
    }

    [TestMethod]
    public void PersonTestAddMethod() {
      int peopleCount = person_repo.All().Count;
      Person ruth = new Person(user.Id, "Ruth Smith", "1045 Fake Street", "1234567898", new DateTime(1960, 04, 03), "sister", "Family");

      person_repo.Add(ruth);
      List<Person> updatedPeople = person_repo.All();
      Assert.AreEqual(3,updatedPeople.Count);
      Assert.AreEqual(ruth, updatedPeople[2]); 
    }

    [TestMethod]
    public void PersonTestGetCountMethod() {
      int peopleCount = person_repo.GetCount();
      Assert.AreEqual(2, peopleCount);
    }
  }
}
