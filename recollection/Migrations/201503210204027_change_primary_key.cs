namespace recollection.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class change_primary_key : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Images", "PersonID", "dbo.People");
            DropForeignKey("dbo.Memories", "PersonID", "dbo.People");
            DropForeignKey("dbo.Notes", "PersonID", "dbo.People");
            DropForeignKey("dbo.Images", "PlaceID", "dbo.Places");
            DropForeignKey("dbo.Memories", "PlaceID", "dbo.Places");
            DropForeignKey("dbo.Notes", "PlaceID", "dbo.Places");
            DropPrimaryKey("dbo.People");
            DropPrimaryKey("dbo.Places");
            DropColumn("dbo.People", "ID");
            DropColumn("dbo.Places", "ID");
            AddColumn("dbo.People", "PersonID", c => c.Int(nullable: false, identity: true));
            AddColumn("dbo.Places", "PlaceID", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.People", "PersonID");
            AddPrimaryKey("dbo.Places", "PlaceID");
            AddForeignKey("dbo.Images", "PersonID", "dbo.People", "PersonID", cascadeDelete: true);
            AddForeignKey("dbo.Memories", "PersonID", "dbo.People", "PersonID", cascadeDelete: true);
            AddForeignKey("dbo.Notes", "PersonID", "dbo.People", "PersonID", cascadeDelete: true);
            AddForeignKey("dbo.Images", "PlaceID", "dbo.Places", "PlaceID", cascadeDelete: true);
            AddForeignKey("dbo.Memories", "PlaceID", "dbo.Places", "PlaceID", cascadeDelete: true);
            AddForeignKey("dbo.Notes", "PlaceID", "dbo.Places", "PlaceID", cascadeDelete: true);

        }
        
        public override void Down()
        {
            AddColumn("dbo.Places", "ID", c => c.Int(nullable: false, identity: true));
            AddColumn("dbo.People", "ID", c => c.Int(nullable: false, identity: true));
            DropForeignKey("dbo.Notes", "PlaceID", "dbo.Places");
            DropForeignKey("dbo.Memories", "PlaceID", "dbo.Places");
            DropForeignKey("dbo.Images", "PlaceID", "dbo.Places");
            DropForeignKey("dbo.Notes", "PersonID", "dbo.People");
            DropForeignKey("dbo.Memories", "PersonID", "dbo.People");
            DropForeignKey("dbo.Images", "PersonID", "dbo.People");
            DropPrimaryKey("dbo.Places");
            DropPrimaryKey("dbo.People");
            DropColumn("dbo.Places", "PlaceID");
            DropColumn("dbo.People", "PersonID");
            AddPrimaryKey("dbo.Places", "ID");
            AddPrimaryKey("dbo.People", "ID");
            AddForeignKey("dbo.Notes", "PlaceID", "dbo.Places", "PlaceID", cascadeDelete: true);
            AddForeignKey("dbo.Memories", "PlaceID", "dbo.Places", "PlaceID", cascadeDelete: true);
            AddForeignKey("dbo.Images", "PlaceID", "dbo.Places", "PlaceID", cascadeDelete: true);
            AddForeignKey("dbo.Notes", "PersonID", "dbo.People", "PersonID", cascadeDelete: true);
            AddForeignKey("dbo.Memories", "PersonID", "dbo.People", "PersonID", cascadeDelete: true);
            AddForeignKey("dbo.Images", "PersonID", "dbo.People", "PersonID", cascadeDelete: true);
        }
    }
}
