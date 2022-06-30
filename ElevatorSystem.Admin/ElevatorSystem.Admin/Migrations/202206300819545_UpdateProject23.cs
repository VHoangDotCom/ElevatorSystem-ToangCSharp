namespace ElevatorSystem.Admin.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateProject23 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Projects", "Name", c => c.String());
            AddColumn("dbo.Projects", "Title", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Projects", "Title");
            DropColumn("dbo.Projects", "Name");
        }
    }
}
