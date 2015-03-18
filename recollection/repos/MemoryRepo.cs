using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using recollection.Models;
using recollection.Context;

namespace recollection.repos {
  public class MemoryRepo : IMemoryRepo {

    private recollectionContext _dbContext;

    public MemoryRepo(string connection="recollectionDBContext") {
      _dbContext = new recollectionContext(connection);
    }

    public Memory GetById(int id) {
      return _dbContext.Memories.Where(x => x.ID == id).First<Memory>();
    }

    public void Delete(int id) {
      var memory = _dbContext.Memories.Where(x => x.ID == id);
      _dbContext.Memories.RemoveRange(memory);
      _dbContext.SaveChanges();
    }

    public void Add(Memory memory) {
      _dbContext.Memories.Add(memory);
      _dbContext.SaveChanges();
    }

    public void Edit(Memory memory) {
      var query = _dbContext.Memories.Where(c => c.ID == memory.ID);

      foreach (Memory dbMemory in query) {
        dbMemory.Message = memory.Message;
        dbMemory.LocationID = memory.LocationID;
        dbMemory.PersId = memory.PersId;
      }

      _dbContext.SaveChanges();
    }

    public List<Memory> GetAllPlaceMemories(int placeId) {
      return _dbContext.Memories.Where(c => c.LocationID == placeId).ToList();
    } 

    public void Clear() {
      var memories = this.All();
      _dbContext.Memories.RemoveRange(memories);
      _dbContext.SaveChanges();
    }

    public int GetCount() {
      return _dbContext.Memories.Count<Memory>();
    }

    public List<Memory> All() {
      return _dbContext.Memories.ToList();
    }


    public List<Memory> GetAllPersonMemories(int personId) {
      return _dbContext.Memories.Where(c => c.PersId == personId).ToList();
    }
  }
}
