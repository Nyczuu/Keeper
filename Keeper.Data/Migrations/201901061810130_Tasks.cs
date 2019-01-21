namespace Keeper.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Tasks : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Tasks",
                c => new
                    {
                        Identifier = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Description = c.String(),
                        ProjectIdentifier = c.Int(nullable: false),
                        Status = c.Int(nullable: false),
                        CreatedOnUtc = c.DateTime(nullable: false),
                        UpdatedOnUtc = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Identifier)
                .ForeignKey("dbo.Projects", t => t.ProjectIdentifier, cascadeDelete: true)
                .Index(t => t.ProjectIdentifier);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Tasks", "ProjectIdentifier", "dbo.Projects");
            DropIndex("dbo.Tasks", new[] { "ProjectIdentifier" });
            DropTable("dbo.Tasks");
        }
    }
}
