namespace POSManagementProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class partyChange : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Parties", "IsCustomer", c => c.Boolean(nullable: false));
            AddColumn("dbo.Parties", "IsSupplier", c => c.Boolean(nullable: false));
            DropColumn("dbo.Parties", "Type");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Parties", "Type", c => c.String());
            DropColumn("dbo.Parties", "IsSupplier");
            DropColumn("dbo.Parties", "IsCustomer");
        }
    }
}
