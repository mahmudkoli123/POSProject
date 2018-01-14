namespace POSManagementProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class itemAdd : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.CategoryDTOes", "ParentCategoryId", "dbo.CategoryDTOes");
            DropIndex("dbo.CategoryDTOes", new[] { "ParentCategoryId" });
            CreateTable(
                "dbo.Items",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Code = c.String(nullable: false),
                        Description = c.String(),
                        Image = c.Binary(),
                        CostPrice = c.Double(nullable: false),
                        SalePrice = c.Double(nullable: false),
                        Date = c.DateTime(nullable: false),
                        CategoryId = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ItemCategories", t => t.CategoryId, cascadeDelete: true)
                .Index(t => t.CategoryId);
            
            DropTable("dbo.CategoryDTOes");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.CategoryDTOes",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Name = c.String(),
                        Code = c.String(),
                        Description = c.String(),
                        ImageData = c.Binary(),
                        ParentCategoryId = c.Long(),
                    })
                .PrimaryKey(t => t.Id);
            
            DropForeignKey("dbo.Items", "CategoryId", "dbo.ItemCategories");
            DropIndex("dbo.Items", new[] { "CategoryId" });
            DropTable("dbo.Items");
            CreateIndex("dbo.CategoryDTOes", "ParentCategoryId");
            AddForeignKey("dbo.CategoryDTOes", "ParentCategoryId", "dbo.CategoryDTOes", "Id");
        }
    }
}
