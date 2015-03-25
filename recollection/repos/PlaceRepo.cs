using recollection.Context;
using recollection.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace recollection.repos {
  public class PlaceRepo : IPlaceRepo{

    private recollectionContext _dbContext;

    public PlaceRepo(string connection="recollectionDBContext") {
      _dbContext = new recollectionContext(connection);
    }

    public Place GetById(int id) {
      return _dbContext.Places.Where(x => x.ID == id).First<Place>();
    }

    public List<Place> GetAllByUserId(string userID) {
      return _dbContext.Places.Where(c => c.UserID == userID).ToList();
    }

    public void Delete(int id) {
      var place = _dbContext.Places.Where(x => x.ID == id);
      _dbContext.Places.RemoveRange(place);
      _dbContext.SaveChanges();
    }

    public void Add(Place place) {
      _dbContext.Places.Add(place);
      _dbContext.SaveChanges();
    }

    public void Edit(Place place) {
      var query = _dbContext.Places.Where(c => c.ID == place.ID);

      foreach(Place dbPlace in query){
        dbPlace.Address = place.Address;
        dbPlace.Name = place.Name;
      }
      _dbContext.SaveChanges();
    }

    public void Clear() {
      var places = this.All();
      _dbContext.Places.RemoveRange(places);
      _dbContext.SaveChanges();
    }

    public int GetCount() {
      return _dbContext.Places.Count();
    }

    public List<Place> All() {
      return _dbContext.Places.ToList();
    }

    public List<Place> getPlaceBySearch(string userID, string match) {
      var matches = _dbContext.Places.Where(c => c.UserID == userID).Where(p => p.Name.Contains(match));
      return matches.ToList();
    }
  }
}