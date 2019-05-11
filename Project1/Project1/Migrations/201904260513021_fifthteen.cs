namespace Project1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fifthteen : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.PeripheralDevices", name: "DepartamentName", newName: "DepartamentId");
            RenameColumn(table: "dbo.PeripheralDevices", name: "ManufacturerName", newName: "ManufacturerId");
            RenameColumn(table: "dbo.PeripheralDevices", name: "TypeName", newName: "TypeId");
            RenameIndex(table: "dbo.PeripheralDevices", name: "IX_TypeName", newName: "IX_TypeId");
            RenameIndex(table: "dbo.PeripheralDevices", name: "IX_DepartamentName", newName: "IX_DepartamentId");
            RenameIndex(table: "dbo.PeripheralDevices", name: "IX_ManufacturerName", newName: "IX_ManufacturerId");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.PeripheralDevices", name: "IX_ManufacturerId", newName: "IX_ManufacturerName");
            RenameIndex(table: "dbo.PeripheralDevices", name: "IX_DepartamentId", newName: "IX_DepartamentName");
            RenameIndex(table: "dbo.PeripheralDevices", name: "IX_TypeId", newName: "IX_TypeName");
            RenameColumn(table: "dbo.PeripheralDevices", name: "TypeId", newName: "TypeName");
            RenameColumn(table: "dbo.PeripheralDevices", name: "ManufacturerId", newName: "ManufacturerName");
            RenameColumn(table: "dbo.PeripheralDevices", name: "DepartamentId", newName: "DepartamentName");
        }
    }
}
