namespace Project1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class eleventh : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.PeripheralDevices", name: "Id", newName: "TypeId");
            RenameIndex(table: "dbo.PeripheralDevices", name: "IX_Id", newName: "IX_TypeId");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.PeripheralDevices", name: "IX_TypeId", newName: "IX_Id");
            RenameColumn(table: "dbo.PeripheralDevices", name: "TypeId", newName: "Id");
        }
    }
}
