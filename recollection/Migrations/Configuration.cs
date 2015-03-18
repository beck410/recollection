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

          ApplicationUser user = userContext.Users.Where(x => x.UserName == "jsmith@gmail.com").First();

          var people = new List<Person>{
            new Person { Name = "Peter Smith", UserID = user.Id, Birthday = new DateTime(1980, 05, 07), Address = "123 Fake Street", Phone = "1234567890", Relationship = "son", RelationshipType = "Family" },

            new Person { Name = "Mary Smith", UserID = user.Id, Birthday = new DateTime(1950, 05, 07), Address = "103 Fake Street", Phone = "1234567890", Relationship = "wife", RelationshipType = "Family" }
          };

          people.ForEach(s => context.Persons.AddOrUpdate(p => p.Name, s));
          context.SaveChanges();

          int peterId = context.Persons.Where(c => c.Name == "Peter Smith").First().ID;
          int maryId = context.Persons.Where(c => c.Name == "Mary Smith").First().ID;

          var places = new List<Place> {
            new Place { Address = "Cronulla Beach, Sydney, Australia", UserID = user.Id ,Name = "Cronulla Beach" },
            new Place { Address = "103 Fake Street", Name = "Home", UserID = user.Id }
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
