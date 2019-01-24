namespace Keeper.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TaskCollections : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Worklogs", newName: "TaskWorklogs");
        }
        
        public override void Down()
        {
            RenameTable(name: "dbo.TaskWorklogs", newName: "Worklogs");
        }
    }
}
