namespace ElevatorSystem.Admin.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdaterequiredOrder : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Orders", "OrderEmail", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Orders", "OrderEmail", c => c.String(nullable: false));
        }
    }
}
