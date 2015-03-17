using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace recollection.repos {
  public class NoteRepo : INoteRepo {
    public Models.Note GetById(int id) {
      throw new NotImplementedException();
    }

    public Models.Note Delete(int id) {
      throw new NotImplementedException();
    }

    public Models.Note Add(Models.Note note) {
      throw new NotImplementedException();
    }

    public Models.Note Edit(Models.Note note) {
      throw new NotImplementedException();
    }

    public List<Models.Note> GetAllPlaceNotes(int placeId) {
      throw new NotImplementedException();
    }

    public List<Models.Note> GetAllPersonNotes(int personId) {
      throw new NotImplementedException();
    }
  }
}