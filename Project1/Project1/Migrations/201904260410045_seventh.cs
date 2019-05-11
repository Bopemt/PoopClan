namespace Project1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class seventh : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.PeripheralDevices", name: "TypeId", newName: "TypId");
            RenameIndex(table: "dbo.PeripheralDevices", name: "IX_TypeId", newName: "IX_TypId");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.PeripheralDevices", name: "IX_TypId", newName: "IX_TypeId");
            RenameColumn(table: "dbo.PeripheralDevices", name: "TypId", newName: "TypeId");
        }
    }
}
