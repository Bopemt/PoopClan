namespace Project1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class sixth : DbMigration
    {
        public override void Up()
        {
            RenameColumn("dbo.Types", "TypeId", "Id");
        }
        
        
    }
}
