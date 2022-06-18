namespace ElevatorSystem.Admin.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DateTimeFix : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Tags", "CreatedAt", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Tags", "ModifiedAt", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Tags", "PublishedAt", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Tags", "PublishedAt", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Tags", "ModifiedAt", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Tags", "CreatedAt", c => c.DateTime(nullable: false));
        }
    }
}
