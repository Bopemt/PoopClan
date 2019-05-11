namespace Project1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class peri : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.PeripheralDevices");
            AddColumn("dbo.PeripheralDevices", "PDID", c => c.Int(nullable: false, identity: true));
            AlterColumn("dbo.PeripheralDevices", "name", c => c.String());
            AddPrimaryKey("dbo.PeripheralDevices", "PDID");
        }
        
        public override void Down()
        {
            DropPrimaryKey("dbo.PeripheralDevices");
            AlterColumn("dbo.PeripheralDevices", "name", c => c.String(nullable: false, maxLength: 128));
            DropColumn("dbo.PeripheralDevices", "PDID");
            AddPrimaryKey("dbo.PeripheralDevices", "name");
        }
    }
}
