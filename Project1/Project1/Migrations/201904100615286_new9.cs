namespace Project1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class new9 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.PeripheralDevices", "type_TypeName", "dbo.Types");
            DropIndex("dbo.PeripheralDevices", new[] { "type_TypeName" });
            RenameColumn(table: "dbo.PeripheralDevices", name: "type_TypeName", newName: "type_TypeId");
            DropPrimaryKey("dbo.Types");
            AlterColumn("dbo.PeripheralDevices", "type_TypeId", c => c.Int());
            AlterColumn("dbo.Types", "TypeName", c => c.String());
            AlterColumn("dbo.Types", "TypeId", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.Types", "TypeId");
            CreateIndex("dbo.PeripheralDevices", "type_TypeId");
            AddForeignKey("dbo.PeripheralDevices", "type_TypeId", "dbo.Types", "TypeId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PeripheralDevices", "type_TypeId", "dbo.Types");
            DropIndex("dbo.PeripheralDevices", new[] { "type_TypeId" });
            DropPrimaryKey("dbo.Types");
            AlterColumn("dbo.Types", "TypeId", c => c.Int(nullable: false));
            AlterColumn("dbo.Types", "TypeName", c => c.String(nullable: false, maxLength: 128));
            AlterColumn("dbo.PeripheralDevices", "type_TypeId", c => c.String(maxLength: 128));
            AddPrimaryKey("dbo.Types", "TypeName");
            RenameColumn(table: "dbo.PeripheralDevices", name: "type_TypeId", newName: "type_TypeName");
            CreateIndex("dbo.PeripheralDevices", "type_TypeName");
            AddForeignKey("dbo.PeripheralDevices", "type_TypeName", "dbo.Types", "TypeName");
        }
    }
}
