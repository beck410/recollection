namespace recollection.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mainimagekey : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.People", "MainImage", c => c.String());
            AddColumn("dbo.Places", "MainImage", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Places", "MainImage");
            DropColumn("dbo.People", "MainImage");
        }
    }
}
