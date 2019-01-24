namespace Keeper.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class WorklogsFinishedDateNullable : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Worklogs", "FinishedOnUtc", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Worklogs", "FinishedOnUtc", c => c.DateTime(nullable: false));
        }
    }
}
