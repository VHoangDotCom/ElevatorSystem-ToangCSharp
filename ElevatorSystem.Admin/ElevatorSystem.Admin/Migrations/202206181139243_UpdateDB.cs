namespace ElevatorSystem.Admin.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateDB : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Elevators", "DiscountID", "dbo.Discounts");
            DropForeignKey("dbo.User_Address", "ApplicationUser_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.User_Payment", "ApplicationUser_Id", "dbo.AspNetUsers");
            DropIndex("dbo.Elevators", new[] { "DiscountID" });
            DropIndex("dbo.User_Address", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.User_Payment", new[] { "ApplicationUser_Id" });
            AddColumn("dbo.AspNetUsers", "AddressLine1", c => c.String());
            AddColumn("dbo.AspNetUsers", "AddressLine2", c => c.String());
            AddColumn("dbo.AspNetUsers", "City", c => c.String());
            AddColumn("dbo.AspNetUsers", "Country", c => c.String());
            AddColumn("dbo.Payment_Detail", "PaymentType", c => c.String());
            DropColumn("dbo.Elevators", "DiscountID");
            DropTable("dbo.Discounts");
            DropTable("dbo.User_Address");
            DropTable("dbo.User_Payment");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.User_Payment",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        PaymentType = c.String(),
                        Provider = c.String(),
                        Account_no = c.Int(nullable: false),
                        ZIP = c.String(),
                        Expiry = c.DateTime(nullable: false),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.User_Address",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        AddressLine1 = c.String(),
                        AddressLine2 = c.String(),
                        City = c.String(),
                        Country = c.String(),
                        Telephone = c.String(),
                        Mobile = c.String(),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Discounts",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Description = c.String(),
                        DiscountPercent = c.Int(nullable: false),
                        IsActivated = c.Boolean(nullable: false),
                        CreatedAt = c.DateTime(nullable: false),
                        ModifiedAt = c.DateTime(nullable: false),
                        DeletedAt = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            AddColumn("dbo.Elevators", "DiscountID", c => c.Int(nullable: false));
            DropColumn("dbo.Payment_Detail", "PaymentType");
            DropColumn("dbo.AspNetUsers", "Country");
            DropColumn("dbo.AspNetUsers", "City");
            DropColumn("dbo.AspNetUsers", "AddressLine2");
            DropColumn("dbo.AspNetUsers", "AddressLine1");
            CreateIndex("dbo.User_Payment", "ApplicationUser_Id");
            CreateIndex("dbo.User_Address", "ApplicationUser_Id");
            CreateIndex("dbo.Elevators", "DiscountID");
            AddForeignKey("dbo.User_Payment", "ApplicationUser_Id", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.User_Address", "ApplicationUser_Id", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.Elevators", "DiscountID", "dbo.Discounts", "ID", cascadeDelete: true);
        }
    }
}
