using recollection.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace recollection.repos {
  public class PlaceRepo : IPlaceRepo{

    public Place GetById(int id) {
      throw new NotImplementedException();
    }

    public List<Place> GetAllByUserId(string userID) {
      throw new NotImplementedException();
    }

    public Place Delete(int id) {
      throw new NotImplementedException();
    }

    public Place Add(Person place) {
      throw new NotImplementedException();
    }

    public Place Edit(Person place) {
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