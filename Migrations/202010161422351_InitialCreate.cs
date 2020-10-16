namespace HarryAngelGarage.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Car",
                c => new
                    {
                        CarID = c.Int(nullable: false, identity: true),
                        ClientID = c.Int(nullable: false),
                        WorkerID = c.Int(nullable: false),
                        Brand = c.String(),
                        Model = c.String(),
                        CarHandInDate = c.DateTime(nullable: false),
                        ProductionYear = c.DateTime(nullable: false),
                        BodyStyleType = c.Int(nullable: false),
                        VIN = c.String(),
                        Garage_GarageID = c.Int(),
                    })
                .PrimaryKey(t => t.CarID)
                .ForeignKey("dbo.Client", t => t.ClientID, cascadeDelete: true)
                .ForeignKey("dbo.Worker", t => t.WorkerID, cascadeDelete: true)
                .ForeignKey("dbo.Garage", t => t.Garage_GarageID)
                .Index(t => t.ClientID)
                .Index(t => t.WorkerID)
                .Index(t => t.Garage_GarageID);
            
            CreateTable(
                "dbo.Client",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        LastName = c.String(nullable: false, maxLength: 50),
                        FirstName = c.String(nullable: false),
                        City = c.String(),
                        PhoneNumber = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Helper",
                c => new
                    {
                        HelperID = c.Int(nullable: false, identity: true),
                        WorkerID = c.Int(nullable: false),
                        FirstName = c.String(),
                        LastName = c.String(),
                        BirthYear = c.DateTime(nullable: false),
                        Car_CarID = c.Int(),
                    })
                .PrimaryKey(t => t.HelperID)
                .ForeignKey("dbo.Worker", t => t.WorkerID, cascadeDelete: true)
                .ForeignKey("dbo.Car", t => t.Car_CarID)
                .Index(t => t.WorkerID)
                .Index(t => t.Car_CarID);
            
            CreateTable(
                "dbo.Worker",
                c => new
                    {
                        WorkerID = c.Int(nullable: false),
                        GarageID = c.Int(nullable: false),
                        FirstName = c.String(nullable: false),
                        LastName = c.String(nullable: false),
                        BirthYear = c.DateTime(nullable: false),
                        Salary = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.WorkerID)
                .ForeignKey("dbo.Garage", t => t.GarageID, cascadeDelete: true)
                .Index(t => t.GarageID);
            
            CreateTable(
                "dbo.Garage",
                c => new
                    {
                        GarageID = c.Int(nullable: false, identity: true),
                        GarageName = c.Int(nullable: false),
                        Space = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.GarageID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Helper", "Car_CarID", "dbo.Car");
            DropForeignKey("dbo.Helper", "WorkerID", "dbo.Worker");
            DropForeignKey("dbo.Worker", "GarageID", "dbo.Garage");
            DropForeignKey("dbo.Car", "Garage_GarageID", "dbo.Garage");
            DropForeignKey("dbo.Car", "WorkerID", "dbo.Worker");
            DropForeignKey("dbo.Car", "ClientID", "dbo.Client");
            DropIndex("dbo.Worker", new[] { "GarageID" });
            DropIndex("dbo.Helper", new[] { "Car_CarID" });
            DropIndex("dbo.Helper", new[] { "WorkerID" });
            DropIndex("dbo.Car", new[] { "Garage_GarageID" });
            DropIndex("dbo.Car", new[] { "WorkerID" });
            DropIndex("dbo.Car", new[] { "ClientID" });
            DropTable("dbo.Garage");
            DropTable("dbo.Worker");
            DropTable("dbo.Helper");
            DropTable("dbo.Client");
            DropTable("dbo.Car");
        }
    }
}
