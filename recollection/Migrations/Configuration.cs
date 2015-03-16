namespace recollection.Migrations
{
  using recollection.Models;
  using System;
  using System.Data.Entity;
  using System.Data.Entity.Migrations;
  using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<recollection.Context.recollectionContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(recollection.Context.recollectionContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //

          context.Persons.AddOrUpdate(
            p => p.UserID,
            new Person { Name = "Peter Smith", UserID = "c3er4",  RelationshipType="Family" }
          );
        }
    }
}
