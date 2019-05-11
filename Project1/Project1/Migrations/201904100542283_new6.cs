namespace Project1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class new6 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.PeripheralDevices", "type_TypeId", "dbo.Types");
            DropIndex("dbo.PeripheralDevices", new[] { "type_TypeId" });
            RenameColumn(table: "dbo.PeripheralDevices", name: "type_TypeId", newName: "type_TypeName");
            DropPrimaryKey("dbo.Types");
            AlterColumn("dbo.PeripheralDevices", "type_TypeName", c => c.String(maxLength: 128));
            AlterColumn("dbo.Types", "TypeId", c => c.Int(nullable: false));
            AlterColumn("dbo.Types", "TypeName", c => c.String(nullable: false, maxLength: 128));
            AddPrimaryKey("dbo.Types", "TypeName");
            CreateIndex("dbo.PeripheralDevices", "type_TypeName");
            AddForeignKey("dbo.PeripheralDevices", "type_TypeName", "dbo.Types", "TypeName");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PeripheralDevices", "type_TypeName", "dbo.Types");
            DropIndex("dbo.PeripheralDevices", new[] { "type_TypeName" });
            DropPrimaryKey("dbo.Types");
            AlterColumn("dbo.Types", "TypeName", c => c.String());
            AlterColumn("dbo.Types", "TypeId", c => c.Int(nullable: false, identity: true));
            AlterColumn("dbo.PeripheralDevices", "type_TypeName", c => c.Int());
            AddPrimaryKey("dbo.Types", "TypeId");
            RenameColumn(table: "dbo.PeripheralDevices", name: "type_TypeName", newName: "type_TypeId");
            CreateIndex("dbo.PeripheralDevices", "type_TypeId");
            AddForeignKey("dbo.PeripheralDevices", "type_TypeId", "dbo.Types", "TypeId");
        }
    }
}
