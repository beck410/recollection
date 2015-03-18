using recollection.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace recollection.repos {
  interface INoteRepo {
    Note GetById(int id);
    void Delete(int id);
    void Add(Note note);
    void Edit(Note note);
    List<Note> GetAllPlaceNotes(int placeId);
    List<Note> GetAllPersonNotes(int personId);
    int GetCount();
    void Clear();
    List<Note> All();
  }
}
