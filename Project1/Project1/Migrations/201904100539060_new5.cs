namespace Project1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class new5 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Computers", "cpu_name", c => c.String(maxLength: 128));
            AddColumn("dbo.Computers", "hdd_name", c => c.String(maxLength: 128));
            AddColumn("dbo.Computers", "motherboard_name", c => c.String(maxLength: 128));
            CreateIndex("dbo.Computers", "cpu_name");
            CreateIndex("dbo.Computers", "hdd_name");
            CreateIndex("dbo.Computers", "motherboard_name");
            AddForeignKey("dbo.Computers", "cpu_name", "dbo.CPUs", "name");
            AddForeignKey("dbo.Computers", "hdd_name", "dbo.HDDs", "name");
            AddForeignKey("dbo.Computers", "motherboard_name", "dbo.Motherboards", "name");
            DropColumn("dbo.Computers", "motherboard");
            DropColumn("dbo.Computers", "hdd");
            DropColumn("dbo.Computers", "cpu");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Computers", "cpu", c => c.String());
            AddColumn("dbo.Computers", "hdd", c => c.String());
            AddColumn("dbo.Computers", "motherboard", c => c.String());
            DropForeignKey("dbo.Computers", "motherboard_name", "dbo.Motherboards");
            DropForeignKey("dbo.Computers", "hdd_name", "dbo.HDDs");
            DropForeignKey("dbo.Computers", "cpu_name", "dbo.CPUs");
            DropIndex("dbo.Computers", new[] { "motherboard_name" });
            DropIndex("dbo.Computers", new[] { "hdd_name" });
            DropIndex("dbo.Computers", new[] { "cpu_name" });
            DropColumn("dbo.Computers", "motherboard_name");
            DropColumn("dbo.Computers", "hdd_name");
            DropColumn("dbo.Computers", "cpu_name");
        }
    }
}
