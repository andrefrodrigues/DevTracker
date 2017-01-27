namespace DevTracker.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class praying : DbMigration
    {
        public override void Up()
        {
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
                        paradigmId = c.Int(nullable: false, identity: true),
                        name = c.String(),
                    })
                .PrimaryKey(t => t.paradigmId);
            
            CreateTable(
                "dbo.User",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        admin = c.Boolean(nullable: false),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.User", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.User", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.User", t => t.UserId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
            CreateTable(
                "dbo.ParadigmLanguages",
                c => new
                    {
                        Paradigm_paradigmId = c.Int(nullable: false),
                        Language_name = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.Paradigm_paradigmId, t.Language_name })
                .ForeignKey("dbo.Paradigms", t => t.Paradigm_paradigmId, cascadeDelete: true)
                .ForeignKey("dbo.Languages", t => t.Language_name, cascadeDelete: true)
                .Index(t => t.Paradigm_paradigmId)
                .Index(t => t.Language_name);
            
            CreateTable(
                "dbo.ApplicationUserLanguages",
                c => new
                    {
                        ApplicationUser_Id = c.String(nullable: false, maxLength: 128),
                        Language_name = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.ApplicationUser_Id, t.Language_name })
                .ForeignKey("dbo.User", t => t.ApplicationUser_Id, cascadeDelete: true)
                .ForeignKey("dbo.Languages", t => t.Language_name, cascadeDelete: true)
                .Index(t => t.ApplicationUser_Id)
                .Index(t => t.Language_name);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.User");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.User");
            DropForeignKey("dbo.ApplicationUserLanguages", "Language_name", "dbo.Languages");
            DropForeignKey("dbo.ApplicationUserLanguages", "ApplicationUser_Id", "dbo.User");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.User");
            DropForeignKey("dbo.ParadigmLanguages", "Language_name", "dbo.Languages");
            DropForeignKey("dbo.ParadigmLanguages", "Paradigm_paradigmId", "dbo.Paradigms");
            DropIndex("dbo.ApplicationUserLanguages", new[] { "Language_name" });
            DropIndex("dbo.ApplicationUserLanguages", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.ParadigmLanguages", new[] { "Language_name" });
            DropIndex("dbo.ParadigmLanguages", new[] { "Paradigm_paradigmId" });
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.User", "UserNameIndex");
            DropTable("dbo.ApplicationUserLanguages");
            DropTable("dbo.ParadigmLanguages");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.User");
            DropTable("dbo.Paradigms");
            DropTable("dbo.Languages");
        }
    }
}
