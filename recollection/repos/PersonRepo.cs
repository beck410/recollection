using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using recollection.Models;
using recollection.Context;

namespace recollection.repos {
  public class PersonRepo : IPersonRepo {

    private recollectionContext _dbContext;

    public PersonRepo(string connection="recollectionDBContext") {
      _dbContext = new recollectionContext(connection);
    }

    public Person GetById(int id) {
      return _dbContext.Persons.Where(x => x.ID == id).First<Person>();
    }

    public List<Person> GetAllByUserId(string userID) {
      return _dbContext.Persons.Where(c => c.UserID == userID).ToList();
    }

    public void Delete(int id) {
      var person = _dbContext.Persons.Where(x => x.ID == id);
      _dbContext.Persons.RemoveRange(person);
      _dbContext.SaveChanges();
    }

    public void Add(Person person) {
      _dbContext.Persons.Add(person);
      _dbContext.SaveChanges();
    }

    public void Edit(Person person) {
      var query = _dbContext.Persons.Where(c => c.ID == person.ID);

      foreach(Person dbPerson in query) {
        dbPerson.Address = person.Address;
        dbPerson.Birthday = person.Birthday;
        dbPerson.Name = person.Name;
        dbPerson.Phone = dbPerson.Phone;
        dbPerson.Relationship = dbPerson.Relationship;
        dbPerson.RelationshipType = dbPerson.RelationshipType;
      }

      _dbContext.SaveChanges();
    }

    public void Clear() {
      var people = this.All();
      _dbContext.Persons.RemoveRange(people);
      _dbContext.SaveChanges();
    }

    public int GetCount() {
      return _dbContext.Persons.Count<Person>();
    }

    public List<Person> All() {
      return _dbContext.Persons.ToList();
    }

    public List<Person> getByRelationshipType(string type) {
      return _dbContext.Persons.Where(c => c.RelationshipType == type).ToList<Person>();
    }
  }
}