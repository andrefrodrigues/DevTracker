namespace DevTracker.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class newEntities : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Lang_Paradigm",
                c => new
                    {
                        langName = c.String(nullable: false, maxLength: 128),
                        paradID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.langName, t.paradID })
                .ForeignKey("dbo.Languages", t => t.langName, cascadeDelete: true)
                .ForeignKey("dbo.Paradigms", t => t.paradID, cascadeDelete: true)
                .Index(t => t.langName)
                .Index(t => t.paradID);
            
            CreateTable(
                "dbo.Languages",
                c => new
                    {
                        name = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.name);
            
            CreateTable(
                "dbo.Paradigms",
                c => new
                    {
                        paradigm_id = c.Int(nullable: false, identity: true),
                        name = c.String(),
                    })
                .PrimaryKey(t => t.paradigm_id);
            
            CreateTable(
                "dbo.User_Lang",
                c => new
                    {
                        userID = c.String(nullable: false, maxLength: 128),
                        langName = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.userID, t.langName })
                .ForeignKey("dbo.Languages", t => t.langName, cascadeDelete: true)
                .ForeignKey("dbo.User", t => t.userID, cascadeDelete: true)
                .Index(t => t.userID)
                .Index(t => t.langName);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.User_Lang", "userID", "dbo.User");
            DropForeignKey("dbo.User_Lang", "langName", "dbo.Languages");
            DropForeignKey("dbo.Lang_Paradigm", "paradID", "dbo.Paradigms");
            DropForeignKey("dbo.Lang_Paradigm", "langName", "dbo.Languages");
            DropIndex("dbo.User_Lang", new[] { "langName" });
            DropIndex("dbo.User_Lang", new[] { "userID" });
            DropIndex("dbo.Lang_Paradigm", new[] { "paradID" });
            DropIndex("dbo.Lang_Paradigm", new[] { "langName" });
            DropTable("dbo.User_Lang");
            DropTable("dbo.Paradigms");
            DropTable("dbo.Languages");
            DropTable("dbo.Lang_Paradigm");
        }
    }
}
