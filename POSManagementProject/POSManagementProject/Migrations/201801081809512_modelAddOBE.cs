namespace POSManagementProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class modelAddOBE : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Branches",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Code = c.String(nullable: false),
                        Contact = c.String(),
                        Address = c.String(nullable: false),
                        OrganizationId = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Organizations", t => t.OrganizationId, cascadeDelete: true)
                .Index(t => t.OrganizationId);
            
            CreateTable(
                "dbo.Organizations",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Code = c.String(nullable: false),
                        Contact = c.String(),
                        Address = c.String(nullable: false),
                        Image = c.Binary(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Employees",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Code = c.String(nullable: false),
                        Contact = c.String(nullable: false),
                        Email = c.String(nullable: false),
                        EmergencyContact = c.String(),
                        NID = c.String(),
                        FathersName = c.String(),
                        MothersName = c.String(),
                        PresentAddress = c.String(),
                        PermanentAddress = c.String(),
                        Date = c.DateTime(nullable: false),
                        Image = c.Binary(),
                        BranchId = c.Long(nullable: false),
                        ReferenceId = c.Long(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Branches", t => t.BranchId, cascadeDelete: true)
                .ForeignKey("dbo.Employees", t => t.ReferenceId)
                .Index(t => t.BranchId)
                .Index(t => t.ReferenceId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Employees", "ReferenceId", "dbo.Employees");
            DropForeignKey("dbo.Employees", "BranchId", "dbo.Branches");
            DropForeignKey("dbo.Branches", "OrganizationId", "dbo.Organizations");
            DropIndex("dbo.Employees", new[] { "ReferenceId" });
            DropIndex("dbo.Employees", new[] { "BranchId" });
            DropIndex("dbo.Branches", new[] { "OrganizationId" });
            DropTable("dbo.Employees");
            DropTable("dbo.Organizations");
            DropTable("dbo.Branches");
        }
    }
}
