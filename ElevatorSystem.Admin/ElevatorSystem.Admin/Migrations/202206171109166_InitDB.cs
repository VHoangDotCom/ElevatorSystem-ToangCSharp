namespace ElevatorSystem.Admin.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitDB : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Blogs",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false),
                        Summary = c.String(),
                        IsPublished = c.Boolean(nullable: false),
                        PostContent = c.String(),
                        Thumbnail = c.String(),
                        Slug = c.String(),
                        CreatedAt = c.DateTime(nullable: false),
                        ModifiedAt = c.DateTime(nullable: false),
                        PublishedAt = c.DateTime(nullable: false),
                        TagID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Tags", t => t.TagID, cascadeDelete: true)
                .Index(t => t.TagID);
            
            CreateTable(
                "dbo.Tags",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false),
                        Description = c.String(),
                        IsPublished = c.Boolean(nullable: false),
                        CreatedAt = c.DateTime(nullable: false),
                        ModifiedAt = c.DateTime(nullable: false),
                        PublishedAt = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Description = c.String(),
                        CreatedAt = c.DateTime(nullable: false),
                        ModifiedAt = c.DateTime(nullable: false),
                        DeletedAt = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Elevators",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        SKU = c.String(),
                        Status = c.Int(nullable: false),
                        Description = c.String(),
                        Thumbnails = c.String(nullable: false),
                        Capacity = c.Double(nullable: false),
                        Speed = c.Double(nullable: false),
                        Price = c.Double(nullable: false),
                        MaxPerson = c.Int(nullable: false),
                        Location = c.String(),
                        Slug = c.String(),
                        Tag = c.String(),
                        CreatedAt = c.DateTime(nullable: false),
                        UpdatedAt = c.DateTime(nullable: false),
                        DeletedAt = c.DateTime(nullable: false),
                        CategoryID = c.Int(nullable: false),
                        DiscountID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Categories", t => t.CategoryID, cascadeDelete: true)
                .ForeignKey("dbo.Discounts", t => t.DiscountID, cascadeDelete: true)
                .Index(t => t.CategoryID)
                .Index(t => t.DiscountID);
            
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
            
            CreateTable(
                "dbo.Feedbacks",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Description = c.String(),
                        SatisfyingLevel = c.Int(nullable: false),
                        Problem = c.String(),
                        Improvement = c.String(),
                        ApplicationUserID = c.Int(nullable: false),
                        ElevatorID = c.Int(nullable: false),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.AspNetUsers", t => t.ApplicationUser_Id)
                .ForeignKey("dbo.Elevators", t => t.ElevatorID, cascadeDelete: true)
                .Index(t => t.ElevatorID)
                .Index(t => t.ApplicationUser_Id);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        ContactDetails = c.String(),
                        Company = c.String(),
                        Status = c.Int(nullable: false),
                        CreatedAt = c.DateTime(nullable: false),
                        ModifiedAt = c.DateTime(nullable: false),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.Order_Detail",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Total = c.Double(nullable: false),
                        ShippingFee = c.Double(nullable: false),
                        Tax = c.Single(nullable: false),
                        OrderEmail = c.String(nullable: false),
                        OrderStatus = c.Int(nullable: false),
                        ShipStatus = c.Int(nullable: false),
                        OrderDate = c.DateTime(nullable: false),
                        CreatedAt = c.DateTime(nullable: false),
                        ModifiedAt = c.DateTime(nullable: false),
                        ApplicationUserID = c.Int(nullable: false),
                        PaymentID = c.Int(nullable: false),
                        ApplicationUser_Id = c.String(maxLength: 128),
                        Payment_Detail_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.AspNetUsers", t => t.ApplicationUser_Id)
                .ForeignKey("dbo.Payment_Detail", t => t.Payment_Detail_ID)
                .Index(t => t.ApplicationUser_Id)
                .Index(t => t.Payment_Detail_ID);
            
            CreateTable(
                "dbo.Complaints",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false),
                        Description = c.String(),
                        ProblemFaced = c.String(),
                        OrderID = c.Int(nullable: false),
                        Order_Detail_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Order_Detail", t => t.Order_Detail_ID)
                .Index(t => t.Order_Detail_ID);
            
            CreateTable(
                "dbo.Order_Items",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        NumberOfFloor = c.Int(nullable: false),
                        Quantity = c.Int(nullable: false),
                        CreatedAt = c.DateTime(nullable: false),
                        ModifiedAt = c.DateTime(nullable: false),
                        ElevatorID = c.Int(nullable: false),
                        Order_DetailID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Elevators", t => t.ElevatorID, cascadeDelete: true)
                .ForeignKey("dbo.Order_Detail", t => t.Order_DetailID, cascadeDelete: true)
                .Index(t => t.ElevatorID)
                .Index(t => t.Order_DetailID);
            
            CreateTable(
                "dbo.Payment_Detail",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Amount = c.Double(nullable: false),
                        Provider = c.String(),
                        Status = c.Int(nullable: false),
                        CreatedAt = c.DateTime(nullable: false),
                        ModifiedAt = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Projects",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Status = c.Int(nullable: false),
                        StartDate = c.DateTime(nullable: false),
                        EndDate = c.DateTime(nullable: false),
                        Description = c.String(),
                        Partner = c.String(),
                        Term = c.String(),
                        Images = c.String(),
                        ContractDocument = c.String(),
                        CreatedAt = c.DateTime(nullable: false),
                        UpdatedAt = c.DateTime(nullable: false),
                        DeletedAt = c.DateTime(nullable: false),
                        Order_DetailID = c.Int(nullable: false),
                        ApplicationUserID = c.Int(nullable: false),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.AspNetUsers", t => t.ApplicationUser_Id)
                .ForeignKey("dbo.Order_Detail", t => t.Order_DetailID, cascadeDelete: true)
                .Index(t => t.Order_DetailID)
                .Index(t => t.ApplicationUser_Id);
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
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
                        ApplicationUserID = c.Int(nullable: false),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.AspNetUsers", t => t.ApplicationUser_Id)
                .Index(t => t.ApplicationUser_Id);
            
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
                        ApplicationUserID = c.Int(nullable: false),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.AspNetUsers", t => t.ApplicationUser_Id)
                .Index(t => t.ApplicationUser_Id);
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.Feedbacks", "ElevatorID", "dbo.Elevators");
            DropForeignKey("dbo.User_Payment", "ApplicationUser_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.User_Address", "ApplicationUser_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Projects", "Order_DetailID", "dbo.Order_Detail");
            DropForeignKey("dbo.Projects", "ApplicationUser_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Order_Detail", "Payment_Detail_ID", "dbo.Payment_Detail");
            DropForeignKey("dbo.Order_Items", "Order_DetailID", "dbo.Order_Detail");
            DropForeignKey("dbo.Order_Items", "ElevatorID", "dbo.Elevators");
            DropForeignKey("dbo.Complaints", "Order_Detail_ID", "dbo.Order_Detail");
            DropForeignKey("dbo.Order_Detail", "ApplicationUser_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Feedbacks", "ApplicationUser_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Elevators", "DiscountID", "dbo.Discounts");
            DropForeignKey("dbo.Elevators", "CategoryID", "dbo.Categories");
            DropForeignKey("dbo.Blogs", "TagID", "dbo.Tags");
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.User_Payment", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.User_Address", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.Projects", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.Projects", new[] { "Order_DetailID" });
            DropIndex("dbo.Order_Items", new[] { "Order_DetailID" });
            DropIndex("dbo.Order_Items", new[] { "ElevatorID" });
            DropIndex("dbo.Complaints", new[] { "Order_Detail_ID" });
            DropIndex("dbo.Order_Detail", new[] { "Payment_Detail_ID" });
            DropIndex("dbo.Order_Detail", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.Feedbacks", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.Feedbacks", new[] { "ElevatorID" });
            DropIndex("dbo.Elevators", new[] { "DiscountID" });
            DropIndex("dbo.Elevators", new[] { "CategoryID" });
            DropIndex("dbo.Blogs", new[] { "TagID" });
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.User_Payment");
            DropTable("dbo.User_Address");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.Projects");
            DropTable("dbo.Payment_Detail");
            DropTable("dbo.Order_Items");
            DropTable("dbo.Complaints");
            DropTable("dbo.Order_Detail");
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.Feedbacks");
            DropTable("dbo.Discounts");
            DropTable("dbo.Elevators");
            DropTable("dbo.Categories");
            DropTable("dbo.Tags");
            DropTable("dbo.Blogs");
        }
    }
}
