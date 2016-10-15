namespace Blog.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateTableBaseOnDomailModel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        CategoryId = c.Int(nullable: false, identity: true),
                        CategoryDescription = c.String(nullable: false, maxLength: 50),
                        Remark = c.String(nullable: false, maxLength: 50),
                        FeatureImage = c.String(unicode: false),
                    })
                .PrimaryKey(t => t.CategoryId);
            
            CreateTable(
                "dbo.Posts",
                c => new
                    {
                        PostId = c.Int(nullable: false, identity: true),
                        PostTitle = c.String(nullable: false, maxLength: 50),
                        PostDate = c.DateTime(nullable: false),
                        OwnerId = c.Int(nullable: false),
                        PostStatusId = c.Int(nullable: false),
                        CategoryId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.PostId)
                .ForeignKey("dbo.Categories", t => t.CategoryId, cascadeDelete: true)
                .ForeignKey("dbo.PostStatus", t => t.PostStatusId, cascadeDelete: true)
                .Index(t => t.PostStatusId)
                .Index(t => t.CategoryId);
            
            CreateTable(
                "dbo.PostDetails",
                c => new
                    {
                        PostId = c.Int(nullable: false),
                        PostDetailId = c.Int(nullable: false),
                        PostDescription = c.String(nullable: false, unicode: false),
                        FeatureImage = c.String(unicode: false),
                        Video = c.String(unicode: false),
                        ViewCount = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.PostId)
                .ForeignKey("dbo.Posts", t => t.PostId)
                .Index(t => t.PostId);
            
            CreateTable(
                "dbo.PostStatus",
                c => new
                    {
                        PostStatusId = c.Int(nullable: false, identity: true),
                        Status = c.String(maxLength: 50),
                        Remark = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.PostStatusId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Posts", "PostStatusId", "dbo.PostStatus");
            DropForeignKey("dbo.PostDetails", "PostId", "dbo.Posts");
            DropForeignKey("dbo.Posts", "CategoryId", "dbo.Categories");
            DropIndex("dbo.PostDetails", new[] { "PostId" });
            DropIndex("dbo.Posts", new[] { "CategoryId" });
            DropIndex("dbo.Posts", new[] { "PostStatusId" });
            DropTable("dbo.PostStatus");
            DropTable("dbo.PostDetails");
            DropTable("dbo.Posts");
            DropTable("dbo.Categories");
        }
    }
}
