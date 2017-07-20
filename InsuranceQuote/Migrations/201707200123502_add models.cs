namespace InsuranceQuote.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addmodels : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.DriverModels",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        FirstName = c.String(),
                        LastName = c.String(),
                        Address = c.String(),
                        City = c.String(),
                        State = c.String(),
                        ZipCode = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.QuoteModels",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Age = c.Int(nullable: false),
                        ZipCode = c.Int(nullable: false),
                        AnnualMilage = c.Int(nullable: false),
                        Make = c.String(),
                        Model = c.String(),
                        Year = c.Int(nullable: false),
                        DriverModel_Id = c.Guid(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.DriverModels", t => t.DriverModel_Id)
                .Index(t => t.DriverModel_Id);
            
            CreateTable(
                "dbo.VehicleModels",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Make = c.String(),
                        Model = c.String(),
                        Year = c.Int(nullable: false),
                        DriverModel_Id = c.Guid(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.DriverModels", t => t.DriverModel_Id)
                .Index(t => t.DriverModel_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.VehicleModels", "DriverModel_Id", "dbo.DriverModels");
            DropForeignKey("dbo.QuoteModels", "DriverModel_Id", "dbo.DriverModels");
            DropIndex("dbo.VehicleModels", new[] { "DriverModel_Id" });
            DropIndex("dbo.QuoteModels", new[] { "DriverModel_Id" });
            DropTable("dbo.VehicleModels");
            DropTable("dbo.QuoteModels");
            DropTable("dbo.DriverModels");
        }
    }
}
