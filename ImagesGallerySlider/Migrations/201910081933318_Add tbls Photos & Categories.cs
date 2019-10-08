namespace ImagesGallerySlider.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddtblsPhotosCategories : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        IdCategory = c.Int(nullable: false, identity: true),
                        NameOfCategory = c.String(),
                    })
                .PrimaryKey(t => t.IdCategory);
            
            CreateTable(
                "dbo.Photos",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FileName = c.String(nullable: false, maxLength: 100),
                        Сaption = c.String(nullable: false, maxLength: 100),
                        IdCategory = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Categories", t => t.IdCategory)
                .Index(t => t.IdCategory);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Photos", "IdCategory", "dbo.Categories");
            DropIndex("dbo.Photos", new[] { "IdCategory" });
            DropTable("dbo.Photos");
            DropTable("dbo.Categories");
        }
    }
}
