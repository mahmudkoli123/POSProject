namespace POSManagementProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class listAdd : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.CategoryDTOes");
            AddColumn("dbo.CategoryDTOes", "ParentCategoryId", c => c.Long());
            AlterColumn("dbo.CategoryDTOes", "Id", c => c.Long(nullable: false, identity: true));
            AddPrimaryKey("dbo.CategoryDTOes", "Id");
            CreateIndex("dbo.CategoryDTOes", "ParentCategoryId");
            AddForeignKey("dbo.CategoryDTOes", "ParentCategoryId", "dbo.CategoryDTOes", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.CategoryDTOes", "ParentCategoryId", "dbo.CategoryDTOes");
            DropIndex("dbo.CategoryDTOes", new[] { "ParentCategoryId" });
            DropPrimaryKey("dbo.CategoryDTOes");
            AlterColumn("dbo.CategoryDTOes", "Id", c => c.Int(nullable: false, identity: true));
            DropColumn("dbo.CategoryDTOes", "ParentCategoryId");
            AddPrimaryKey("dbo.CategoryDTOes", "Id");
        }
    }
}
