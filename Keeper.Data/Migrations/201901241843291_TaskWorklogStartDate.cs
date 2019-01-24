namespace Keeper.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TaskWorklogStartDate : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.TaskWorklogs", "StartDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.TaskWorklogs", "FinishDate", c => c.DateTime());
            DropColumn("dbo.TaskWorklogs", "FinishedOnUtc");
        }
        
        public override void Down()
        {
            AddColumn("dbo.TaskWorklogs", "FinishedOnUtc", c => c.DateTime());
            DropColumn("dbo.TaskWorklogs", "FinishDate");
            DropColumn("dbo.TaskWorklogs", "StartDate");
        }
    }
}
