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
    private static ApplicationDbContext userContext = new ApplicationDbContext();
    private static recollectionContext context = new recollectionContext();
    private static NoteRepo note_repo = new NoteRepo("Name=recollectionTest");
    private static PersonRepo person_repo = new PersonRepo("Name=recollectionTest");
    private static PlaceRepo place_repo = new PlaceRepo("Name=recollectionTest");
    private static ImageRepo image_repo = new ImageRepo("Name=recollectionTest");
    private static MemoryRepo memory_repo = new MemoryRepo("Name=recollectionTest");

    public static ApplicationUser firstUser() {
      ApplicationUser user = userContext.Users.First();
      return user;
    }

    public static void seedData() {
      var user = userContext.Users.First();
      var people = new List<Person>{
            new Person { Name = "Peter Smith", UserID = user.Id, Birthday = new DateTime(1980, 05, 07), Address = "123 Fake Street", Phone = "1234567890", Relationship = "son", RelationshipType = "Family" },

            new Person { Name = "Mary Smith", UserID = user.Id, Birthday = new DateTime(1950, 05, 07), Address = "103 Fake Street", Phone = "1234567890", Relationship = "wife", RelationshipType = "Family" }
          };

      people.ForEach(c => person_repo.Add(c));

      int peterId = context.Persons.Where(c => c.Name == "Peter Smith").First().ID;
      int maryId = context.Persons.Where(c => c.Name == "Mary Smith").First().ID;

      var places = new List<Place> {
            new Place { Address = "Cronulla Beach, Sydney, Australia", UserID = user.Id ,Name = "Cronulla Beach" },
            new Place { Address = "103 Fake Street", Name = "Home", UserID = user.Id }
          };

      places.ForEach(c => place_repo.Add(c));

      int cronullaId = context.Places.Where(c => c.Name == "Cronulla Beach").First().ID;
      int homeId = context.Places.Where(c => c.Name == "Home").First().ID;

      var memories = new List<Memory> {
            new Memory { LocationID = cronullaId, Message = "Where i learnt to ride my first surfboard" },
            new Memory { LocationID = homeId, Message = "Mary and I bought the house in 1980 and raised our 3 children here" },
            new Memory { PersId = maryId, Message = "Mary is very kind and patient. She likes roses and country music. We were married in Australia and raised 3 children together. We met on a cruise" },
            new Memory { PersId = peterId, Message = "Peter is my oldest son and second child. He loves football and is an engineer. We go fishing every Saturday" }
          };
      memories.ForEach(c => memory_repo.Add(c));

      var notes = new List<Note> {
            new Note { LocationID = cronullaId, Message = "fish and chips are great at the kiosk" },
            new Note { PersId = peterId, Message = "Peter has 2 children - Ruth and Bobby" },
            new Note { PersId = maryId, Message = "Mary has 1 sisters - Rachel" }
          };
      notes.ForEach(c => note_repo.Add(c));

      var images = new List<Image> {
            new Image { ImageLink = "http://i.huffpost.com/gen/1623986/images/o-WOMEN-LAUGHING-facebook.jpg", Caption = "Mary laughing", PersID = maryId, DateOfImage = new DateTime(2013,05,01)},
            new Image { ImageLink = "http://www.sutherlandshireaustralia.com.au/imagesDB/gallery/CronullaSlideshow6_1.jpg", LocationID = cronullaId, Caption = "Nice day out with family at the beach", DateOfImage = new DateTime(2000,10,05) }
         };
      images.ForEach(c => image_repo.Add(c));
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
