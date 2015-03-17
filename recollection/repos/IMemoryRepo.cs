using recollection.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace recollection.repos {
  interface IMemoryRepo {
    Memory GetById(int id);
    Memory Delete(int id);
    Memory Add(Person person);
    Memory Edit(Person person);
    List<Memory> GetAllPlaceMemories(int placeId);
    List<Memory> GetAllPersonMemories(int personId);
  }
}
