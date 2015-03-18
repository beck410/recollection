using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using recollection.Models;
using recollection.Context;

namespace recollection.repos {
  public class NoteRepo : INoteRepo {

    private recollectionContext _dbContext;

    public NoteRepo(string connection="recollectionDBContext") {
      _dbContext = new recollectionContext(connection);
    }

    public Note GetById(int id) {
      return _dbContext.Notes.Where(x => x.ID == id).First<Note>();
    }

    public void Delete(int id) {
      var note = _dbContext.Notes.Where(x => x.ID == id);
      _dbContext.Notes.RemoveRange(note);
      _dbContext.SaveChanges();
    }

    public void Add(Note note) {
      _dbContext.Notes.Add(note);
      _dbContext.SaveChanges();
    }

    public void Edit(Note note) {
      var query = _dbContext.Notes.Where(c => c.ID == note.ID);

      foreach(Note dbNote in query){
        dbNote.Message = note.Message;
        dbNote.LocationID = note.LocationID;
        dbNote.PersId = note.PersId;
      }

      _dbContext.SaveChanges();
    }

    public List<Note> GetAllPlaceNotes(int placeId) {
      return _dbContext.Notes.Where(c => c.LocationID == placeId).ToList();
    }

    public List<Note> GetAllPersonNotes(int noteId) {
      return _dbContext.Notes.Where(c => c.PersId == noteId).ToList();
    }

    public int GetCount() {
      return _dbContext.Notes.Count();
    }

    public void Clear() {
      var notes = this.All();
      _dbContext.Notes.RemoveRange(notes);
      _dbContext.SaveChanges();
    }

    public List<Note> All() {
      return _dbContext.Notes.ToList();
    }
  }
}