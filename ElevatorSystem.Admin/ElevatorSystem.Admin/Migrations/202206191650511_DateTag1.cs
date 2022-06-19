namespace ElevatorSystem.Admin.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DateTag1 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Tags", "PublishedAt", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Tags", "PublishedAt", c => c.DateTime(precision: 7, storeType: "datetime2"));
        }
    }
}
