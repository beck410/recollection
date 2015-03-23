namespace recollection.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class remove_image_requirement : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Images", "ImageLink", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Images", "ImageLink", c => c.String(nullable: false));
        }
    }
}
