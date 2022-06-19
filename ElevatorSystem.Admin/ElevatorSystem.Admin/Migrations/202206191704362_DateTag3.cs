namespace ElevatorSystem.Admin.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DateTag3 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Tags", "CreatedAt", c => c.DateTime());
            AlterColumn("dbo.Tags", "ModifiedAt", c => c.DateTime());
            DropColumn("dbo.Order_Items", "CreatedAt");
            DropColumn("dbo.Order_Items", "ModifiedAt");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Order_Items", "ModifiedAt", c => c.DateTime());
            AddColumn("dbo.Order_Items", "CreatedAt", c => c.DateTime());
            AlterColumn("dbo.Tags", "ModifiedAt", c => c.DateTime());
            AlterColumn("dbo.Tags", "CreatedAt", c => c.DateTime());
        }
    }
}
