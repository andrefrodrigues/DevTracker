namespace DevTracker.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class adminRights : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.User", "admin", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.User", "admin");
        }
    }
}
