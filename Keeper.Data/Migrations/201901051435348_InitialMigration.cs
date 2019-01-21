namespace Keeper.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Projects",
                c => new
                    {
                        Identifier = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        CreatedOnUtc = c.DateTime(nullable: false),
                        UpdatedOnUtc = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Identifier);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Identifier = c.Int(nullable: false, identity: true),
                        Email = c.String(),
                        Password = c.String(),
                        GroupType = c.Int(nullable: false),
                        CreatedOnUtc = c.DateTime(nullable: false),
                        UpdatedOnUtc = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Identifier);
            
            CreateTable(
                "dbo.UserSessions",
                c => new
                    {
                        Identifier = c.Int(nullable: false, identity: true),
                        UserId = c.Int(nullable: false),
                        SessionId = c.Guid(nullable: false),
                        FinishedOnUtc = c.DateTime(nullable: false),
                        CreatedOnUtc = c.DateTime(nullable: false),
                        UpdatedOnUtc = c.DateTime(nullable: false),
                        User_Identifier = c.Int(),
                    })
                .PrimaryKey(t => t.Identifier)
                .ForeignKey("dbo.Users", t => t.User_Identifier)
                .Index(t => t.User_Identifier);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UserSessions", "User_Identifier", "dbo.Users");
            DropIndex("dbo.UserSessions", new[] { "User_Identifier" });
            DropTable("dbo.UserSessions");
            DropTable("dbo.Users");
            DropTable("dbo.Projects");
        }
    }
}
