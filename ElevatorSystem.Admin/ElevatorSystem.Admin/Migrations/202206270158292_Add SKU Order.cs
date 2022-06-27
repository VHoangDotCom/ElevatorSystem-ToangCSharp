namespace ElevatorSystem.Admin.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddSKUOrder : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Orders", "SKU", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Orders", "SKU");
        }
    }
}
