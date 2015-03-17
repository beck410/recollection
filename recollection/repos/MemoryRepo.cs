using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace recollection.repos {
  public class MemoryRepo : IMemoryRepo {
    public Models.Memory GetById(int id) {
      throw new NotImplementedException();
    }

    public Models.Memory Delete(int id) {
      throw new NotImplementedException();
    }

    public Models.Memory Add(Models.Person person) {
      throw new NotImplementedException();
    }

    public Models.Memory Edit(Models.Person person) {
      throw new NotImplementedException();
    }

    public List<Models.Memory> GetAllPlaceMemories(int placeId) {
      throw new NotImplementedException();
    }

    public List<Models.Memory> GetAllPersonMemories(int personId) {
      throw new NotImplementedException();
    }
  }
}