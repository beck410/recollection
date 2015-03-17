using recollection.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace recollection.repos {
  interface IPlaceRepo {
    Place GetById(int id);
    List<Place> GetAllByUserId(string userID);
    void Delete(int id);
    void Add(Place place);
    void Edit(Place place);
    void Clear();
    int GetCount();
    List<Place> All();
  }
}
