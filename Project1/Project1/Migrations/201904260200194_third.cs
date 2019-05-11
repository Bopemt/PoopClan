namespace Project1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class third : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.PeripheralDevices", name: "departament_DepartamentId", newName: "DepartamentId");
            RenameColumn(table: "dbo.PeripheralDevices", name: "manufacturer_ManufacturerId", newName: "ManufacturerId");
            RenameColumn(table: "dbo.PeripheralDevices", name: "type_Id", newName: "TypeId");
            RenameIndex(table: "dbo.PeripheralDevices", name: "IX_type_Id", newName: "IX_TypeId");
            RenameIndex(table: "dbo.PeripheralDevices", name: "IX_departament_DepartamentId", newName: "IX_DepartamentId");
            RenameIndex(table: "dbo.PeripheralDevices", name: "IX_manufacturer_ManufacturerId", newName: "IX_ManufacturerId");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.PeripheralDevices", name: "IX_ManufacturerId", newName: "IX_manufacturer_ManufacturerId");
            RenameIndex(table: "dbo.PeripheralDevices", name: "IX_DepartamentId", newName: "IX_departament_DepartamentId");
            RenameIndex(table: "dbo.PeripheralDevices", name: "IX_TypeId", newName: "IX_type_Id");
            RenameColumn(table: "dbo.PeripheralDevices", name: "TypeId", newName: "type_Id");
            RenameColumn(table: "dbo.PeripheralDevices", name: "ManufacturerId", newName: "manufacturer_ManufacturerId");
            RenameColumn(table: "dbo.PeripheralDevices", name: "DepartamentId", newName: "departament_DepartamentId");
        }
    }
}
