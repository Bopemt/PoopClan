namespace Project1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class eighteen : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.PeripheralDevices", "ComputerId", "dbo.Computers");
            DropPrimaryKey("dbo.Computers");
            DropColumn("dbo.Computers", "id");
            AddColumn("dbo.Computers", "ComputerId", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.Computers", "ComputerId");
            AddForeignKey("dbo.PeripheralDevices", "ComputerId", "dbo.Computers", "ComputerId");
            
        }
        
        public override void Down()
        {
            AddColumn("dbo.Computers", "id", c => c.Int(nullable: false, identity: true));
            DropForeignKey("dbo.PeripheralDevices", "ComputerId", "dbo.Computers");
            DropPrimaryKey("dbo.Computers");
            DropColumn("dbo.Computers", "ComputerId");
            AddPrimaryKey("dbo.Computers", "id");
            AddForeignKey("dbo.PeripheralDevices", "ComputerId", "dbo.Computers", "id");
        }
    }
}
