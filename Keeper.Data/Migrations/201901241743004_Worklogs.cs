namespace Keeper.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Worklogs : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Worklogs",
                c => new
                    {
                        Identifier = c.Int(nullable: false, identity: true),
                        UserIdentifier = c.Int(nullable: false),
                        TaskIdentifier = c.Int(nullable: false),
                        FinishedOnUtc = c.DateTime(nullable: false),
                        CreatedOnUtc = c.DateTime(nullable: false),
                        UpdatedOnUtc = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Identifier)
                .ForeignKey("dbo.Tasks", t => t.TaskIdentifier, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.UserIdentifier, cascadeDelete: true)
                .Index(t => t.UserIdentifier)
                .Index(t => t.TaskIdentifier);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Worklogs", "UserIdentifier", "dbo.Users");
            DropForeignKey("dbo.Worklogs", "TaskIdentifier", "dbo.Tasks");
            DropIndex("dbo.Worklogs", new[] { "TaskIdentifier" });
            DropIndex("dbo.Worklogs", new[] { "UserIdentifier" });
            DropTable("dbo.Worklogs");
        }
    }
}
