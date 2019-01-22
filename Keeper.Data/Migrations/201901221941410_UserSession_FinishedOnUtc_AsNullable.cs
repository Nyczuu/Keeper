namespace Keeper.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UserSession_FinishedOnUtc_AsNullable : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.UserSessions", "FinishedOnUtc", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.UserSessions", "FinishedOnUtc", c => c.DateTime(nullable: false));
        }
    }
}
