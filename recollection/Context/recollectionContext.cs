using recollection.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace recollection.Context {
  public class recollectionContext : DbContext{

    public recollectionContext(string connection="recollectionContext") : base(connection) {
    }

    public recollectionContext(){}

    public DbSet<Memory> Memories { get; set; }
    public DbSet<Person> Persons { get; set; }
    public DbSet<Place> Places { get; set; }
    public DbSet<Note> Notes { get; set; }
    public DbSet<Image> Images { get; set; }   
  }
}