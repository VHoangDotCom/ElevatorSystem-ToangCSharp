namespace ElevatorSystem.Admin.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UserID_2 : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.Feedbacks", new[] { "ApplicationUser_Id1" });
            DropIndex("dbo.Order_Detail", new[] { "ApplicationUser_Id1" });
            DropIndex("dbo.Projects", new[] { "ApplicationUser_Id1" });
            DropIndex("dbo.User_Address", new[] { "ApplicationUser_Id1" });
            DropColumn("dbo.Feedbacks", "ApplicationUser_Id");
            DropColumn("dbo.Order_Detail", "ApplicationUser_Id");
            DropColumn("dbo.Projects", "ApplicationUser_Id");
            DropColumn("dbo.User_Address", "ApplicationUser_Id");
            RenameColumn(table: "dbo.Feedbacks", name: "ApplicationUser_Id1", newName: "ApplicationUser_Id");
            RenameColumn(table: "dbo.Order_Detail", name: "ApplicationUser_Id1", newName: "ApplicationUser_Id");
            RenameColumn(table: "dbo.Projects", name: "ApplicationUser_Id1", newName: "ApplicationUser_Id");
            RenameColumn(table: "dbo.User_Address", name: "ApplicationUser_Id1", newName: "ApplicationUser_Id");
            AlterColumn("dbo.Feedbacks", "ApplicationUser_Id", c => c.String(maxLength: 128));
            AlterColumn("dbo.Order_Detail", "ApplicationUser_Id", c => c.String(maxLength: 128));
            AlterColumn("dbo.Projects", "ApplicationUser_Id", c => c.String(maxLength: 128));
            AlterColumn("dbo.User_Address", "ApplicationUser_Id", c => c.String(maxLength: 128));
            CreateIndex("dbo.Feedbacks", "ApplicationUser_Id");
            CreateIndex("dbo.Order_Detail", "ApplicationUser_Id");
            CreateIndex("dbo.Projects", "ApplicationUser_Id");
            CreateIndex("dbo.User_Address", "ApplicationUser_Id");
            DropColumn("dbo.User_Payment", "ApplicationUserId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.User_Payment", "ApplicationUserId", c => c.Int(nullable: false));
            DropIndex("dbo.User_Address", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.Projects", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.Order_Detail", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.Feedbacks", new[] { "ApplicationUser_Id" });
            AlterColumn("dbo.User_Address", "ApplicationUser_Id", c => c.Int(nullable: false));
            AlterColumn("dbo.Projects", "ApplicationUser_Id", c => c.Int(nullable: false));
            AlterColumn("dbo.Order_Detail", "ApplicationUser_Id", c => c.Int(nullable: false));
            AlterColumn("dbo.Feedbacks", "ApplicationUser_Id", c => c.Int(nullable: false));
            RenameColumn(table: "dbo.User_Address", name: "ApplicationUser_Id", newName: "ApplicationUser_Id1");
            RenameColumn(table: "dbo.Projects", name: "ApplicationUser_Id", newName: "ApplicationUser_Id1");
            RenameColumn(table: "dbo.Order_Detail", name: "ApplicationUser_Id", newName: "ApplicationUser_Id1");
            RenameColumn(table: "dbo.Feedbacks", name: "ApplicationUser_Id", newName: "ApplicationUser_Id1");
            AddColumn("dbo.User_Address", "ApplicationUser_Id", c => c.Int(nullable: false));
            AddColumn("dbo.Projects", "ApplicationUser_Id", c => c.Int(nullable: false));
            AddColumn("dbo.Order_Detail", "ApplicationUser_Id", c => c.Int(nullable: false));
            AddColumn("dbo.Feedbacks", "ApplicationUser_Id", c => c.Int(nullable: false));
            CreateIndex("dbo.User_Address", "ApplicationUser_Id1");
            CreateIndex("dbo.Projects", "ApplicationUser_Id1");
            CreateIndex("dbo.Order_Detail", "ApplicationUser_Id1");
            CreateIndex("dbo.Feedbacks", "ApplicationUser_Id1");
        }
    }
}
