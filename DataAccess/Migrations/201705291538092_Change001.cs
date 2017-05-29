namespace DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Change001 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.attachments",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DocumentId = c.Int(),
                        FileName = c.String(unicode: false),
                        Description = c.String(unicode: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.documents", t => t.DocumentId)
                .Index(t => t.DocumentId);
            
            CreateTable(
                "dbo.documents",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CategoryId = c.Int(),
                        UserId = c.Int(),
                        Title = c.String(unicode: false),
                        Content = c.String(unicode: false),
                        CreatedDate = c.DateTime(nullable: false, precision: 0),
                        UpdatedDate = c.DateTime(nullable: false, precision: 0),
                        IsPublic = c.Boolean(nullable: false),
                        IsActive = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.galeries",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DocumentId = c.Int(),
                        FileName = c.String(unicode: false),
                        Description = c.String(unicode: false),
                        Order = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.documents", t => t.DocumentId)
                .Index(t => t.DocumentId);
            
            CreateTable(
                "dbo.categories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ParentCategoryId = c.Int(),
                        Name = c.String(unicode: false),
                        Order = c.Int(),
                        IsPublic = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.categories", t => t.ParentCategoryId)
                .Index(t => t.ParentCategoryId);
            
            CreateTable(
                "dbo.users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50, unicode: false),
                        Email = c.String(nullable: false, maxLength: 100, unicode: false),
                        Password = c.String(nullable: false, maxLength: 100, unicode: false),
                        IsActive = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.categories", "ParentCategoryId", "dbo.categories");
            DropForeignKey("dbo.galeries", "DocumentId", "dbo.documents");
            DropForeignKey("dbo.attachments", "DocumentId", "dbo.documents");
            DropIndex("dbo.categories", new[] { "ParentCategoryId" });
            DropIndex("dbo.galeries", new[] { "DocumentId" });
            DropIndex("dbo.attachments", new[] { "DocumentId" });
            DropTable("dbo.users");
            DropTable("dbo.categories");
            DropTable("dbo.galeries");
            DropTable("dbo.documents");
            DropTable("dbo.attachments");
        }
    }
}
