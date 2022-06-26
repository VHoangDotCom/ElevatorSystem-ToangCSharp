namespace ElevatorSystem.Admin.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateOrderDetail : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Order_Items", "Order_ID", "dbo.Orders");
            DropIndex("dbo.Order_Items", new[] { "Order_ID" });
            RenameColumn(table: "dbo.Order_Items", name: "Order_ID", newName: "OrderID");
            AlterColumn("dbo.Order_Items", "OrderID", c => c.Int(nullable: false));
            CreateIndex("dbo.Order_Items", "OrderID");
            AddForeignKey("dbo.Order_Items", "OrderID", "dbo.Orders", "ID", cascadeDelete: true);
            DropColumn("dbo.Order_Items", "Order_DetailID");
            DropColumn("dbo.Payment_Detail", "Amount");
            DropColumn("dbo.Payment_Detail", "Status");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Payment_Detail", "Status", c => c.Int(nullable: false));
            AddColumn("dbo.Payment_Detail", "Amount", c => c.Double(nullable: false));
            AddColumn("dbo.Order_Items", "Order_DetailID", c => c.Int(nullable: false));
            DropForeignKey("dbo.Order_Items", "OrderID", "dbo.Orders");
            DropIndex("dbo.Order_Items", new[] { "OrderID" });
            AlterColumn("dbo.Order_Items", "OrderID", c => c.Int());
            RenameColumn(table: "dbo.Order_Items", name: "OrderID", newName: "Order_ID");
            CreateIndex("dbo.Order_Items", "Order_ID");
            AddForeignKey("dbo.Order_Items", "Order_ID", "dbo.Orders", "ID");
        }
    }
}
