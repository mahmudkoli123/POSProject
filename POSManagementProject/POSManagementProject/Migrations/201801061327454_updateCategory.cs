namespace POSManagementProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateCategory : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.CategoryDTOes", "ParentCategoryId", "dbo.CategoryDTOes");
            DropIndex("dbo.CategoryDTOes", new[] { "ParentCategoryId" });
            DropColumn("dbo.CategoryDTOes", "ParentCategoryId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.CategoryDTOes", "ParentCategoryId", c => c.Int(nullable: false));
            CreateIndex("dbo.CategoryDTOes", "ParentCategoryId");
            AddForeignKey("dbo.CategoryDTOes", "ParentCategoryId", "dbo.CategoryDTOes", "Id");
        }
    }
}
