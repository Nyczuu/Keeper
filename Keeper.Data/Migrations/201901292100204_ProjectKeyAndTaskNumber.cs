namespace Keeper.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ProjectKeyAndTaskNumber : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Projects", "Key", c => c.String());
            AddColumn("dbo.Projects", "TasksCreatedTotal", c => c.Int(nullable: false));
            AddColumn("dbo.Tasks", "Number", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Tasks", "Number");
            DropColumn("dbo.Projects", "TasksCreatedTotal");
            DropColumn("dbo.Projects", "Key");
        }
    }
}
