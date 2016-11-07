namespace KariyerPortali.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Cvs",
                c => new
                    {
                        CvId = c.Int(nullable: false, identity: true),
                        CvName = c.String(nullable: false, maxLength: 200),
                    })
                .PrimaryKey(t => t.CvId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Cvs");
        }
    }
}
