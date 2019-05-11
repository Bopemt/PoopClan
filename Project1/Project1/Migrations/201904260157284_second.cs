namespace Project1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class second : DbMigration
    {
        public override void Up()
        {
            RenameColumn("dbo.Types", "Id", "TypeId");
        }
        
        public override void Down()
        {
        }
    }
}
