using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using recollection.repos;

namespace recollection.tests.RepoTests {
  [TestClass]

  public class NoteRepoTests : helperTests {

    private static NoteRepo note_repo;
    private static PersonRepo person_repo;
    private static PlaceRepo place_repo;
    private static ImageRepo image_repo;
    private static MemoryRepo memory_repo;

    [TestInitialize]
    public static void SetUp(TestContext _context) {
      note_repo = new NoteRepo();
      person_repo = new PersonRepo();
      place_repo = new PlaceRepo();
      seedData();
    }

    [TestCleanup]
    public void ClearDB() {

    }
    
    [TestMethod]
    public void TestMethod1() {
    }
  }
}
