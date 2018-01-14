namespace POSManagementProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class partyAdd : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Parties",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Code = c.String(nullable: false),
                        Type = c.String(),
                        Contact = c.String(),
                        Email = c.String(),
                        Address = c.String(),
                        Image = c.Binary(),
                        Date = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Parties");
        }
    }
}
