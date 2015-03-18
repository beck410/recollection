using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using recollection.repos;
using recollection.Models;
using System.Collections.Generic;

namespace recollection.tests.RepoTests {
  [TestClass]
  public class MemoryRepoTests {
  
    private static MemoryRepo memory_repo = new MemoryRepo("Name=recollectionTest");
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
      memory_repo.Clear();
    }

    [ClassCleanup]
    public static void CleanUp() {
      helperTests.ClearAllDB();
    }

    [TestMethod]
    public void MemoryTestGetByIdMethod() {
      List<Memory> memories = memory_repo.All();
      int firstMemoryId = memories[0].ID;

      Memory firstMemory = memory_repo.GetById(firstMemoryId);
      Assert.AreEqual(memories[0],firstMemory);
    }

    [TestMethod]
    public void MemoryTestDeleteMethod() {
      List<Memory> memories = memory_repo.All();
      Assert.AreEqual(4, memories.Count);
      var firstMemoryId = memories[0].ID;
      memory_repo.Delete(firstMemoryId);
      List<Memory> newMemoriesList = memory_repo.All();
      Assert.AreEqual(3,newMemoriesList.Count);
      Assert.AreEqual("Mary and I bought the house in 1980 and raised our 3 children here", newMemoriesList[0].Message); 
    }

    [TestMethod]
    public void MemoryTestAddMethod() {
      List<Memory> memories = memory_repo.All();
      int memoryCount = memories.Count;
      int locId = memories[0].LocationID;
      Assert.AreEqual(4, memoryCount);
      Memory cronMemory = new Memory("I used to go to Cronulla Beach when i was younger",false,locId);

      memory_repo.Add(cronMemory);
      List<Memory> updatedMemories = memory_repo.All();
      Assert.AreEqual(5,updatedMemories.Count);
      Assert.AreEqual(cronMemory,updatedMemories[4]);
    }

    [TestMethod]
    public void MemoryTestEditMethod() {
      Memory cron = memory_repo.All()[0];
      cron.Message = "Where i learnt to ride my SECOND surfboard";
      memory_repo.Edit(cron);
      Memory newCron = memory_repo.All()[0];
      Assert.AreEqual("Where i learnt to ride my SECOND surfboard", newCron.Message);
    }

    [TestMethod]
    public void MemoryTestGetAllPlaceMemoriesMethod() {
      int placeId = memory_repo.All()[2].PersId;

      int memoryCount = memory_repo.GetAllPlaceMemories(placeId).Count; 
      Assert.AreEqual(1,memoryCount);      
    }

    [TestMethod]
    public void MemoryTestGetAllMemoriesMemoriesMethod() {
      int locationId = memory_repo.All()[0].LocationID;

      int memoryCount = memory_repo.GetAllPersonMemories(locationId).Count; 
      Assert.AreEqual(1,memoryCount); 
    }

    [TestMethod]
    public void MemoryTestClearMethod() { 
      List<Memory> memories = memory_repo.All();
      int beforeCount = memory_repo.GetCount();
      Assert.AreEqual(4,beforeCount);

      memory_repo.Clear();
      var afterCount = memory_repo.GetCount();
      Assert.AreEqual(0, afterCount);
    }

    [TestMethod]
    public void MemoryTestGetCountMethod() {
      int memoryCount = memory_repo.GetCount();
      Assert.AreEqual(4, memoryCount);
    }

    [TestMethod]
    public void MemoryTestAllMethod() { 
      var allMemories = memory_repo.All();
      Assert.AreEqual(4,allMemories.Count);
    }
  }
}
