namespace ElevatorSystem.Admin.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateUserID : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Feedbacks", "ApplicationUser_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Order_Detail", "ApplicationUser_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Projects", "ApplicationUser_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.User_Address", "ApplicationUser_Id", "dbo.AspNetUsers");
            DropIndex("dbo.Feedbacks", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.Order_Detail", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.Projects", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.User_Address", new[] { "ApplicationUser_Id" });
            AddColumn("dbo.Feedbacks", "ApplicationUser_Id1", c => c.String(maxLength: 128));
            AddColumn("dbo.Order_Detail", "ApplicationUser_Id1", c => c.String(maxLength: 128));
            AddColumn("dbo.Projects", "ApplicationUser_Id1", c => c.String(maxLength: 128));
            AddColumn("dbo.User_Address", "ApplicationUser_Id1", c => c.String(maxLength: 128));
            AlterColumn("dbo.Feedbacks", "ApplicationUser_Id", c => c.Int(nullable: false));
            AlterColumn("dbo.Order_Detail", "ApplicationUser_Id", c => c.Int(nullable: false));
            AlterColumn("dbo.Projects", "ApplicationUser_Id", c => c.Int(nullable: false));
            AlterColumn("dbo.User_Address", "ApplicationUser_Id", c => c.Int(nullable: false));
            CreateIndex("dbo.Feedbacks", "ApplicationUser_Id1");
            CreateIndex("dbo.Order_Detail", "ApplicationUser_Id1");
            CreateIndex("dbo.Projects", "ApplicationUser_Id1");
            CreateIndex("dbo.User_Address", "ApplicationUser_Id1");
            AddForeignKey("dbo.Feedbacks", "ApplicationUser_Id1", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.Order_Detail", "ApplicationUser_Id1", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.Projects", "ApplicationUser_Id1", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.User_Address", "ApplicationUser_Id1", "dbo.AspNetUsers", "Id");
            DropColumn("dbo.Feedbacks", "ApplicationUserID");
            DropColumn("dbo.Order_Detail", "ApplicationUserID");
            DropColumn("dbo.Projects", "ApplicationUserID");
            DropColumn("dbo.User_Address", "ApplicationUserID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.User_Address", "ApplicationUserID", c => c.Int(nullable: false));
            AddColumn("dbo.Projects", "ApplicationUserID", c => c.Int(nullable: false));
            AddColumn("dbo.Order_Detail", "ApplicationUserID", c => c.Int(nullable: false));
            AddColumn("dbo.Feedbacks", "ApplicationUserID", c => c.Int(nullable: false));
            DropForeignKey("dbo.User_Address", "ApplicationUser_Id1", "dbo.AspNetUsers");
            DropForeignKey("dbo.Projects", "ApplicationUser_Id1", "dbo.AspNetUsers");
            DropForeignKey("dbo.Order_Detail", "ApplicationUser_Id1", "dbo.AspNetUsers");
            DropForeignKey("dbo.Feedbacks", "ApplicationUser_Id1", "dbo.AspNetUsers");
            DropIndex("dbo.User_Address", new[] { "ApplicationUser_Id1" });
            DropIndex("dbo.Projects", new[] { "ApplicationUser_Id1" });
            DropIndex("dbo.Order_Detail", new[] { "ApplicationUser_Id1" });
            DropIndex("dbo.Feedbacks", new[] { "ApplicationUser_Id1" });
            AlterColumn("dbo.User_Address", "ApplicationUser_Id", c => c.String(maxLength: 128));
            AlterColumn("dbo.Projects", "ApplicationUser_Id", c => c.String(maxLength: 128));
            AlterColumn("dbo.Order_Detail", "ApplicationUser_Id", c => c.String(maxLength: 128));
            AlterColumn("dbo.Feedbacks", "ApplicationUser_Id", c => c.String(maxLength: 128));
            DropColumn("dbo.User_Address", "ApplicationUser_Id1");
            DropColumn("dbo.Projects", "ApplicationUser_Id1");
            DropColumn("dbo.Order_Detail", "ApplicationUser_Id1");
            DropColumn("dbo.Feedbacks", "ApplicationUser_Id1");
            CreateIndex("dbo.User_Address", "ApplicationUser_Id");
            CreateIndex("dbo.Projects", "ApplicationUser_Id");
            CreateIndex("dbo.Order_Detail", "ApplicationUser_Id");
            CreateIndex("dbo.Feedbacks", "ApplicationUser_Id");
            AddForeignKey("dbo.User_Address", "ApplicationUser_Id", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.Projects", "ApplicationUser_Id", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.Order_Detail", "ApplicationUser_Id", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.Feedbacks", "ApplicationUser_Id", "dbo.AspNetUsers", "Id");
        }
    }
}
