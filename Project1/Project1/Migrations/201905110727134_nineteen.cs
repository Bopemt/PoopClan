namespace Project1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class nineteen : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Employees", "ComputerId", c => c.Int());
            CreateIndex("dbo.Employees", "ComputerId");
            AddForeignKey("dbo.Employees", "ComputerId", "dbo.Computers", "ComputerId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Employees", "ComputerId", "dbo.Computers");
            DropIndex("dbo.Employees", new[] { "ComputerId" });
            DropColumn("dbo.Employees", "ComputerId");
        }
    }
}
