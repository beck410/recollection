using recollection.Context;
using recollection.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using recollection.repos;

namespace recollection.tests.RepoTests {
  public class helperTests {
  
    private static NoteRepo note_repo;
    private static PersonRepo person_repo;
    private static PlaceRepo place_repo;
    private static ImageRepo image_repo;
    private static MemoryRepo memory_repo;

    public static void seedData() {
      ApplicationDbContext userContext = new ApplicationDbContext();
      recollectionContext context = new recollectionContext();
     
      ApplicationUser user = userContext.Users.Where(x => x.UserName == "jsmith@gmail.com").First();

      var people = new List<Person>{
            new Person { Name = "Peter Smith", UserID = user.Id, Birthday = new DateTime(1980, 05, 07), Address = "123 Fake Street", Phone = "1234567890", Relationship = "son", RelationshipType = "Family" },

            new Person { Name = "Mary Smith", UserID = user.Id, Birthday = new DateTime(1950, 05, 07), Address = "103 Fake Street", Phone = "1234567890", Relationship = "wife", RelationshipType = "Family" }
          };

      people.ForEach(c => context.Persons.Add(c));
      context.SaveChanges();

      int peterId = context.Persons.Where(c => c.Name == "Peter Smith").First().ID;
      int maryId = context.Persons.Where(c => c.Name == "Mary Smith").First().ID;

      var places = new List<Place> {
            new Place { Address = "Cronulla Beach, Sydney, Australia", UserID = user.Id ,Name = "Cronulla Beach" },
            new Place { Address = "103 Fake Street", Name = "Home", UserID = user.Id }
          };


      places.ForEach(c => context.Places.Add(c));
      context.SaveChanges();

      int cronullaId = context.Places.Where(c => c.Name == "Cronulla Beach").First().ID;
      int homeId = context.Places.Where(c => c.Name == "Home").First().ID;

      var memories = new List<Memory> {
            new Memory { LocationID = cronullaId, Message = "Where i learnt to ride my first surfboard" },
            new Memory { LocationID = homeId, Message = "Mary and I bought the house in 1980 and raised our 3 children here" },
            new Memory { PersId = maryId, Message = "Mary is very kind and patient. She likes roses and country music. We were married in Australia and raised 3 children together. We met on a cruise" },
            new Memory { PersId = peterId, Message = "Peter is my oldest son and second child. He loves football and is an engineer. We go fishing every Saturday" }
          };
      memories.ForEach(c => context.Memories.Add(c));
      context.SaveChanges();

      var notes = new List<Note> {
            new Note { LocationID = cronullaId, Message = "fish and chips are great at the kiosk" },
            new Note { PersId = peterId, Message = "Peter has 2 children - Ruth and Bobby" },
            new Note { PersId = maryId, Message = "Mary has 1 sisters - Rachel" }
          };
      notes.ForEach(c => context.Notes.Add(c));
      context.SaveChanges();
    }

    public static void ClearAllDB() { 
      note_repo.Clear();
      person_repo.Clear();
      place_repo.Clear();
      memory_repo.Clear();
      image_repo.Clear(); 
    }
  }
}
