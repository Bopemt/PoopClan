namespace Project1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class twenty : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.Employees");
            AddColumn("dbo.Employees", "EmployeeID", c => c.Int(nullable: false, identity: true));
            AlterColumn("dbo.Administrators", "Password", c => c.String(nullable: false));
            AlterColumn("dbo.CPUs", "CpuName", c => c.String(nullable: false));
            AlterColumn("dbo.CPUs", "rate", c => c.String(nullable: false));
            AlterColumn("dbo.Manufacturers", "ManufacturerName", c => c.String(nullable: false));
            AlterColumn("dbo.HDDs", "HddName", c => c.String(nullable: false));
            AlterColumn("dbo.Motherboards", "MotherboardName", c => c.String(nullable: false));
            AlterColumn("dbo.Departaments", "DepartamentName", c => c.String(nullable: false));
            AlterColumn("dbo.Employees", "fullName", c => c.String(nullable: false));
            AlterColumn("dbo.Employees", "position", c => c.String(nullable: false));
            AlterColumn("dbo.PeripheralDevices", "name", c => c.String(nullable: false));
            AlterColumn("dbo.Types", "TypeName", c => c.String(nullable: false));
            AddPrimaryKey("dbo.Employees", "EmployeeID");
        }
        
        public override void Down()
        {
            DropPrimaryKey("dbo.Employees");
            AlterColumn("dbo.Types", "TypeName", c => c.String());
            AlterColumn("dbo.PeripheralDevices", "name", c => c.String());
            AlterColumn("dbo.Employees", "position", c => c.String());
            AlterColumn("dbo.Employees", "fullName", c => c.String(nullable: false, maxLength: 128));
            AlterColumn("dbo.Departaments", "DepartamentName", c => c.String());
            AlterColumn("dbo.Motherboards", "MotherboardName", c => c.String());
            AlterColumn("dbo.HDDs", "HddName", c => c.String());
            AlterColumn("dbo.Manufacturers", "ManufacturerName", c => c.String());
            AlterColumn("dbo.CPUs", "rate", c => c.String());
            AlterColumn("dbo.CPUs", "CpuName", c => c.String());
            AlterColumn("dbo.Administrators", "Password", c => c.String());
            DropColumn("dbo.Employees", "EmployeeID");
            AddPrimaryKey("dbo.Employees", "fullName");
        }
    }
}
