namespace KariyerPortali.Admin.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AlanlarMig : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "Title", c => c.String());
            AddColumn("dbo.AspNetUsers", "ImagePath", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "ImagePath");
            DropColumn("dbo.AspNetUsers", "Title");
        }
    }
}
