namespace Project1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class new11 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.PeripheralDevices", "type_TypeId", "dbo.Types");
            RenameColumn(table: "dbo.PeripheralDevices", name: "type_TypeId", newName: "type_Id");
            RenameIndex(table: "dbo.PeripheralDevices", name: "IX_type_TypeId", newName: "IX_type_Id");
            DropPrimaryKey("dbo.Types");
            AddColumn("dbo.Types", "Id", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.Types", "Id");
            AddForeignKey("dbo.PeripheralDevices", "type_Id", "dbo.Types", "Id");
            DropColumn("dbo.Types", "TypeId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Types", "TypeId", c => c.Int(nullable: false, identity: true));
            DropForeignKey("dbo.PeripheralDevices", "type_Id", "dbo.Types");
            DropPrimaryKey("dbo.Types");
            DropColumn("dbo.Types", "Id");
            AddPrimaryKey("dbo.Types", "TypeId");
            RenameIndex(table: "dbo.PeripheralDevices", name: "IX_type_Id", newName: "IX_type_TypeId");
            RenameColumn(table: "dbo.PeripheralDevices", name: "type_Id", newName: "type_TypeId");
            AddForeignKey("dbo.PeripheralDevices", "type_TypeId", "dbo.Types", "TypeId");
        }
    }
}
