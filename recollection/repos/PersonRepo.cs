using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace recollection.repos {
  public class PersonRepo : IPersonRepo {
    public Models.Person GetById(int id) {
      throw new NotImplementedException();
    }

    public List<Models.Person> GetAllByUserId(string userID) {
      throw new NotImplementedException();
    }

    public Models.Person Delete(int id) {
      throw new NotImplementedException();
    }

    public Models.Person Add(Models.Person person) {
      throw new NotImplementedException();
    }

    public Models.Person Edit(Models.Person person) {
      throw new NotImplementedException();
    }
  }
}