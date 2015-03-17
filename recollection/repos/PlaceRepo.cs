using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace recollection.repos {
  public class PlaceRepo : IPlaceRepo{
    public Models.Place GetById(int id) {
      throw new NotImplementedException();
    }

    public List<Models.Place> GetAllByUserId(string userID) {
      throw new NotImplementedException();
    }

    public Models.Place Delete(int id) {
      throw new NotImplementedException();
    }

    public Models.Place Add(Models.Person place) {
      throw new NotImplementedException();
    }

    public Models.Place Edit(Models.Person place) {
      throw new NotImplementedException();
    }
  }
}