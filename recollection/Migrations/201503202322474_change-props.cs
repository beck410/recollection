namespace recollection.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changeprops : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Images", "Person_ID", "dbo.People");
            DropForeignKey("dbo.Memories", "Person_ID", "dbo.People");
            DropForeignKey("dbo.Notes", "Person_ID", "dbo.People");
            DropForeignKey("dbo.Images", "Place_ID", "dbo.Places");
            DropForeignKey("dbo.Memories", "Place_ID", "dbo.Places");
            DropForeignKey("dbo.Notes", "Place_ID", "dbo.Places");
            DropIndex("dbo.Images", new[] { "Person_ID" });
            DropIndex("dbo.Images", new[] { "Place_ID" });
            DropIndex("dbo.Memories", new[] { "Person_ID" });
            DropIndex("dbo.Memories", new[] { "Place_ID" });
            DropIndex("dbo.Notes", new[] { "Person_ID" });
            DropIndex("dbo.Notes", new[] { "Place_ID" });
            RenameColumn(table: "dbo.Images", name: "Person_ID", newName: "PersonID");
            RenameColumn(table: "dbo.Memories", name: "Person_ID", newName: "PersonID");
            RenameColumn(table: "dbo.Notes", name: "Person_ID", newName: "PersonID");
            RenameColumn(table: "dbo.Images", name: "Place_ID", newName: "PlaceID");
            RenameColumn(table: "dbo.Memories", name: "Place_ID", newName: "PlaceID");
            RenameColumn(table: "dbo.Notes", name: "Place_ID", newName: "PlaceID");
            AlterColumn("dbo.Images", "PersonID", c => c.Int(nullable: false));
            AlterColumn("dbo.Images", "PlaceID", c => c.Int(nullable: false));
            AlterColumn("dbo.Memories", "PersonID", c => c.Int(nullable: false));
            AlterColumn("dbo.Memories", "PlaceID", c => c.Int(nullable: false));
            AlterColumn("dbo.Notes", "PersonID", c => c.Int(nullable: false));
            AlterColumn("dbo.Notes", "PlaceID", c => c.Int(nullable: false));
            CreateIndex("dbo.Images", "PersonID");
            CreateIndex("dbo.Images", "PlaceID");
            CreateIndex("dbo.Memories", "PersonID");
            CreateIndex("dbo.Memories", "PlaceID");
            CreateIndex("dbo.Notes", "PersonID");
            CreateIndex("dbo.Notes", "PlaceID");
            AddForeignKey("dbo.Images", "PersonID", "dbo.People", "ID", cascadeDelete: true);
            AddForeignKey("dbo.Memories", "PersonID", "dbo.People", "ID", cascadeDelete: true);
            AddForeignKey("dbo.Notes", "PersonID", "dbo.People", "ID", cascadeDelete: true);
            AddForeignKey("dbo.Images", "PlaceID", "dbo.Places", "ID", cascadeDelete: true);
            AddForeignKey("dbo.Memories", "PlaceID", "dbo.Places", "ID", cascadeDelete: true);
            AddForeignKey("dbo.Notes", "PlaceID", "dbo.Places", "ID", cascadeDelete: true);
            DropColumn("dbo.Images", "PersID");
            DropColumn("dbo.Images", "LocationID");
            DropColumn("dbo.Memories", "PersId");
            DropColumn("dbo.Memories", "LocationID");
            DropColumn("dbo.Notes", "PersId");
            DropColumn("dbo.Notes", "LocationID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Notes", "LocationID", c => c.Int(nullable: false));
            AddColumn("dbo.Notes", "PersId", c => c.Int(nullable: false));
            AddColumn("dbo.Memories", "LocationID", c => c.Int(nullable: false));
            AddColumn("dbo.Memories", "PersId", c => c.Int(nullable: false));
            AddColumn("dbo.Images", "LocationID", c => c.Int(nullable: false));
            AddColumn("dbo.Images", "PersID", c => c.Int(nullable: false));
            DropForeignKey("dbo.Notes", "PlaceID", "dbo.Places");
            DropForeignKey("dbo.Memories", "PlaceID", "dbo.Places");
            DropForeignKey("dbo.Images", "PlaceID", "dbo.Places");
            DropForeignKey("dbo.Notes", "PersonID", "dbo.People");
            DropForeignKey("dbo.Memories", "PersonID", "dbo.People");
            DropForeignKey("dbo.Images", "PersonID", "dbo.People");
            DropIndex("dbo.Notes", new[] { "PlaceID" });
            DropIndex("dbo.Notes", new[] { "PersonID" });
            DropIndex("dbo.Memories", new[] { "PlaceID" });
            DropIndex("dbo.Memories", new[] { "PersonID" });
            DropIndex("dbo.Images", new[] { "PlaceID" });
            DropIndex("dbo.Images", new[] { "PersonID" });
            AlterColumn("dbo.Notes", "PlaceID", c => c.Int());
            AlterColumn("dbo.Notes", "PersonID", c => c.Int());
            AlterColumn("dbo.Memories", "PlaceID", c => c.Int());
            AlterColumn("dbo.Memories", "PersonID", c => c.Int());
            AlterColumn("dbo.Images", "PlaceID", c => c.Int());
            AlterColumn("dbo.Images", "PersonID", c => c.Int());
            RenameColumn(table: "dbo.Notes", name: "PlaceID", newName: "Place_ID");
            RenameColumn(table: "dbo.Memories", name: "PlaceID", newName: "Place_ID");
            RenameColumn(table: "dbo.Images", name: "PlaceID", newName: "Place_ID");
            RenameColumn(table: "dbo.Notes", name: "PersonID", newName: "Person_ID");
            RenameColumn(table: "dbo.Memories", name: "PersonID", newName: "Person_ID");
            RenameColumn(table: "dbo.Images", name: "PersonID", newName: "Person_ID");
            CreateIndex("dbo.Notes", "Place_ID");
            CreateIndex("dbo.Notes", "Person_ID");
            CreateIndex("dbo.Memories", "Place_ID");
            CreateIndex("dbo.Memories", "Person_ID");
            CreateIndex("dbo.Images", "Place_ID");
            CreateIndex("dbo.Images", "Person_ID");
            AddForeignKey("dbo.Notes", "Place_ID", "dbo.Places", "ID");
            AddForeignKey("dbo.Memories", "Place_ID", "dbo.Places", "ID");
            AddForeignKey("dbo.Images", "Place_ID", "dbo.Places", "ID");
            AddForeignKey("dbo.Notes", "Person_ID", "dbo.People", "ID");
            AddForeignKey("dbo.Memories", "Person_ID", "dbo.People", "ID");
            AddForeignKey("dbo.Images", "Person_ID", "dbo.People", "ID");
        }
    }
}
