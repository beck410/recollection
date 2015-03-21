using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using recollection.Models;

namespace recollection.tests.UnitTests {
  [TestClass]
  public class PersonModelTests {
    [TestMethod]
    public void PersonConstructorTestSuccess() {
      Person bob = new Person("c1ad","Bob Smith","123 Fake Street","1234561234",new DateTime(2005,04,03),"Friend from Bowling Club","Friend", "www.someimage.com");
      Assert.AreEqual("c1ad", bob.UserID);
      Assert.AreEqual("Bob Smith", bob.Name);
      Assert.AreEqual("123 Fake Street", bob.Address);
      Assert.AreEqual("1234561234", bob.Phone);
      Assert.AreEqual(new DateTime(2005,04,03), bob.Birthday);
      Assert.AreEqual("Friend from Bowling Club",bob.Relationship);
      Assert.AreEqual("Friend",bob.RelationshipType);
    }
  }
}
