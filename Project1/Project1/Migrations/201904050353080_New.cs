namespace Project1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class New : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Administrators",
                c => new
                    {
                        Login = c.String(nullable: false, maxLength: 128),
                        Password = c.String(),
                    })
                .PrimaryKey(t => t.Login);
            
            CreateTable(
                "dbo.Computers",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        status = c.String(),
                        motherboard = c.String(),
                        hdd = c.String(),
                        cpu = c.String(),
                        keyboard = c.String(),
                        mouse = c.String(),
                        monitor = c.String(),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.CPUs",
                c => new
                    {
                        name = c.String(nullable: false, maxLength: 128),
                        rate = c.String(),
                        manufacturer_ManufacturerId = c.Int(),
                    })
                .PrimaryKey(t => t.name)
                .ForeignKey("dbo.Manufacturers", t => t.manufacturer_ManufacturerId)
                .Index(t => t.manufacturer_ManufacturerId);
            
            CreateTable(
                "dbo.Manufacturers",
                c => new
                    {
                        ManufacturerId = c.Int(nullable: false, identity: true),
                        ManufacturerName = c.String(),
                    })
                .PrimaryKey(t => t.ManufacturerId);
            
            CreateTable(
                "dbo.Departaments",
                c => new
                    {
                        DepartamentId = c.Int(nullable: false, identity: true),
                        DepartamentName = c.String(),
                    })
                .PrimaryKey(t => t.DepartamentId);
            
            CreateTable(
                "dbo.Employees",
                c => new
                    {
                        fullName = c.String(nullable: false, maxLength: 128),
                        position = c.String(),
                        departament_DepartamentId = c.Int(),
                    })
                .PrimaryKey(t => t.fullName)
                .ForeignKey("dbo.Departaments", t => t.departament_DepartamentId)
                .Index(t => t.departament_DepartamentId);
            
            CreateTable(
                "dbo.HDDs",
                c => new
                    {
                        name = c.String(nullable: false, maxLength: 128),
                        capacity = c.Int(nullable: false),
                        manufacturer_ManufacturerId = c.Int(),
                    })
                .PrimaryKey(t => t.name)
                .ForeignKey("dbo.Manufacturers", t => t.manufacturer_ManufacturerId)
                .Index(t => t.manufacturer_ManufacturerId);
            
            CreateTable(
                "dbo.Motherboards",
                c => new
                    {
                        name = c.String(nullable: false, maxLength: 128),
                        manufacturer_ManufacturerId = c.Int(),
                    })
                .PrimaryKey(t => t.name)
                .ForeignKey("dbo.Manufacturers", t => t.manufacturer_ManufacturerId)
                .Index(t => t.manufacturer_ManufacturerId);
            
            CreateTable(
                "dbo.PeripheralDevices",
                c => new
                    {
                        name = c.String(nullable: false, maxLength: 128),
                        status = c.String(),
                        departament_DepartamentId = c.Int(),
                        manufacturer_ManufacturerId = c.Int(),
                        type_TypeName = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.name)
                .ForeignKey("dbo.Departaments", t => t.departament_DepartamentId)
                .ForeignKey("dbo.Manufacturers", t => t.manufacturer_ManufacturerId)
                .ForeignKey("dbo.Types", t => t.type_TypeName)
                .Index(t => t.departament_DepartamentId)
                .Index(t => t.manufacturer_ManufacturerId)
                .Index(t => t.type_TypeName);
            
            CreateTable(
                "dbo.Types",
                c => new
                    {
                        TypeName = c.String(nullable: false, maxLength: 128),
                        TypeId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.TypeName);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PeripheralDevices", "type_TypeName", "dbo.Types");
            DropForeignKey("dbo.PeripheralDevices", "manufacturer_ManufacturerId", "dbo.Manufacturers");
            DropForeignKey("dbo.PeripheralDevices", "departament_DepartamentId", "dbo.Departaments");
            DropForeignKey("dbo.Motherboards", "manufacturer_ManufacturerId", "dbo.Manufacturers");
            DropForeignKey("dbo.HDDs", "manufacturer_ManufacturerId", "dbo.Manufacturers");
            DropForeignKey("dbo.Employees", "departament_DepartamentId", "dbo.Departaments");
            DropForeignKey("dbo.CPUs", "manufacturer_ManufacturerId", "dbo.Manufacturers");
            DropIndex("dbo.PeripheralDevices", new[] { "type_TypeName" });
            DropIndex("dbo.PeripheralDevices", new[] { "manufacturer_ManufacturerId" });
            DropIndex("dbo.PeripheralDevices", new[] { "departament_DepartamentId" });
            DropIndex("dbo.Motherboards", new[] { "manufacturer_ManufacturerId" });
            DropIndex("dbo.HDDs", new[] { "manufacturer_ManufacturerId" });
            DropIndex("dbo.Employees", new[] { "departament_DepartamentId" });
            DropIndex("dbo.CPUs", new[] { "manufacturer_ManufacturerId" });
            DropTable("dbo.Types");
            DropTable("dbo.PeripheralDevices");
            DropTable("dbo.Motherboards");
            DropTable("dbo.HDDs");
            DropTable("dbo.Employees");
            DropTable("dbo.Departaments");
            DropTable("dbo.Manufacturers");
            DropTable("dbo.CPUs");
            DropTable("dbo.Computers");
            DropTable("dbo.Administrators");
        }
    }
}
