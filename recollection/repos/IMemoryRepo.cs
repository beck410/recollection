using recollection.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace recollection.repos {
  interface IMemoryRepo {
    Memory GetById(int id);
    void Delete(int id);
    void Add(Memory memory);
    void Edit(Memory memory);
    List<Memory> GetAllPlaceMemories(int placeId);
    List<Memory> GetAllPersonMemories(int personId);
    void Clear();
    int GetCount();
    List<Memory> All();
  }
}
