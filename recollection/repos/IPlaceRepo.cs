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
    Place Delete(int id);
    Place Add(Person place);
    Place Edit(Person place);
    void Clear();
    int GetCount();
  }
}
