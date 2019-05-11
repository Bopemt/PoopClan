namespace Project1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class seventeen : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Computers", "cpu_name", "dbo.CPUs");
            DropForeignKey("dbo.Computers", "hdd_name", "dbo.HDDs");
            DropForeignKey("dbo.Computers", "motherboard_name", "dbo.Motherboards");
            DropIndex("dbo.Computers", new[] { "cpu_name" });
            DropIndex("dbo.Computers", new[] { "hdd_name" });
            DropIndex("dbo.Computers", new[] { "motherboard_name" });
            RenameColumn(table: "dbo.Computers", name: "cpu_name", newName: "CpuId");
            RenameColumn(table: "dbo.Computers", name: "hdd_name", newName: "HddId");
            RenameColumn(table: "dbo.Computers", name: "motherboard_name", newName: "MotherboardId");
            RenameColumn(table: "dbo.CPUs", name: "manufacturer_ManufacturerId", newName: "ManufacturerId");
            RenameColumn(table: "dbo.HDDs", name: "manufacturer_ManufacturerId", newName: "ManufacturerId");
            RenameColumn(table: "dbo.Motherboards", name: "manufacturer_ManufacturerId", newName: "ManufacturerId");
            RenameColumn(table: "dbo.Employees", name: "departament_DepartamentId", newName: "DepartamentId");
            RenameIndex(table: "dbo.CPUs", name: "IX_manufacturer_ManufacturerId", newName: "IX_ManufacturerId");
            RenameIndex(table: "dbo.HDDs", name: "IX_manufacturer_ManufacturerId", newName: "IX_ManufacturerId");
            RenameIndex(table: "dbo.Motherboards", name: "IX_manufacturer_ManufacturerId", newName: "IX_ManufacturerId");
            RenameIndex(table: "dbo.Employees", name: "IX_departament_DepartamentId", newName: "IX_DepartamentId");
            DropPrimaryKey("dbo.CPUs");
            DropPrimaryKey("dbo.HDDs");
            DropPrimaryKey("dbo.Motherboards");
            AddColumn("dbo.CPUs", "CpuId", c => c.Int(nullable: false, identity: true));
            AddColumn("dbo.CPUs", "CpuName", c => c.String());
            AddColumn("dbo.HDDs", "HddId", c => c.Int(nullable: false, identity: true));
            AddColumn("dbo.HDDs", "HddName", c => c.String());
            AddColumn("dbo.Motherboards", "MotherboardId", c => c.Int(nullable: false, identity: true));
            AddColumn("dbo.Motherboards", "MotherboardName", c => c.String());
            AddColumn("dbo.PeripheralDevices", "ComputerId", c => c.Int());
            AlterColumn("dbo.Computers", "CpuId", c => c.Int());
            AlterColumn("dbo.Computers", "HddId", c => c.Int());
            AlterColumn("dbo.Computers", "MotherboardId", c => c.Int());
            AddPrimaryKey("dbo.CPUs", "CpuId");
            AddPrimaryKey("dbo.HDDs", "HddId");
            AddPrimaryKey("dbo.Motherboards", "MotherboardId");
            CreateIndex("dbo.Computers", "MotherboardId");
            CreateIndex("dbo.Computers", "HddId");
            CreateIndex("dbo.Computers", "CpuId");
            CreateIndex("dbo.PeripheralDevices", "ComputerId");
            AddForeignKey("dbo.PeripheralDevices", "ComputerId", "dbo.Computers", "id");
            AddForeignKey("dbo.Computers", "CpuId", "dbo.CPUs", "CpuId");
            AddForeignKey("dbo.Computers", "HddId", "dbo.HDDs", "HddId");
            AddForeignKey("dbo.Computers", "MotherboardId", "dbo.Motherboards", "MotherboardId");
            DropColumn("dbo.Computers", "keyboard");
            DropColumn("dbo.Computers", "mouse");
            DropColumn("dbo.Computers", "monitor");
            DropColumn("dbo.CPUs", "name");
            DropColumn("dbo.HDDs", "name");
            DropColumn("dbo.Motherboards", "name");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Motherboards", "name", c => c.String(nullable: false, maxLength: 128));
            AddColumn("dbo.HDDs", "name", c => c.String(nullable: false, maxLength: 128));
            AddColumn("dbo.CPUs", "name", c => c.String(nullable: false, maxLength: 128));
            AddColumn("dbo.Computers", "monitor", c => c.String());
            AddColumn("dbo.Computers", "mouse", c => c.String());
            AddColumn("dbo.Computers", "keyboard", c => c.String());
            DropForeignKey("dbo.Computers", "MotherboardId", "dbo.Motherboards");
            DropForeignKey("dbo.Computers", "HddId", "dbo.HDDs");
            DropForeignKey("dbo.Computers", "CpuId", "dbo.CPUs");
            DropForeignKey("dbo.PeripheralDevices", "ComputerId", "dbo.Computers");
            DropIndex("dbo.PeripheralDevices", new[] { "ComputerId" });
            DropIndex("dbo.Computers", new[] { "CpuId" });
            DropIndex("dbo.Computers", new[] { "HddId" });
            DropIndex("dbo.Computers", new[] { "MotherboardId" });
            DropPrimaryKey("dbo.Motherboards");
            DropPrimaryKey("dbo.HDDs");
            DropPrimaryKey("dbo.CPUs");
            AlterColumn("dbo.Computers", "MotherboardId", c => c.String(maxLength: 128));
            AlterColumn("dbo.Computers", "HddId", c => c.String(maxLength: 128));
            AlterColumn("dbo.Computers", "CpuId", c => c.String(maxLength: 128));
            DropColumn("dbo.PeripheralDevices", "ComputerId");
            DropColumn("dbo.Motherboards", "MotherboardName");
            DropColumn("dbo.Motherboards", "MotherboardId");
            DropColumn("dbo.HDDs", "HddName");
            DropColumn("dbo.HDDs", "HddId");
            DropColumn("dbo.CPUs", "CpuName");
            DropColumn("dbo.CPUs", "CpuId");
            AddPrimaryKey("dbo.Motherboards", "name");
            AddPrimaryKey("dbo.HDDs", "name");
            AddPrimaryKey("dbo.CPUs", "name");
            RenameIndex(table: "dbo.Employees", name: "IX_DepartamentId", newName: "IX_departament_DepartamentId");
            RenameIndex(table: "dbo.Motherboards", name: "IX_ManufacturerId", newName: "IX_manufacturer_ManufacturerId");
            RenameIndex(table: "dbo.HDDs", name: "IX_ManufacturerId", newName: "IX_manufacturer_ManufacturerId");
            RenameIndex(table: "dbo.CPUs", name: "IX_ManufacturerId", newName: "IX_manufacturer_ManufacturerId");
            RenameColumn(table: "dbo.Employees", name: "DepartamentId", newName: "departament_DepartamentId");
            RenameColumn(table: "dbo.Motherboards", name: "ManufacturerId", newName: "manufacturer_ManufacturerId");
            RenameColumn(table: "dbo.HDDs", name: "ManufacturerId", newName: "manufacturer_ManufacturerId");
            RenameColumn(table: "dbo.CPUs", name: "ManufacturerId", newName: "manufacturer_ManufacturerId");
            RenameColumn(table: "dbo.Computers", name: "MotherboardId", newName: "motherboard_name");
            RenameColumn(table: "dbo.Computers", name: "HddId", newName: "hdd_name");
            RenameColumn(table: "dbo.Computers", name: "CpuId", newName: "cpu_name");
            CreateIndex("dbo.Computers", "motherboard_name");
            CreateIndex("dbo.Computers", "hdd_name");
            CreateIndex("dbo.Computers", "cpu_name");
            AddForeignKey("dbo.Computers", "motherboard_name", "dbo.Motherboards", "name");
            AddForeignKey("dbo.Computers", "hdd_name", "dbo.HDDs", "name");
            AddForeignKey("dbo.Computers", "cpu_name", "dbo.CPUs", "name");
        }
    }
}
