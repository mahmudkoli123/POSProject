namespace POSManagementProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class expenseAdd : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ExpenseCategories",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Code = c.String(nullable: false),
                        Description = c.String(),
                        Date = c.DateTime(nullable: false),
                        ParentId = c.Long(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ExpenseCategories", t => t.ParentId)
                .Index(t => t.ParentId);
            
            CreateTable(
                "dbo.ExpenseItems",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Code = c.String(nullable: false),
                        Description = c.String(),
                        Date = c.DateTime(nullable: false),
                        CategoryId = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ExpenseCategories", t => t.CategoryId, cascadeDelete: true)
                .Index(t => t.CategoryId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ExpenseItems", "CategoryId", "dbo.ExpenseCategories");
            DropForeignKey("dbo.ExpenseCategories", "ParentId", "dbo.ExpenseCategories");
            DropIndex("dbo.ExpenseItems", new[] { "CategoryId" });
            DropIndex("dbo.ExpenseCategories", new[] { "ParentId" });
            DropTable("dbo.ExpenseItems");
            DropTable("dbo.ExpenseCategories");
        }
    }
}
