namespace recollection.Migrations
{
  using Microsoft.AspNet.Identity;
  using Microsoft.AspNet.Identity.EntityFramework;
  using recollection.Context;
  using recollection.Models;
  using System;
  using System.Collections.Generic;
  using System.Data.Entity;
  using System.Data.Entity.Migrations;
  using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<recollection.Context.recollectionContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        private void AddUsers(ApplicationDbContext context) {
          if (!(context.Users.Any(u => u.UserName == "jsmith@gmail.com"))) {
            var userStore = new UserStore<ApplicationUser>(context);
            var userManager = new UserManager<ApplicationUser>(userStore);
            var userToInsert = new ApplicationUser { UserName = "jsmith@gmail.com", PhoneNumber = "0797697898" };
            userManager.Create(userToInsert, "password");
          }
          context.SaveChanges();
        }

        protected override void Seed(recollectionContext context) {

          ApplicationDbContext userContext = new ApplicationDbContext();

          AddUsers(userContext);

          string userID = "91818b2b-a2af-4e10-8fb4-362fd8780ba3";

          var people = new List<Person>{
            new Person { Name = "Peter Smith", UserID = userID, Birthday = new DateTime(1980, 05, 07), Address = "123 Fake Street", Phone = "1234567890", Relationship = "son", RelationshipType = "Family", MainImage = "http://www.culligan.com/images/Culligan_NewMan.png" },

            new Person { Name = "Mary Smith", UserID = userID, Birthday = new DateTime(1950, 05, 07), Address = "103 Fake Street", Phone = "1234567890", Relationship = "wife", RelationshipType = "Family", MainImage = "http://slodive.com/wp-content/uploads/2013/04/short-hair-styles-for-older-women/cheerful-old-woman.jpg " }
          };

          people.ForEach(s => context.Persons.AddOrUpdate(p => p.Name, s));
          context.SaveChanges();

          int peterId = context.Persons.Where(c => c.Name == "Peter Smith").First().ID;
          int maryId = context.Persons.Where(c => c.Name == "Mary Smith").First().ID;

          var places = new List<Place> {
            new Place { Address = "Cronulla Beach, Sydney, Australia", UserID = userID ,Name = "Cronulla Beach", MainImage = "http://media-cdn.tripadvisor.com/media/photo-s/02/50/f2/a4/south-cronulla-beach.jpg" },
            new Place { Address = "103 Fake Street", Name = "Home", UserID = userID, MainImage = "http://www.burkhartinsurance.com/wp-content/uploads/2011/12/home1.jpg" }
          };
          places.ForEach(s => context.Places.AddOrUpdate(p => p.Name, s));
          context.SaveChanges();

          int cronullaId = context.Places.Where(c => c.Name == "Cronulla Beach").First().ID;
          int homeId = context.Places.Where(c => c.Name == "Home").First().ID;

          var memories = new List<Memory> {
            new Memory { LocationID = cronullaId, Message = "Where i learnt to ride my first surfboard" },
            new Memory { LocationID = homeId, Message = "Mary and I bought the house in 1980 and raised our 3 children here" },
            new Memory { PersId = maryId, Message = "Mary is very kind and patient. She likes roses and country music. We were married in Australia and raised 3 children together. We met on a cruise" },
            new Memory { PersId = peterId, Message = "Peter is my oldest son and second child. He loves football and is an engineer. We go fishing every Saturday" }
          };
          memories.ForEach(s => context.Memories.AddOrUpdate(c => c.Message, s));
          context.SaveChanges();

          var notes = new List<Note> {
            new Note { LocationID = cronullaId, Message = "fish and chips are great at the kiosk" },
            new Note { PersId = peterId, Message = "Peter has 2 children - Ruth and Bobby" },
            new Note { PersId = maryId, Message = "Mary has 1 sisters - Rachel" }
          };
          notes.ForEach(s => context.Notes.AddOrUpdate(c => c.Message, s));
          context.SaveChanges();
        } 
    }
}
