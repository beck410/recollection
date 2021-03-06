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
            new Person { Name = "Peter Smith", UserID = userID, Birthday = new DateTime(1970, 05, 07), Address = "123 Fake Street", Phone = "1234567890", Relationship = "son", RelationshipType = "Family", MainImage = "http://www.culligan.com/images/Culligan_NewMan.png" },

            new Person { Name = "Mary Smith", UserID = userID, Birthday = new DateTime(1950, 05, 07), Address = "103 Fake Street", Phone = "1234567890", Relationship = "wife", RelationshipType = "Family", MainImage = "http://slodive.com/wp-content/uploads/2013/04/short-hair-styles-for-older-women/cheerful-old-woman.jpg " },

            new Person { Name = "Alex Porter", UserID = userID, Birthday = new DateTime(1958, 05, 07), Address = "107 Fake Street", Phone = "5869385746", Relationship = "neighbor", RelationshipType = "Friends", MainImage = "http://i.telegraph.co.uk/multimedia/archive/01446/joan-bakewell_1446106c.jpg" },

            new Person { Name = "Lenny Porter", UserID = userID, Birthday = new DateTime(1958, 03, 08), Address = "107 Fake Street", Phone = "5869385746", Relationship = "neighbor", RelationshipType = "Friends", MainImage = "http://richmonkey.co.uk/Older%20man%201.jpg"},

            new Person { Name = "Denise Powell", UserID = userID, Birthday = new DateTime(1981, 05, 07), Address = "131 Cherry lane", Phone = "5864785746", Relationship = "Accountant", RelationshipType = "Business", MainImage = "http://rack.2.mshcdn.com/media/ZgkyMDEyLzEyLzA0LzFiL29uZXdvbWFuc3F1LmRBVS5qcGcKcAl0aHVtYgk5NTB4NTM0IwplCWpwZw/b3b3bbf3/5ed/one-woman-s-quest-to-change-the-ratio-in-tech-ee359104d9.jpg" },

            new Person { Name = "Ken Robson", UserID = userID, Birthday = new DateTime(1966, 03, 08), Address = "172 Lodge Street", Phone = "5857385746", Relationship = "Electrician", RelationshipType = "Business", MainImage = "http://static3.businessinsider.com/image/52b235196bb3f776493e69dd/north-dakota-says-man-in-same-sex-marriage-can-also-marry-a-woman.jpg"},

            new Person { Name = "Sheila Thompson", UserID = userID, Birthday = new DateTime(1953, 03, 08), Address = "191 Lodge Street", Phone = "5857384746", Relationship = "Respite Nurse", RelationshipType = "Other", MainImage = "http://blogcdn.nursingjobs.us/wp-content/uploads/2012/05/goodluz.jpg"},           
          };

          people.ForEach(s => context.Persons.AddOrUpdate(p => p.Name, s));
          context.SaveChanges();

          int peterId = context.Persons.Where(c => c.Name == "Peter Smith").First().ID;
          int maryId = context.Persons.Where(c => c.Name == "Mary Smith").First().ID;

          var places = new List<Place> {
            new Place { Address = "Cronulla Beach, Sydney, Australia", UserID = userID ,Name = "Cronulla Beach", MainImage = "http://media-cdn.tripadvisor.com/media/photo-s/02/50/f2/a4/south-cronulla-beach.jpg" },

            new Place { Address = "103 Fake Street", Name = "Home", UserID = userID, MainImage = "http://www.burkhartinsurance.com/wp-content/uploads/2011/12/home1.jpg" },

            new Place { Address = "109 Fake Street", Name = "Peter's Home", UserID = userID, MainImage = "http://www.goodwinhouse.org/wp/wp-content/uploads/2012/08/certified-home-inspection-company.jpg" },

            new Place { Address = "117 Jenner Parade", Name = "Whole Foods", UserID = userID, MainImage = "http://www.gaiahealthblog.com/wordpress1/wp-content/uploads/2013/08/whole-foods1.jpg" },

            new Place { Address = "10 Bowling Lane", Name = "Nashville Lawn Bowls Club", UserID = userID, MainImage = "http://2.bp.blogspot.com/-QOgyf1ByQcQ/UZDw6TNopZI/AAAAAAAADZ0/pJztBOa7wyw/s1600/beac2006.jpg" }
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

          var images = new List<Image> {
            new Image { PersID = peterId, ImageLink = "http://www.stylishboard.com/wp-content/uploads/2013/07/baby-boy-check-shirts.jpg", DateOfImage = new DateTime(1981,4,7), Caption = "Peter before his christening" },                                    
            new Image { PersID = peterId, ImageLink = "http://www.bhmpics.com/walls/my_baby_boy-other.jpg", DateOfImage = new DateTime(1985,7,7), Caption = "first baseball game" },  
 
            new Image { PersID = peterId, ImageLink = "http://www.wrangler.com/WRG_STORE_US/assets/department/2012_boy_top_none_boy-bball.jpg", DateOfImage = new DateTime(1987,6,1), Caption = "playing basketball" },

            new Image { PersID = peterId, ImageLink = "http://www.playbillsvspayingbills.com/wp-content/uploads/2010/10/kick.jpg", DateOfImage = new DateTime(1986,6,1), Caption = "first game of soccer" },

            new Image { PersID = peterId, ImageLink = "http://blogs.record-eagle.com/wp-content/uploads/2012/06/father-son-picblk-wht-2.jpg", DateOfImage = new DateTime(1984,6,1), Caption = "camping trip in Florida" },

            new Image { PersID = peterId, ImageLink = "http://soughtoutglobal.com/wp-content/uploads/2014/05/father_son_beach-580x397.jpg", DateOfImage = new DateTime(1984,6,1), Caption = "camping trip in Florida" }
          };

          images.ForEach(s => context.Images.AddOrUpdate(c => c.ImageLink, s));
        }
    }
}
