namespace Project1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class tenth : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.PeripheralDevices", name: "TypeId", newName: "Id");
            RenameIndex(table: "dbo.PeripheralDevices", name: "IX_TypeId", newName: "IX_Id");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.PeripheralDevices", name: "IX_Id", newName: "IX_TypeId");
            RenameColumn(table: "dbo.PeripheralDevices", name: "Id", newName: "TypeId");
        }
    }
}
