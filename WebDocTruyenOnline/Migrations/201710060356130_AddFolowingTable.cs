namespace WebDocTruyenOnline.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddFolowingTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Folowings",
                c => new
                    {
                        StoryId = c.Long(nullable: false),
                        FolowerId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.StoryId, t.FolowerId })
                .ForeignKey("dbo.AspNetUsers", t => t.FolowerId)
                .ForeignKey("dbo.Story", t => t.StoryId)
                .Index(t => t.StoryId)
                .Index(t => t.FolowerId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Folowings", "StoryId", "dbo.Story");
            DropForeignKey("dbo.Folowings", "FolowerId", "dbo.AspNetUsers");
            DropIndex("dbo.Folowings", new[] { "FolowerId" });
            DropIndex("dbo.Folowings", new[] { "StoryId" });
            DropTable("dbo.Folowings");
        }
    }
}
