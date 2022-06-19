namespace ElevatorSystem.Admin.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateDB1 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Blogs", "CreatedAt", c => c.DateTime());
            AlterColumn("dbo.Blogs", "ModifiedAt", c => c.DateTime());
            AlterColumn("dbo.Blogs", "PublishedAt", c => c.DateTime());
            AlterColumn("dbo.Categories", "CreatedAt", c => c.DateTime());
            AlterColumn("dbo.Categories", "ModifiedAt", c => c.DateTime());
            AlterColumn("dbo.Categories", "DeletedAt", c => c.DateTime());
            AlterColumn("dbo.Elevators", "CreatedAt", c => c.DateTime());
            AlterColumn("dbo.Elevators", "UpdatedAt", c => c.DateTime());
            AlterColumn("dbo.Elevators", "DeletedAt", c => c.DateTime());
            AlterColumn("dbo.AspNetUsers", "CreatedAt", c => c.DateTime());
            AlterColumn("dbo.AspNetUsers", "ModifiedAt", c => c.DateTime());
            AlterColumn("dbo.Orders", "OrderDate", c => c.DateTime());
            AlterColumn("dbo.Orders", "CreatedAt", c => c.DateTime());
            AlterColumn("dbo.Orders", "ModifiedAt", c => c.DateTime());
            AlterColumn("dbo.Order_Items", "CreatedAt", c => c.DateTime());
            AlterColumn("dbo.Order_Items", "ModifiedAt", c => c.DateTime());
            AlterColumn("dbo.Payment_Detail", "CreatedAt", c => c.DateTime());
            AlterColumn("dbo.Payment_Detail", "ModifiedAt", c => c.DateTime());
            AlterColumn("dbo.Projects", "CreatedAt", c => c.DateTime());
            AlterColumn("dbo.Projects", "UpdatedAt", c => c.DateTime());
            AlterColumn("dbo.Projects", "DeletedAt", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Projects", "DeletedAt", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Projects", "UpdatedAt", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Projects", "CreatedAt", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Payment_Detail", "ModifiedAt", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Payment_Detail", "CreatedAt", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Order_Items", "ModifiedAt", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Order_Items", "CreatedAt", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Orders", "ModifiedAt", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Orders", "CreatedAt", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Orders", "OrderDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.AspNetUsers", "ModifiedAt", c => c.DateTime(nullable: false));
            AlterColumn("dbo.AspNetUsers", "CreatedAt", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Elevators", "DeletedAt", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Elevators", "UpdatedAt", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Elevators", "CreatedAt", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Categories", "DeletedAt", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Categories", "ModifiedAt", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Categories", "CreatedAt", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Blogs", "PublishedAt", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Blogs", "ModifiedAt", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Blogs", "CreatedAt", c => c.DateTime(nullable: false));
        }
    }
}
