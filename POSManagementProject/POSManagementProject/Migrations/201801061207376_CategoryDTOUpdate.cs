namespace POSManagementProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CategoryDTOUpdate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CategoryDTOes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Code = c.String(),
                        Description = c.String(),
                        ImageData = c.Binary(),
                        ParentCategoryId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.CategoryDTOes", t => t.ParentCategoryId)
                .Index(t => t.ParentCategoryId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.CategoryDTOes", "ParentCategoryId", "dbo.CategoryDTOes");
            DropIndex("dbo.CategoryDTOes", new[] { "ParentCategoryId" });
            DropTable("dbo.CategoryDTOes");
        }
    }
}
