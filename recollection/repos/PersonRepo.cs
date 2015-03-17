using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using recollection.Models;

namespace recollection.repos {
  public class PersonRepo : IPersonRepo {

    public Person GetById(int id) {
      throw new NotImplementedException();
    }

    public List<Person> GetAllByUserId(string userID) {
      throw new NotImplementedException();
    }

    public Person Delete(int id) {
      throw new NotImplementedException();
    }

    public Person Add(Person person) {
      throw new NotImplementedException();
    }

    public Person Edit(Person person) {
      throw new NotImplementedException();
    }

    public void Clear() {
      throw new NotImplementedException();
    }

    public int GetCount() {
      throw new NotImplementedException();
    }
  }
}