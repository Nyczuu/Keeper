namespace Keeper.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ProjectUser_Relationship : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.UserProjects",
                c => new
                    {
                        User_Identifier = c.Int(nullable: false),
                        Project_Identifier = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.User_Identifier, t.Project_Identifier })
                .ForeignKey("dbo.Users", t => t.User_Identifier, cascadeDelete: true)
                .ForeignKey("dbo.Projects", t => t.Project_Identifier, cascadeDelete: true)
                .Index(t => t.User_Identifier)
                .Index(t => t.Project_Identifier);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UserProjects", "Project_Identifier", "dbo.Projects");
            DropForeignKey("dbo.UserProjects", "User_Identifier", "dbo.Users");
            DropIndex("dbo.UserProjects", new[] { "Project_Identifier" });
            DropIndex("dbo.UserProjects", new[] { "User_Identifier" });
            DropTable("dbo.UserProjects");
        }
    }
}
