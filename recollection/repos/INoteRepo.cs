using recollection.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace recollection.repos {
  interface INoteRepo {
    Note GetById(int id);
    Note Delete(int id);
    Note Add(Note note);
    Note Edit(Note note);
    List<Note> GetAllPlaceNotes(int placeId);
    List<Note> GetAllPersonNotes(int personId);
    int GetCount();
    void Clear();
  }
}
