namespace Keeper.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreatorIdentifier : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Projects", "CreatorIdentifier", c => c.Int(nullable: false));
            AddColumn("dbo.Tasks", "CreatorIdentifier", c => c.Int(nullable: false));
            AddColumn("dbo.Tasks", "AssigneeIdentifier", c => c.Int());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Tasks", "AssigneeIdentifier");
            DropColumn("dbo.Tasks", "CreatorIdentifier");
            DropColumn("dbo.Projects", "CreatorIdentifier");
        }
    }
}
