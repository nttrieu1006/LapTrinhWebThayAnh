namespace WebDocTruyenOnline.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialDatabase : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.About",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Name = c.String(maxLength: 250),
                        MetaTitle = c.String(maxLength: 250, unicode: false),
                        Detail = c.String(storeType: "ntext"),
                        CreateDate = c.DateTime(nullable: false),
                        CreateBy = c.String(maxLength: 250, unicode: false),
                        ModifyDate = c.DateTime(),
                        ModifyBy = c.String(maxLength: 250, unicode: false),
                        Status = c.Boolean(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Author",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 250),
                        MetaTitle = c.String(maxLength: 250, unicode: false),
                        DisplayOrder = c.Int(),
                        CreateDate = c.DateTime(nullable: false),
                        CreateBy = c.String(maxLength: 250, unicode: false),
                        ModifyDate = c.DateTime(),
                        ModifyBy = c.String(maxLength: 250, unicode: false),
                        Status = c.Boolean(nullable: false),
                        ShowOnHome = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Story",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 250),
                        MetaTitle = c.String(maxLength: 250, unicode: false),
                        Descirption = c.String(storeType: "ntext"),
                        AuthorId = c.Long(),
                        TypeId = c.Long(),
                        CategoryId = c.Long(),
                        Image = c.String(maxLength: 250),
                        CreateDate = c.DateTime(nullable: false),
                        CreateBy = c.String(maxLength: 250, unicode: false),
                        ModifyDate = c.DateTime(),
                        ModifyBy = c.String(maxLength: 250, unicode: false),
                        Status = c.Boolean(nullable: false),
                        Views = c.Int(nullable: false),
                        TopHot = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Author", t => t.AuthorId)
                .ForeignKey("dbo.StoryCategory", t => t.CategoryId)
                .ForeignKey("dbo.StoryType", t => t.TypeId)
                .Index(t => t.AuthorId)
                .Index(t => t.TypeId)
                .Index(t => t.CategoryId);
            
            CreateTable(
                "dbo.ChapStory",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        StoryId = c.Long(),
                        Chap = c.Int(nullable: false),
                        MetaTitle = c.String(maxLength: 250, fixedLength: true),
                        Content = c.String(storeType: "ntext"),
                        CreateDate = c.DateTime(nullable: false),
                        CreateBy = c.String(maxLength: 250, unicode: false),
                        ModifyDate = c.DateTime(),
                        ModifyBy = c.String(maxLength: 250, unicode: false),
                        Status = c.Boolean(nullable: false),
                        ChapName = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Story", t => t.StoryId)
                .Index(t => t.StoryId);
            
            CreateTable(
                "dbo.StoryCategory",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 250),
                        MetaTitle = c.String(maxLength: 250, unicode: false),
                        DisplayOrder = c.Int(),
                        CreateDate = c.DateTime(nullable: false),
                        CreateBy = c.String(maxLength: 250, unicode: false),
                        ModifyDate = c.DateTime(),
                        ModifyBy = c.String(maxLength: 250, unicode: false),
                        Status = c.Boolean(nullable: false),
                        ShowOnHome = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.StoryType",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 250),
                        MetaTitle = c.String(maxLength: 250, unicode: false),
                        DisplayOrder = c.Int(),
                        CreateDate = c.DateTime(),
                        CreateBy = c.String(maxLength: 250, unicode: false),
                        ModifyDate = c.DateTime(),
                        ModifyBy = c.String(maxLength: 250, unicode: false),
                        Status = c.Boolean(nullable: false),
                        ShowOnHome = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Contact",
                c => new
                    {
                        ID = c.Long(nullable: false, identity: true),
                        Content = c.String(storeType: "ntext"),
                        Status = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Feedback",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Name = c.String(maxLength: 250),
                        Phone = c.String(maxLength: 50),
                        Email = c.String(maxLength: 50),
                        Address = c.String(maxLength: 50),
                        Content = c.String(maxLength: 250),
                        CreateDate = c.DateTime(nullable: false),
                        Status = c.Boolean(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Footer",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 50, unicode: false),
                        Content = c.String(storeType: "ntext"),
                        Status = c.Boolean(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Menu",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Text = c.String(maxLength: 50),
                        Link = c.String(maxLength: 50),
                        DisplayOrder = c.Int(),
                        Target = c.String(maxLength: 50),
                        Status = c.Boolean(),
                        TypeId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.MenuType", t => t.TypeId)
                .Index(t => t.TypeId);
            
            CreateTable(
                "dbo.MenuType",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 250),
                    })
                .PrimaryKey(t => t.Id);
            
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
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.Slide",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Image = c.String(maxLength: 250),
                        DisplayOrder = c.Int(),
                        Link = c.String(maxLength: 250),
                        Description = c.String(maxLength: 50),
                        CreateDate = c.DateTime(nullable: false),
                        CreateBy = c.String(maxLength: 250, unicode: false),
                        ModifyDate = c.DateTime(),
                        ModifyBy = c.String(maxLength: 250, unicode: false),
                        Status = c.String(maxLength: 10, fixedLength: true),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        FullName = c.String(),
                        Address = c.String(),
                        Avartar = c.String(),
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
                .ForeignKey("dbo.AspNetUsers", t => t.UserId)
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
                .ForeignKey("dbo.AspNetUsers", t => t.UserId)
                .Index(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.Menu", "TypeId", "dbo.MenuType");
            DropForeignKey("dbo.Story", "TypeId", "dbo.StoryType");
            DropForeignKey("dbo.Story", "CategoryId", "dbo.StoryCategory");
            DropForeignKey("dbo.ChapStory", "StoryId", "dbo.Story");
            DropForeignKey("dbo.Story", "AuthorId", "dbo.Author");
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.Menu", new[] { "TypeId" });
            DropIndex("dbo.ChapStory", new[] { "StoryId" });
            DropIndex("dbo.Story", new[] { "CategoryId" });
            DropIndex("dbo.Story", new[] { "TypeId" });
            DropIndex("dbo.Story", new[] { "AuthorId" });
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.Slide");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.MenuType");
            DropTable("dbo.Menu");
            DropTable("dbo.Footer");
            DropTable("dbo.Feedback");
            DropTable("dbo.Contact");
            DropTable("dbo.StoryType");
            DropTable("dbo.StoryCategory");
            DropTable("dbo.ChapStory");
            DropTable("dbo.Story");
            DropTable("dbo.Author");
            DropTable("dbo.About");
        }
    }
}
