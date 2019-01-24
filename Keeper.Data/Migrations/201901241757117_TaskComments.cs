namespace Keeper.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TaskComments : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.TaskComments",
                c => new
                    {
                        Identifier = c.Int(nullable: false, identity: true),
                        Content = c.String(),
                        TaskIdentifier = c.Int(nullable: false),
                        UserIdentifier = c.Int(nullable: false),
                        CreatedOnUtc = c.DateTime(nullable: false),
                        UpdatedOnUtc = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Identifier)
                .ForeignKey("dbo.Tasks", t => t.TaskIdentifier, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.UserIdentifier, cascadeDelete: true)
                .Index(t => t.TaskIdentifier)
                .Index(t => t.UserIdentifier);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TaskComments", "UserIdentifier", "dbo.Users");
            DropForeignKey("dbo.TaskComments", "TaskIdentifier", "dbo.Tasks");
            DropIndex("dbo.TaskComments", new[] { "UserIdentifier" });
            DropIndex("dbo.TaskComments", new[] { "TaskIdentifier" });
            DropTable("dbo.TaskComments");
        }
    }
}
