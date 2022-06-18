namespace ElevatorSystem.Admin.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UserID3 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Complaints", "ApplicationUser_Id", c => c.String(maxLength: 128));
            CreateIndex("dbo.Complaints", "ApplicationUser_Id");
            AddForeignKey("dbo.Complaints", "ApplicationUser_Id", "dbo.AspNetUsers", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Complaints", "ApplicationUser_Id", "dbo.AspNetUsers");
            DropIndex("dbo.Complaints", new[] { "ApplicationUser_Id" });
            DropColumn("dbo.Complaints", "ApplicationUser_Id");
        }
    }
}
