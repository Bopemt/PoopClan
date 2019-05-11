namespace Project1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class eighth : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.PeripheralDevices", name: "TypId", newName: "TypeId");
            RenameIndex(table: "dbo.PeripheralDevices", name: "IX_TypId", newName: "IX_TypeId");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.PeripheralDevices", name: "IX_TypeId", newName: "IX_TypId");
            RenameColumn(table: "dbo.PeripheralDevices", name: "TypeId", newName: "TypId");
        }
    }
}
