namespace POSManagementProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addJoinDate : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Employees", "JoiningDate", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Employees", "JoiningDate");
        }
    }
}
