namespace POSManagementProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class dateAdd : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Branches", "Date", c => c.DateTime(nullable: false));
            AddColumn("dbo.Organizations", "Date", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Organizations", "Date");
            DropColumn("dbo.Branches", "Date");
        }
    }
}
